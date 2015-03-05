using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureForgers
{
    public partial class EleccionGenuinoAFalsificar : Form
    {
        public static string executablePath = Application.StartupPath;
        public static string forgersDirectory = executablePath + @"\Falsificadores";
        public static string genuineDirectory = executablePath + @"\Genuinos";

        public EleccionGenuinoAFalsificar()
        {
            int numberOfGenuineUsers = getUserID(genuineDirectory);

            InitializeComponent();

            for (int i = 1; i <= numberOfGenuineUsers; i++)
            {
                listBox1.Items.Add("Usuario " + i);
            }           
        }

        /*
         * Para ver cual ha elegido usar o bien listBox1.GetItemText(listBox1.SelectedItem)
         * o listBox1.SelectedItem.ToString()
         */


        private void button1_Click(object sender, EventArgs e)
        {
            NivelesDeFirma niveles = new NivelesDeFirma();
            niveles.Show();
        }

        private void EleccionGenuinoAFalsificar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private int getUserID(string nameOfDirectoryDependingOnUserType)
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
