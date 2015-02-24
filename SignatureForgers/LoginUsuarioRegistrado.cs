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
        public static string directoryDependingOnUserType = @"D:\Laura\Uni\Curso 2014-2015\Trabajo Fin de Grado\Código\Pruebas";
        public static int idToEnterApp;

        /*
         * Entramos en una carpeta u otra según si es usuario falsificador o genuino          
         */
        public LoginUsuarioRegistrado(string userType)
        {
            if (userType == "Falsificador")
            {
                directoryDependingOnUserType = @"D:\Laura\Uni\Curso 2014-2015\Trabajo Fin de Grado\Código\Pruebas\Falsificadores";
            }
            else
            {
                directoryDependingOnUserType = @"D:\Laura\Uni\Curso 2014-2015\Trabajo Fin de Grado\Código\Pruebas\Genuinos";
            }

            InitializeComponent();
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {

            if (textBoxID.Text == "")
            {
                SearchForExistingUserByDNI();
            }
            else
            {
                SearchForExistingUserByID();
            }
            
        }

        private void SearchForExistingUserByDNI()
        {
            string dniToSearch = textBoxDNI.Text;
                        
            dniToSearch = Regex.Replace(dniToSearch, @"\s", "");
            dniToSearch = dniToSearch.ToUpper();

            if (isDNIRepeated(dniToSearch) == false)
            {
                string message = "El DNI introducido no se encuentra registrado, por favor, revíselo o regístrese primero";
                string messageBoxTitle = "DNI incorrecto";
                MessageBox.Show(message, messageBoxTitle);

                //TO DO Entrar a la pantalla de falsificación
            }
            else
            {
                string message = "Hola usuario " + Convert.ToString(idToEnterApp); ;
                string messageBoxTitle = "DNI correcto";
                MessageBox.Show(message, messageBoxTitle);
            }

        }

        private void SearchForExistingUserByID()
        {
            
            string idToSearch = textBoxID.Text;
            string fileNameToCheck;
            fileNameToCheck = directoryDependingOnUserType + @"\Usuario_" + idToSearch + @"\usuario" + idToSearch + ".txt";
           
            if (File.Exists(fileNameToCheck))
            {
                string message = "Hola usuario " + idToSearch;
                string messageBoxTitle = "ID correcto";
                MessageBox.Show(message, messageBoxTitle);

                //TO DO Entrar a la pantalla de falsificación
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

            }
           
        }

        /*
         *  isDNIRepeated() y getUserID() iguales que en NuevoUsuario.cs
         */ 
        private bool isDNIRepeated(string dni)
        {
            string FirstLineOfFileToRead;
            string searchingDirectory = directoryDependingOnUserType;
            int numberOfUsersRegistered = getUserID();

            //TO DO poner bonito try-catch as clean code 

            for (int i = 0; i < numberOfUsersRegistered; i++)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(searchingDirectory + @"\Usuario_" + i + @"\usuario" + i + ".txt"))
                    {
                        FirstLineOfFileToRead = reader.ReadLine();
                        if (FirstLineOfFileToRead == dni)
                        {
                            idToEnterApp =  i;
                            return true;
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
            string fileName = directoryDependingOnUserType + @"\contadorIDs.txt";
            string IDFromTxt = System.IO.File.ReadAllText(fileName);

            if (Int32.TryParse(IDFromTxt, out userID))
            {
                return userID;
            }

            return 0;
        }

    }
}
