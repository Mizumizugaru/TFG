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
using System.Text.RegularExpressions;

namespace SignatureForgers
{
    public partial class NuevoUsuario : Form
    {
       public string nameFromUserForm = "nombreprueba";
       public string lastNameFromUserForm = "apellidoprueba";
       public string dniFromUserForm = "dniprueba";
       public string ageFromUserForm = "edadprueba";
       public string emailFromUserForm = "email@prueba.es";
       public string phoneNumberFromUserForm = "666111666";
       public string lateralityFromUserForm = "lateralidad prueba";
       public int userID = 0;

        //DUDA ¿Por qué sólo me dejaba llamarla abajo si era static??
       public static string directoryDependingOnUserType = @"D:\Laura\Uni\Curso 2014-2015\Trabajo Fin de Grado\Código\Pruebas";


        /*
        * Entramos en una carpeta u otra según si es usuario falsificador o genuino          
        */        
        public NuevoUsuario(string userType)
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

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            bool oneOrMoreErrorInForm;
            string errorLog = "";

            nameFromUserForm = textBoxName.Text;
            lastNameFromUserForm = textBoxSurname.Text;
            dniFromUserForm = textBoxDNI.Text;
            ageFromUserForm = textBoxAge.Text;
            emailFromUserForm = textBoxEmail.Text;
            phoneNumberFromUserForm = textBoxPhoneNumber.Text;
            
            /*
             * lateralidad desde los radioButtons del formulario 
             */
            if (radioButtonZurdo.Checked == true)
            {
                lateralityFromUserForm = radioButtonZurdo.Text;
            }
            else if (radioButtonDiestro.Checked == true)
            {
                lateralityFromUserForm = radioButtonDiestro.Text;
            }
            else
            {
                errorLog = errorLog + "No ha seleccionado su lateralidad. \n\n";
                oneOrMoreErrorInForm = true;
            }

                                    
            userID = getUserID();

            Usuario newUser = new Usuario(nameFromUserForm, lastNameFromUserForm, dniFromUserForm, ageFromUserForm, phoneNumberFromUserForm, emailFromUserForm, lateralityFromUserForm, userID);


            //TO DO metodo que haga todas las comprobaciones juntas

            /*
             * Eliminamos los espacios
             */
            newUser.userDNI = Regex.Replace(newUser.userDNI, @"\s", "");            
            newUser.userAge = Regex.Replace(newUser.userAge, @"\s", "");
            newUser.userEmail = Regex.Replace(newUser.userEmail, @"\s", "");
            newUser.userPhone = Regex.Replace(newUser.userPhone, @"\s", "");

            newUser.userDNI = newUser.userDNI.ToUpper();

            
            oneOrMoreErrorInForm = false;
            if (isNameCorrect(newUser.userName) == false)
            {
                errorLog = errorLog + "El nombre debe estar formado sólo por letras y tener menos de 50 caracteres. \n\n";                
                oneOrMoreErrorInForm = true;
            }

            if (isLastNameCorrect(newUser.userLastName) == false)
            {
                errorLog = errorLog + "El apellido debe estar formado sólo por letras y tener menos de 80 caracteres. \n\n";                
                oneOrMoreErrorInForm = true;
            }

            if (isDNICorrect(newUser.userDNI) == false)
            {
                errorLog = errorLog + "El DNI debe constar de 8 números y una única letra al final. \n\n";
                oneOrMoreErrorInForm = true;
            }

            if (isDNIRepeated(newUser.userDNI) == true)
            {
                errorLog = errorLog + "Ese DNI ya esta registrado. \n\n";
                oneOrMoreErrorInForm = true;
            }
         if (isAgeCorrect(newUser.userAge) == false)
            {
                errorLog = errorLog + "La edad debe estar formada sólo por números comprendidos entre 18 y 100. \n\n";                
                oneOrMoreErrorInForm = true;
            }

            if (isEmailCorrect(newUser.userEmail) == false)
            {
                errorLog = errorLog + "El formato del email no es correcto. \n\n";
                oneOrMoreErrorInForm = true;
            }

            if (isPhoneNumberCorrect(newUser.userPhone) == false)
            {
                errorLog = errorLog + "El número de teléfono debe estar formado sólo por números y tener 9 dígitos. \n";                
                oneOrMoreErrorInForm = true;
            }
                        

