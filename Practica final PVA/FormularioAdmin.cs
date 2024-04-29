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
    public partial class FormularioAdmin : Form
    {
        public FormularioAdmin()
        {
            InitializeComponent();
        }

        private void linklblProductosExistentes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductosExistentes productosExistentes = new ProductosExistentes();
            productosExistentes.Show();
            this.Hide();
        }
    }
}
