using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Practica_final_PVA
{
    public partial class panelInicio : Form
    {
        // Conexion con la base de datos
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");

        //Indices de imagen del imagelist de top ventas
        private int indiceIL1 = 0; 
        private int indiceIL2 = 0;
        private int indiceIL3 = 0;

        // Tabla de datos donde almacenar los ingredientes extraidos de la base de datos
        private DataTable ingredientes = new DataTable();

        // Objeto sandwich para poder montarlo a gusto
        Sandwich sandwich = new Sandwich();
        public panelInicio()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            pbTopVentas1.Image = ilTopVentas1.Images[indiceIL1];
            pbTopVentas2.Image = ilTopVentas2.Images[indiceIL2];
            pbTopVentas3.Image = ilTopVentas3.Images[indiceIL3];

            timerImagenes.Start();

            lbTopVentas1.Enabled = false;
            lbTopVentas2.Enabled = false;
            lbTopVentas3.Enabled = false;

        }



        private void cambiar_imagenes(object sender, EventArgs e)
        {
            if(indiceIL1 == ilTopVentas1.Images.Count - 1)
            {
                indiceIL1 = 0;
            }
            else
            {
                indiceIL1++;
            }

            if (indiceIL2 == ilTopVentas2.Images.Count - 1)
            {
                indiceIL2 = 0;
            }
            else
            {
                indiceIL2++;
            }

            if (indiceIL3 == ilTopVentas3.Images.Count - 1)
            {
                indiceIL3 = 0;
            }
            else
            {
                indiceIL3++;
            }

            pbTopVentas1.Image = ilTopVentas1.Images[indiceIL1];
            pbTopVentas2.Image = ilTopVentas2.Images[indiceIL2];
            pbTopVentas3.Image = ilTopVentas3.Images[indiceIL3];

            switch (indiceIL1)
            {
                case 0:
                    gbTopVentas1.Text = "Sandwich jamon york";
                    lbTopVentas1.Items.Clear();
                    lbTopVentas1.Items.Add("Lechuga");
                    lbTopVentas1.Items.Add("Jamon York");
                    lbTopVentas1.Items.Add("Tomate");
                    lbTopVentas1.Items.Add("Queso Edam");
                    break;

                case 1:
                    gbTopVentas1.Text = "Sandwich barbacoa";
                    lbTopVentas1.Items.Clear();
                    lbTopVentas1.Items.Add("Perejil");
                    lbTopVentas1.Items.Add("Pulled pork");
                    lbTopVentas1.Items.Add("Cebolla");
                    lbTopVentas1.Items.Add("Pepinillo");
                    break;

                case 2:
                    gbTopVentas1.Text = "Sandwich pechuga";
                    lbTopVentas1.Items.Clear();
                    lbTopVentas1.Items.Add("Lechuga");
                    lbTopVentas1.Items.Add("Pechuga");
                    lbTopVentas1.Items.Add("Tomate");
                    lbTopVentas1.Items.Add("Queso Cheddar");
                    lbTopVentas1.Items.Add("Mayonesa");
                    break;
            }

            switch (indiceIL2)
            {
                case 0:
                    gbTopVentas2.Text = "Sandwich de cebolla";
                    lbTopVentas2.Items.Clear();
                    lbTopVentas2.Items.Add("Lechuga");
                    lbTopVentas2.Items.Add("Jamon York");
                    lbTopVentas2.Items.Add("Tomate");
                    lbTopVentas2.Items.Add("Queso Edam");
                    break;

                case 1:
                    gbTopVentas2.Text = "Sandwich de salchicha";
                    lbTopVentas2.Items.Clear();
                    lbTopVentas2.Items.Add("Lechuga");
                    lbTopVentas2.Items.Add("Salchicha");
                    lbTopVentas2.Items.Add("Tomate");
                    lbTopVentas2.Items.Add("Mayonesa");
                    break;

                case 2:
                    gbTopVentas2.Text = "Sandwich de chorizo";
                    lbTopVentas2.Items.Clear();
                    lbTopVentas2.Items.Add("Lechuga");
                    lbTopVentas2.Items.Add("Cebolla");
                    lbTopVentas2.Items.Add("Tomate");
                    lbTopVentas2.Items.Add("Pepinillo");
                    lbTopVentas2.Items.Add("Chorizo");
                    break;
            }

            switch (indiceIL3)
            {
                case 0:
                    gbTopVentas3.Text = "Sandwich de jamon";
                    lbTopVentas3.Items.Clear();
                    lbTopVentas3.Items.Add("Jamon serrano");
                    lbTopVentas3.Items.Add("Aceite de oliva");
                    lbTopVentas3.Items.Add("Queso Edam");
                    break;

                case 1:
                    gbTopVentas3.Text = "Sandwich de atun";
                    lbTopVentas3.Items.Clear();
                    lbTopVentas3.Items.Add("Lechuga");
                    lbTopVentas3.Items.Add("Atun");
                    lbTopVentas3.Items.Add("Tomate");
                    lbTopVentas3.Items.Add("Pepino");
                    break;

                case 2:
                    gbTopVentas3.Text = "Sandwich de carbonara";
                    lbTopVentas3.Items.Clear();
                    lbTopVentas3.Items.Add("Bacon");
                    lbTopVentas3.Items.Add("Huevo frito");
                    lbTopVentas3.Items.Add("Espaguetis carbonara");
                    break;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MontaTuSandwich formMontarSandwich = new MontaTuSandwich();
            formMontarSandwich.Show();
        }

        private void lblPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario formPerfil = new PerfilUsuario(this);
            formPerfil.Show();
        }

    }
}
