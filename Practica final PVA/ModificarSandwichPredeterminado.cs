using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class ModificarSandwichPredeterminado : Form
    {
        public ModificarSandwichPredeterminado()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioAdmin formularioAdmin = new FormularioAdmin();
            formularioAdmin.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
