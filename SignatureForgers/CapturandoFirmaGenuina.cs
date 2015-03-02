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
    public partial class CapturandoFirmaGenuina : Form
    {        
        int numberOfGenuineSignatures;

        public CapturandoFirmaGenuina()
        {
            
            InitializeComponent();
            changeLabelName();
        }
        private void changeLabelName()
        {
            //TO DO Que el numero de muestras venga de la configuración.

            string numberToShowInLabel;

            numberOfGenuineSignatures = 5;

            numberToShowInLabel = Convert.ToString(numberOfGenuineSignatures);

            label3.Text = numberToShowInLabel;
         

        }
    }
}
