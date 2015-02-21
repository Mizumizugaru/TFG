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
    public partial class PrimeraPantalla : Form
    {
        public PrimeraPantalla()
        {
            InitializeComponent();
        }

        private void botonRegistro_Click(object sender, EventArgs e)
        {
            
            PantallaRegistro PantallaRegistro = new PantallaRegistro();
            PantallaRegistro.Show();

        }

        private void botonConfiguracion_Click(object sender, EventArgs e)
        {
            Configuracion Configuracion = new Configuracion();
            Configuracion.Show();

        }

        private void botonFalsificar_Click(object sender, EventArgs e)
        {
            LoginUsuarioRegistrado Login = new LoginUsuarioRegistrado();
            Login.Show();
        }


    }
}
