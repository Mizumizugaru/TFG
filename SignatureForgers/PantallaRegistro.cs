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
    public partial class PantallaRegistro : Form
    {
        public PantallaRegistro()
        {
            InitializeComponent();
        }

        private void nuevoUsuarioGen_Click(object sender, EventArgs e)
        {
            NuevoUsuario nuevoGen = new NuevoUsuario();
            nuevoGen.Show();

        }

        private void usuarioRegistradoGen_Click(object sender, EventArgs e)
        {
            LoginUsuarioRegistrado loginGen = new LoginUsuarioRegistrado();
            loginGen.Show();
        }

        private void nuevoUsuarioFal_Click(object sender, EventArgs e)
        {
            NuevoUsuario nuevoFal = new NuevoUsuario();
            nuevoFal.Show();

        }

        private void usuarioRegistradoFal_Click(object sender, EventArgs e)
        {
            LoginUsuarioRegistrado loginFal = new LoginUsuarioRegistrado();
            loginFal.Show();
        }
    }
}
