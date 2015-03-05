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
            Form checkingIfFormIsOpen = Application.OpenForms["LoginUsuarioRegistrado"];
            if (checkingIfFormIsOpen != null)
            {
                checkingIfFormIsOpen.BringToFront();
            }
            else
            {
                LoginUsuarioRegistrado loginGenuino = new LoginUsuarioRegistrado("Genuino");
                loginGenuino.Show();
            }
            
        }

        private void botonConfiguracion_Click(object sender, EventArgs e)
        {
            Form checkingIfFormIsOpen = Application.OpenForms["ConfiguracionPassword"];
            if (checkingIfFormIsOpen != null)
            {
                checkingIfFormIsOpen.BringToFront();
            }
            else
            {
                ConfiguracionPassword configPass = new ConfiguracionPassword();
                configPass.Show();
            }
            
        }

        private void botonFalsificar_Click(object sender, EventArgs e)
        {
            Form checkingIfFormIsOpen = Application.OpenForms["LoginUsuarioRegistrado"];
            if (checkingIfFormIsOpen != null)
            {
                checkingIfFormIsOpen.BringToFront();
            }
            else
            {

                LoginUsuarioRegistrado LoginFalsificador = new LoginUsuarioRegistrado("Falsificador");
                LoginFalsificador.Show();
            }
        }


    }
}
