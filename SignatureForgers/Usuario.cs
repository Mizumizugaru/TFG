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
        public string userEmail;
        public string userPhone;

        //así? y/o get&set??
        public Usuario(string name, string lastName, string dni, string age, string phone, string email)
        {
            this.userName = name;
            this.userLastName = lastName;
            this.userDNI = dni;
            this.userEmail = email;
            this.userPhone = phone;
        }
    }
}
