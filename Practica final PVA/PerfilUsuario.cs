using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_final_PVA
{
    public partial class PerfilUsuario : Form
    {
        private string dni, nombre, contrasena;
        private bool admin;
        public PerfilUsuario()
        {
            InitializeComponent();
            cargarInfo();
        }

        private void cargarInfo()
        {
            this.dni = gestorSesion.getDni();
            this.nombre = gestorSesion.getNombre();
            this.contrasena = gestorSesion.getContrasena();
            this.admin = gestorSesion.getAdmin();

            string bienvenida = "Bienvenido, " + this.nombre;
            lblBienvenida.Text = bienvenida.ToUpper();
        }
    }
}
