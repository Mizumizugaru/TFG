using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureForgers
{
    class Usuario
    {
        public string userName;
        public string userLastName;
        public string userDNI;
        public string userAge;
        public string userEmail;
        public string userPhone;
        public string userLaterality;
        public int userID;

        //así? y/o get&set??
        public Usuario(string name, string lastName, string dni, string age, string phone, string email, string laterality, int id)
        {
            this.userName = name;
            this.userLastName = lastName;
            this.userDNI = dni;
            this.userAge = age;
            this.userEmail = email;
            this.userPhone = phone;
            this.userLaterality = laterality;
            this.userID = id;
        }
        //con getters y setters se accede a variables privadas
    }
}
