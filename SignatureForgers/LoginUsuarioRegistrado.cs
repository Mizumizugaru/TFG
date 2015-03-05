using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureForgers
{
    public partial class LoginUsuarioRegistrado : Form
    {
        public static string nameOfDirectoryDependingOnUserType = @"D:\Laura\Uni\Curso 2014-2015\Trabajo Fin de Grado\Código\Pruebas";
        public static int idToEnterApp;
        public string userType = "";

        /*
         * Entramos en una carpeta u otra según si es usuario falsificador o genuino          
         */
        public LoginUsuarioRegistrado(string type)
        {
            string executablePath = Application.StartupPath;

            if (type == "Falsificador")
            {
                nameOfDirectoryDependingOnUserType = executablePath + @"\Falsificadores";

                bool directoryExists = Directory.Exists(nameOfDirectoryDependingOnUserType);

                if (!directoryExists)
                {
                    Directory.CreateDirectory(nameOfDirectoryDependingOnUserType);
                }

                userType = "Falsificador";
                this.Text = "Login Usuario Falsificador";
            }
            else
            {
                nameOfDirectoryDependingOnUserType = executablePath + @"\Genuinos";

                bool directoryExists = Directory.Exists(nameOfDirectoryDependingOnUserType);

                if (!directoryExists)
                {
                    Directory.CreateDirectory(nameOfDirectoryDependingOnUserType);
                }

                userType = "Genuino";
                this.Text = "Login Usuario Genuino";
            }

            InitializeComponent();
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            /*
             * Buscamos preferiblemente por ID, salvo que el campo esté vacío,
             * entonces buscaremos por DNI.
             * Si existe vamos a la pantalla de captura de firma correspondiente.
             */

            if (textBoxID.Text == "")
            {

                if (SearchForExistingUserByDNI() == true)
                {
                    this.Close();

                    if (userType == "Falsificador")
                    {
                        EleccionGenuinoAFalsificar eleccionGenuino = new EleccionGenuinoAFalsificar();
                        eleccionGenuino.Show();
                    }
                    else
                    {
                        CapturandoFirmaGenuina capturaGenuina = new CapturandoFirmaGenuina();
                        capturaGenuina.Show();
                    }
                }
            }
            else
            {
                if (SearchForExistingUserByID() == true)
                {
                    this.Close();

                    if (userType == "Falsificador")
                    {
                        EleccionGenuinoAFalsificar eleccionGenuino = new EleccionGenuinoAFalsificar();
                        eleccionGenuino.Show();
                    }
                    else
                    {
                        CapturandoFirmaGenuina capturaGenuina = new CapturandoFirmaGenuina();
                        capturaGenuina.Show();
                    }
                }
            }
            
        }

        private bool SearchForExistingUserByDNI()
        {
            string dniToSearch = textBoxDNI.Text;
                        
            dniToSearch = Regex.Replace(dniToSearch, @"\s", "");
            dniToSearch = dniToSearch.ToUpper();

            if (isDNIRepeated(dniToSearch) == false)
            {
                string message = "El DNI introducido no se encuentra registrado, por favor, revíselo o regístrese primero";
                string messageBoxTitle = "DNI incorrecto";
                MessageBox.Show(message, messageBoxTitle);
                return false;

                
            }
            else
            {
                string message = "Hola usuario " + Convert.ToString(idToEnterApp); ;
                string messageBoxTitle = "DNI correcto";
                MessageBox.Show(message, messageBoxTitle);
                return true;
            }

        }

        private bool SearchForExistingUserByID()
        {
            
            string idToSearch = textBoxID.Text;
            string fileNameToCheck;
            fileNameToCheck = nameOfDirectoryDependingOnUserType + @"\Usuario_" + idToSearch + @"\usuario" + idToSearch + ".txt";
           
            if (File.Exists(fileNameToCheck))
            {
                string message = "Hola usuario " + idToSearch;
                string messageBoxTitle = "ID correcto";
                MessageBox.Show(message, messageBoxTitle);
                return true;
                                
            }
            else
            {
                string message = "El ID introducido no se encuentra registrado, por favor, revíselo o regístrese primero";
                string messageBoxTitle = "ID incorrecto";
                MessageBox.Show(message, messageBoxTitle);
                /*
                 * Si no es correcto el ID, devolvemos el campo vacío, por si quería buscar por DNI
                 * (Solo busca por DNI, si el campo de texto de ID está vacío)
                 */
                textBoxID.Text = "";
                return false;
            }
           
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userType == "Falsificador")
            {
                NuevoUsuario nuevoFal = new NuevoUsuario("Falsificador");
                nuevoFal.Show();
            }
            else
            {
                NuevoUsuario nuevoGen = new NuevoUsuario("Genuino");
                nuevoGen.Show();
            }
            this.Close();

        }

        
        /*
         *  isDNIRepeated() y getUserID() iguales que en NuevoUsuario.cs
         */


        private bool isDNIRepeated(string dni)
        {
            string FirstLineOfFileToRead;
            string searchingDirectory = nameOfDirectoryDependingOnUserType;
            int numberOfUsersRegistered = getUserID();

            //TO DO poner bonito try-catch as clean code 

            for (int i = 1; i <= numberOfUsersRegistered; i++)
            {
                try
                {
                    /*
                     * Leemos del archivo sólo si la carpeta existe
                     * Si no existe es porque aun no se han creado usuarios, 
                     * por tanto no habría DNIs repetidos tampoco
                     */
                    if (Directory.Exists(searchingDirectory + @"\Usuario_" + i))
                    {
                        using (StreamReader reader = new StreamReader(searchingDirectory + @"\Usuario_" + i + @"\usuario" + i + ".txt"))
                        {
                            FirstLineOfFileToRead = reader.ReadLine();
                            if (FirstLineOfFileToRead == dni)
                            {
                                return true;
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    throw new Exception(String.Format("An error ocurred while executing the data import: {0}", e.Message), e);
                }

            }

            return false;
        }


        private int getUserID()
        {
            int userID;
            string fileName = nameOfDirectoryDependingOnUserType + @"\contadorIDs.txt";
            if (File.Exists(fileName))
            {
                string IDFromTxt;

                using (StreamReader reader = new StreamReader(fileName))
                {
                    IDFromTxt = reader.ReadLine();
                }

                if (Int32.TryParse(IDFromTxt, out userID))
                {
                    return userID;
                }

                return -1;
            }
            else
            {
                File.WriteAllText(fileName, "1");

                return 1;
            }

        }
        
    }
    
}
