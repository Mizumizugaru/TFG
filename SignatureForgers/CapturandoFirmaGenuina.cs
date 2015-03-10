using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignCaptureWacomSTU;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace SignatureForgers
{
    public delegate void UpdateLabelSamples();

    public partial class CapturandoFirmaGenuina : Form
    {        
        /***/
        private WacomButton buttonClearSignature;
        private WacomButton buttonSaveSignature;
        private int currentSample = 1;
        private readonly string folderSave = Application.StartupPath;        
        /***/     
        int numberOfGenuineSignatures = 3;

        public CapturandoFirmaGenuina()
        {
            
            InitializeComponent();
            changeLabelName();

            /***/
            saveFileDialog1.InitialDirectory = folderSave;
            signControlWacomSTU1.TabletaNoConectada += signControlWacomSTU1_TabletaNoConectada;
            /***/
        }
        private void changeLabelName()
        {
            //TO DO Que el numero de muestras venga de la configuración.

            string numberToShowInLabel;
                        
            numberToShowInLabel = Convert.ToString(numberOfGenuineSignatures);

            label3.Text = numberToShowInLabel;
         

        }


        /***************************************************************************/
        /***                  Metodos del otro proyecto                         ***/

        #region Event Handlers

        private void bStartWacom_Click(object sender, EventArgs e)
        {           

            bStartWacom.Enabled = false;

            signControlWacomSTU1.WacomButtons = new WacomButtons();

            buttonClearSignature = new WacomButton
            {
                PointTopLeft = new Point(495, 24),
                PointBottomRight = new Point(623, 75),
                Type = WacomButtonType.Clear,
                Name = @"Borrar",
                Enabled = true,
            };
            signControlWacomSTU1.WacomButtons.Add(buttonClearSignature);

            buttonSaveSignature = new WacomButton
            {
                PointTopLeft = new Point(336, 24),
                PointBottomRight = new Point(464, 75),
                Type = WacomButtonType.SaveSignature,
                Name = @"Guardar",
                Enabled = true,
            };
            signControlWacomSTU1.WacomButtons.Add(buttonSaveSignature);

            foreach (var button in signControlWacomSTU1.WacomButtons)
            {
                button.ButtonPressed += buttonWacom_ButtonPressed;
            }

            //Parámetros gráficos de generación de imagen de firma (Ajustados para Wacom STU-500)
            signControlWacomSTU1.StrokeThickNoVisiblePressure = 1.6f;
            signControlWacomSTU1.StrokeThickNoVisiblePressureToExport = 3f;
            signControlWacomSTU1.StrokeMaxThickPressure = 3.5f;
            signControlWacomSTU1.StrokeVisiblePressure = true;
            signControlWacomSTU1.StrokeColor = Color.Black;

            signControlWacomSTU1.start();

            if (signControlWacomSTU1.IsWacomConnected)
            {
                /* [Laura] He cambiado el segundo parametro de GetBitmap con el numero
                 * de muestras como constante, no con la selección del nudSamples
                 * 
                 */
                signControlWacomSTU1.SetImage(GetBitmap(1, numberOfGenuineSignatures, true));
            }
            else
            {
                MessageBox.Show("ErrorInitializingWacom");
            }

            bStartWacom.Enabled = true;
        }

        private void bStopWacom_Click(object sender, EventArgs e)
        {
            bStopWacom.Enabled = false;

            signControlWacomSTU1.Stop();

            bStopWacom.Enabled = true;
        }

        private void bClearWacom_Click(object sender, EventArgs e)
        {
            signControlWacomSTU1.cleanSignature(true);
        }

        private void bSetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"");
            browseFile.Filter = "Image Files (*.bmp, *.png)| *.bmp; *.png";
            browseFile.Title = "Seleccione archivo de imagen";
            if (browseFile.ShowDialog() == DialogResult.OK)
            {
                string imageLocation = browseFile.FileName;
                signControlWacomSTU1.SetImage(new Bitmap(imageLocation));
            }

        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            string folder = string.IsNullOrEmpty(saveFileDialog1.InitialDirectory)
                          ? folderSave
                          : saveFileDialog1.InitialDirectory;
            Process.Start("explorer.exe", folder);
        }

        private void bSaveSignature_Click(object sender, EventArgs e)
        {
            byte[] birBytes;
            byte[] imageBytes;
            bool signedOutsideLimits;
            bool ret = signControlWacomSTU1.getSignature(out birBytes, out imageBytes, out signedOutsideLimits);

            if (ret)
            {
                /*
                 * [Laura] Ahora guarda siempre los archivos tanto en bir como en imagen
                 * Antes había un check que permitía elegir en cual/es querías
                 */
                SaveFiles(birBytes, imageBytes);
            }
        }

        #endregion
                

        #region Wacom Event Handlers

        private void buttonWacom_ButtonPressed(object sender, WacomButtonPressedEventArgs e)
        {
            if (sender != null)
            {
                WacomButtonType type = ((WacomButton)sender).Type;

                switch (type)
                {
                    case WacomButtonType.Clear:

                        signControlWacomSTU1.cleanSignature(true);
                        break;

                    case WacomButtonType.SaveSignature:

                        byte[] birBytes = e.WacomButtonPressedEventArgsParams.BirBytes;
                        byte[] imageBytes = e.WacomButtonPressedEventArgsParams.ImageBytes;

                        /*
                         * [Laura] Ahora guarda siempre los archivos tanto en bir como en imagen
                         * Antes había un check que permitía elegir en cual/es querías
                         */
                        SaveFiles(birBytes, imageBytes);

                        break;

                    default:
                        break;
                }
            }
        }

        private void signControlWacomSTU1_TabletaNoConectada(object sender, EventArgs e)
        {
            MessageBox.Show(@"Tableta no conectada");
        }

        #endregion

        #region Private Methods

                /*
                 * TO DO -- Cambiar el formato en el que guarda los archivos
                 * Y hacer que lo guarde en la carpeta correspondiente
                 */
        private void SaveFiles(byte[] birBytes, byte[] imageBytes)
        {
            DateTime now = DateTime.Now;

            if (birBytes != null)
            {
                string fileNameBir = string.Format("{0}{1}{2}{3}-{4}{5}{6}-{7}.bir",
                                                folderSave.EndsWith("\\") || folderSave.EndsWith("/") ? folderSave : folderSave + Path.DirectorySeparatorChar,
                                                now.Year,
                                                now.Month.ToString("D2"),
                                                now.Day.ToString("D2"),
                                                now.Hour.ToString("D2"),
                                                now.Minute.ToString("D2"),
                                                now.Second.ToString("D2"),
                                                now.Millisecond.ToString("D3"));
                File.WriteAllBytes(fileNameBir, birBytes);
            }

            if (imageBytes != null)
            {
                string fileNameImage = string.Format("{0}{1}{2}{3}-{4}{5}{6}-{7}.png",
                                                folderSave.EndsWith("\\") || folderSave.EndsWith("/") ? folderSave : folderSave + Path.DirectorySeparatorChar,
                                                now.Year,
                                                now.Month.ToString("D2"),
                                                now.Day.ToString("D2"),
                                                now.Hour.ToString("D2"),
                                                now.Minute.ToString("D2"),
                                                now.Second.ToString("D2"),
                                                now.Millisecond.ToString("D3"));
                File.WriteAllBytes(fileNameImage, imageBytes);
            }

            currentSample++;
            if (currentSample > numberOfGenuineSignatures)
            {
                currentSample = 1;
            }

            signControlWacomSTU1.cleanSignature(false);
            signControlWacomSTU1.SetImage(GetBitmap(currentSample, numberOfGenuineSignatures, true));

            Invoke(new UpdateLabelSamples(UpdateLabelSamples));
        }

        private Bitmap GetBitmap(int sampleCurrent, int? sampleTotal, bool showSamples)
        {
            Bitmap bitmap = new Bitmap(Properties.Resources.PantallaFirma11);

            if (showSamples)
            {
                string samplesText = sampleTotal == null
                    ? string.Format(@"Muestra: {0}", sampleCurrent)
                    : string.Format(@"Muestra: {0}/{1}", sampleCurrent, sampleTotal);

                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawString(samplesText,
                                    new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold),
                                    new SolidBrush(Color.Black),
                                    new PointF(38, 28));
            }

            return bitmap;
        }

        private void UpdateLabelSamples()
        {
            labelSamples.Text = string.Format(@"Muestra {0}/{1}", currentSample, numberOfGenuineSignatures);
        }

        #endregion

      
    }
}
