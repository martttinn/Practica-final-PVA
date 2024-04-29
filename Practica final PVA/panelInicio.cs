using System;
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

            cargarIngredientes();
        }

        private void PaginaInicio_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cargarIngredientes()
        {
            string Consulta = "SELECT Nombre, Tipo, Precio FROM INGREDIENTES;";
            SqlCommand comando = new SqlCommand(Consulta,conexion);
            
            // Este adaptador de datos sirve para llenar la tabla de ingredientes
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(ingredientes);

            foreach(DataRow fila in ingredientes.Rows)
            {
                string nombre = fila["Nombre"].ToString();
                int tipo = (int)fila["Tipo"];

                switch (tipo)
                {
                    case 1:
                        cbProteina.Items.Add(nombre);
                        break;
                    
                    case 2:
                        cbVerdura.Items.Add(nombre);
                        break;

                    case 3:
                        cbqueso.Items.Add(nombre);
                        break;

                    case 4:
                        cbSalsa.Items.Add(nombre);
                        break;

                    default:
                        MessageBox.Show("Error cargando los ingredientes.");
                        break;
                }

            }
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

        private void anadirIngredientes()
        {

            string nombreProte, nombreVerdu, nombreQueso, nombreSalsa;
            int numProte, numVerdu, numQueso, numSalsa;

            nombreProte = cbProteina.Text;
            numProte = (int)udProteina.Value;

            nombreVerdu = cbVerdura.Text;
            numVerdu = (int)udVerdura.Value;

            nombreQueso = cbqueso.Text;
            numQueso = (int)udQueso.Value;

            nombreSalsa = cbSalsa.Text;
            numSalsa = (int)udSalsa.Value;
            
            if(nombreProte != "" & numProte > 0)
            {
                Ingrediente Proteina = new Ingrediente(nombreProte, ObtenerPrecio(nombreProte), 1, numProte);
                sandwich.agregarIngrediente(Proteina);

                ListViewItem prote = new ListViewItem(new[] { nombreProte, numProte.ToString(), ObtenerPrecio(nombreProte).ToString() });
                lvSandwich.Items.Add(prote);
            }
            
            if(nombreVerdu != "" & numVerdu > 0)
            {
                Ingrediente Verdura = new Ingrediente(nombreVerdu, ObtenerPrecio(nombreVerdu), 2, numVerdu);
                sandwich.agregarIngrediente(Verdura);

                ListViewItem verdu = new ListViewItem(new[] { nombreVerdu, numVerdu.ToString(), ObtenerPrecio(nombreVerdu).ToString() });
                lvSandwich.Items.Add(verdu);
            }

            if(nombreQueso != "" & numQueso > 0)
            {
                Ingrediente Queso = new Ingrediente(nombreQueso, ObtenerPrecio(nombreQueso), 3, numQueso);
                sandwich.agregarIngrediente(Queso);

                ListViewItem queso = new ListViewItem(new[] { nombreQueso, numQueso.ToString(), ObtenerPrecio(nombreQueso).ToString() });
                lvSandwich.Items.Add(queso);
            }
            
            if(nombreSalsa != "" & numSalsa > 0)
            {
                Ingrediente Salsa = new Ingrediente(nombreSalsa, ObtenerPrecio(nombreSalsa), 4, numSalsa);
                sandwich.agregarIngrediente(Salsa);

                ListViewItem salsa = new ListViewItem(new[] { nombreSalsa, numSalsa.ToString(), ObtenerPrecio(nombreSalsa).ToString() });
                lvSandwich.Items.Add(salsa);
            }

            float precioTotal = sandwich.calcularPrecio();
            lblPrecioTotal.Text = precioTotal.ToString();
        }

        // Método para obtener el precio de un ingrediente por su nombre
        private float ObtenerPrecio(string nombre)
        {
            DataRow[] rows = ingredientes.Select($"Nombre = '{nombre}'");
            if (rows.Length > 0)
            {
                return Convert.ToSingle(rows[0]["Precio"]);
            }
            return 0.0f;
        }

        // Método para obtener el tipo de un ingrediente por su nombre
        private int ObtenerTipo(string nombre)
        {
            DataRow[] rows = ingredientes.Select($"Nombre = '{nombre}'");
            if (rows.Length > 0)
            {
                return Convert.ToInt32(rows[0]["Tipo"]);
            }
            return 0; 
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            anadirIngredientes();

            cbProteina.SelectedIndex = -1;
            cbVerdura.SelectedIndex = -1;
            cbqueso.SelectedIndex = -1;
            cbSalsa.SelectedIndex = -1;
            udProteina.Value = 0;
            udVerdura.Value = 0;
            udQueso.Value = 0;
            udSalsa.Value = 0;
        }

        private void EliminarIngrediente()
        {
            if (lvSandwich.SelectedItems.Count > 0)
            {
                string nombre = lvSandwich.SelectedItems[0].Text;

                foreach (ListViewItem item in lvSandwich.SelectedItems)
                {
                    lvSandwich.Items.Remove(item);
                }

                sandwich.eliminarIngrediente(nombre);
                lblPrecioTotal.Text = (sandwich.calcularPrecio()).ToString();
                
            }
            else
            {
                
                MessageBox.Show("Por favor, selecciona un ingrediente para eliminar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarIngrediente();
        }
    }
}
