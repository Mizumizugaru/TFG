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

        private void botonGenuino_Click(object sender, EventArgs e)
        {
         
            LoginUsuarioRegistrado loginGenuino = new LoginUsuarioRegistrado("Genuino");
            loginGenuino.Show();
            
            
        }

        private void botonConfiguracion_Click(object sender, EventArgs e)
        {
            
            Configuracion Configuracion = new Configuracion();
            Configuracion.Show();
            
        }

        private void botonFalsificar_Click(object sender, EventArgs e)
        {
           
            LoginUsuarioRegistrado LoginFalsificador = new LoginUsuarioRegistrado("Falsificador");
            LoginFalsificador.Show();
            
        }


    }
}
