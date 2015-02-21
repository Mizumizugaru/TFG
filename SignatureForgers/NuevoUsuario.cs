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
       public string emailFromUserForm = "";
       public string phoneNumberFromUserForm = "";
                
        public NuevoUsuario()
        {
            InitializeComponent();
            
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            nameFromUserForm = textBoxName.Text;
            lastNameFromUserForm = textBoxSurname.Text;
            dniFromUserForm = textBoxDNI.Text;
            ageFromUserForm = textBoxAge.Text;
            emailFromUserForm = textBoxEmail.Text;
            phoneNumberFromUserForm = textBoxPhoneNumber.Text;
            //TO DO falta el radio button de la lateralidad

            //TO DO metodo que haga todas las comprobaciones juntas

            //Eliminamos los espacios
            dniFromUserForm = Regex.Replace(dniFromUserForm, @"\s", "");
            ageFromUserForm = Regex.Replace(ageFromUserForm, @"\s", "");
            emailFromUserForm = Regex.Replace(emailFromUserForm, @"\s", "");
            phoneNumberFromUserForm = Regex.Replace(phoneNumberFromUserForm, @"\s", "");

            //TO DO Hacer que el usuario arregle el error

            if (isNameCorrect(nameFromUserForm) == false)
            {
                nameFromUserForm = nameFromUserForm + "  ERROR AL COMPROBAR NOMBRE";
            }

            if (isLastNameCorrect(lastNameFromUserForm) == false)
            {
                lastNameFromUserForm = lastNameFromUserForm + "  ERROR AL COMPROBAR APELLIDO";
            }

            if (isAgeCorrect(ageFromUserForm) == false)
            {
                ageFromUserForm = ageFromUserForm + "  ERROR AL COMPROBAR EDAD";
            }
            if (isPhoneNumberCorrect(phoneNumberFromUserForm) == false)
            {
                phoneNumberFromUserForm = phoneNumberFromUserForm + "  ERROR AL COMPROBAR TELEFONO";
            }

            if (isDNICorrect(dniFromUserForm) == false)
            {
                dniFromUserForm = dniFromUserForm + "  ERROR AL COMPROBAR DNI";
            }


            CreateNewUserTextFiles(nameFromUserForm, lastNameFromUserForm, dniFromUserForm, ageFromUserForm, emailFromUserForm, phoneNumberFromUserForm);

            this.Close();

        }

        private static void CreateNewUserTextFiles(string name, string lastName, string dni, string age, string email, string phone)
        {
            
                string fileName;               
            
                fileName = "usuario_prueba";
                string newUserDirectory = @"D:\Laura\Uni\Curso 2014-2015\Trabajo Fin de Grado\Código\Pruebas\Usuario_PRUEBA";
                Directory.CreateDirectory(newUserDirectory);


                string[] linesInTextFile = { dni, name, lastName, age, email, phone };

                System.IO.File.WriteAllLines(newUserDirectory + @"\" + fileName + ".txt", linesInTextFile);
           
        }

        //TO DO funcion que junte todas las comprobaciones
        private string[] checkFormatOfAllParameters(string name, string lastName, string dni, string age, string email, string phone)
        {
            
            string[] allParameters = { name, lastName, dni, age, email, phone };
            
            return allParameters ;

        }

        private static bool isDNICorrect(string dni)
        {       
            string patternNumber = "[0-9]";
            string patternLetter = "[A-Z]";
                                    
            if (dni.Length == 9)
            {
                string dniNumbers = dni.Substring(0, 8);
                string dniLetter = dni.Substring(8, 1);
                dniLetter = dniLetter.ToUpper();

                //Si la los primeros 8 caracteres son números y el último una letra es correcto
                if (Regex.IsMatch(dniNumbers, patternNumber) && Regex.IsMatch(dniLetter, patternLetter))
                {
                    return true;
                }
                
            }

            return false;

        }

        private bool isNameCorrect(string name)
        {
            string patternLetter = "[a-zA-Z]";

            if (Regex.IsMatch(name, patternLetter) && name.Length <= 50)
            {
                return true;
            }
            
            return false;
        }

        private bool isLastNameCorrect(string lastName)
        {
            string patternLetter = "[a-zA-Z]";

            if (Regex.IsMatch(lastName, patternLetter) && lastName.Length <= 80)
            {
                return true;
            }

            return false;
        }

        private bool isAgeCorrect(string age)
        {
            int ageNumber;         
            string patternNumber = "[0-9]";

            //Si el string solo está formado por números
            if (Regex.IsMatch(age, patternNumber))
            {                
                //Convertimos el string a int, y si es correcto, hacemos la comprobación de edad
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
            //expresión regular sacada de la web de msdn
            return Regex.IsMatch(email,
             @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"); 
                        
        }


    }
}
