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
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string errorLog = "";
            
            int numeroMuestrasGenuinas;
            int numeroMuestrasPorNivel;
            int minutosEntreNivel8y9;
            int minutosEntreNivel9y10;

            if (Int32.TryParse(textBoxNumeroMuestrasGenuino.Text, out numeroMuestrasGenuinas) == false) 
            {
                errorLog = errorLog + "Error al convertir a int el número de muestras genuinas \n\n";
            }

            if (Int32.TryParse(textBoxNumeroMuestrasNiveles.Text, out numeroMuestrasPorNivel) == false)
            {
                errorLog = errorLog + "Error al convertir a int el número de muestras por niveles \n\n";
            }

            if (Int32.TryParse(textBoxMinEntre8y9.Text, out minutosEntreNivel8y9) == false)
            {
                errorLog = errorLog + "Error al convertir a int los minutos entre nivel 8 y 9 \n\n";
            }

            if (Int32.TryParse(textBoxMinEntre9y10.Text, out minutosEntreNivel9y10) == false)
            {
                errorLog = errorLog + "Error al convertir a int los minutos entre nivel 9 y 10 \n\n";
            }

            /*
             * ¿Cual es el rango de valores a dar al algoritmo estático?
             */


            //TO DO que los valores de aquí sirvan para la pantalla de niveles

            if (errorLog == "")
            {
                string message = "Configuración correcta";
                string messageBoxTitle = "Datos introducidos";
                MessageBox.Show(message, messageBoxTitle);

            }
            else
            {
                string message = "Configuración incorrecta!!\n\n" + errorLog;
                string messageBoxTitle = "Datos introducidos";
                MessageBox.Show(message, messageBoxTitle);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //PrimeraPantalla inicio = new PrimeraPantalla();
            //inicio.Show();

        }
    }
}