            /*
             * Si no ha habido ningún error creamos el registro, si no, mostramos mensaje de error
             */
            if (oneOrMoreErrorInForm == false)
            {
                CreateNewUserTextFiles(newUser.userName, newUser.userLastName, newUser.userDNI, newUser.userAge, newUser.userEmail, newUser.userPhone, newUser.userLaterality, newUser.userID);
                incrementNumberOfUserID();
                this.Close();

                //TO DO En el caso de usuarios genuinos, ahora vendría la captura de firma
            }
            else
            {
                errorLog = "Se encontraron los siguientes errores, por favor, revíselo \n\n\n" + errorLog;
                string messageBoxTitle = "Error al introducir los datos en el formulario";
                MessageBox.Show(errorLog, messageBoxTitle);
            }
            
        }

        private static void CreateNewUserTextFiles(string name, string lastName, string dni, string age, string email, string phone, string laterality, int id)
        {
            
                string fileName;               
            
                //TO DO el ID tiene que aparecer en formato XXXXX, ej: 00003, 00156...

                fileName = "usuario" + id ;                
                string newUserDirectory = directoryDependingOnUserType + @"\Usuario_" + id; ;
                Directory.CreateDirectory(newUserDirectory);

                string[] linesInTextFile = { dni, name, lastName, age, email, phone, laterality };

                System.IO.File.WriteAllLines(newUserDirectory + @"\"+ fileName + ".txt", linesInTextFile);
           
        }


        //TO DO funcion que junte todas las comprobaciones
        private void checkFormatOfAllParameters(string name, string lastName, string dni, string age, string email, string phone)
        {          
          
        }



        private bool isDNIRepeated(string dni)
        {
            string FirstLineOfFileToRead;
            string searchingDirectory = directoryDependingOnUserType;
            int numberOfUsersRegistered = getUserID();
            
            //TO DO poner bonito try-catch as clean code 

            for(int i = 0; i < numberOfUsersRegistered; i++)
            {
                try
                {                                   
                    using (StreamReader reader = new StreamReader(searchingDirectory + @"\Usuario_" + i +  @"\usuario" + i + ".txt"))
                    {
                        FirstLineOfFileToRead = reader.ReadLine();
                        if (FirstLineOfFileToRead == dni)
                        {
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

        private bool isDNICorrect(string dni)
        {       
            string patternNumber = "[0-9]";
            string patternLetter = "[A-Z]";
                                    
            if (dni.Length == 9)
            {
                string dniNumbers = dni.Substring(0, 8);
                string dniLetter = dni.Substring(8, 1);
                dniLetter = dniLetter.ToUpper();

                /*
                 * Si la los primeros 8 caracteres son números y el último una letra es correcto
                 */ 
                if (Regex.IsMatch(dniNumbers, patternNumber) && Regex.IsMatch(dniLetter, patternLetter))
                {
                    return true;
                }
                
            }

            return false;

        }

        private bool isNameCorrect(string name)
        {
            string patternLetter = @"^[a-zA-Z_áéíóúñ\s]*$";

            if (Regex.IsMatch(name, patternLetter) && name.Length <= 50 && name.Length > 0)
            {
                return true;
            }
            
            return false;
        }

        private bool isLastNameCorrect(string lastName)
        {
            string patternLetter = @"^[a-zA-Z_áéíóúñ\s]*$";

            if (Regex.IsMatch(lastName, patternLetter) && lastName.Length <= 80 && lastName.Length > 0)
            {
                return true;
            }

            return false;
        }

        private bool isAgeCorrect(string age)
        {
            int ageNumber;         
            string patternNumber = "[0-9]";

            /*
             * Si el string solo está formado por números
             */ 
            if (Regex.IsMatch(age, patternNumber))
            {                
                /*
                 * Convertimos el string a int, y si es correcto, hacemos la comprobación de edad
                 */ 
                if (Int32.TryParse(age, out ageNumber))
                {
                    if (ageNumber >= 18 && ageNumber <= 100)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private bool isPhoneNumberCorrect(string phone)
        {            
            string patternNumber = "[0-9]";

            if (Regex.IsMatch(phone, patternNumber ) && phone.Length == 9 )
            {
                return true;
            }

            return false;
        }

        private bool isEmailCorrect(string email)
        {                        
            /*
             * expresión regular sacada de la web de msdn
             */
            return Regex.IsMatch(email,
             @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"); 
                        
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

        private void incrementNumberOfUserID()
        {
            string idToTxt;
            int highestID;
            string fileName = directoryDependingOnUserType + @"\contadorIDs.txt";
            
            highestID = getUserID();
            highestID++;
            idToTxt = Convert.ToString(highestID);

            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.Write(idToTxt);
            }

        }

    }
}
