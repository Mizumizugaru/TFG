using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureForgers
{
    public partial class ConfiguracionPassword : Form
    {
        public ConfiguracionPassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string password = "adminGuti"; 
           if (textBoxPassword.Text == password)
           {
               this.Close();
                Configuracion configuracion = new Configuracion();
                configuracion.Show();
           }
           else
           {
               string message = "La contraseña es incorrecta";
               string messageBoxTitle = "Contraseña incorrecta";
               MessageBox.Show(message, messageBoxTitle);
               textBoxPassword.Text = "";
           }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
