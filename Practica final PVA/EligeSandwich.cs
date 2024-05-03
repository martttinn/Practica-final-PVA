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
    public partial class EligeSandwich : Form
    {
        private List<SandwichPredefinido> sandwiches;
        private List<SandwichPredefinido> Cesta;

        private decimal precioTotal;

        // Conexion con la base de datos
        private SqlConnection conexion = new SqlConnection("server=(local)\\SQLEXPRESS;database=master; Integrated Security=SSPI");
        public EligeSandwich()
        {
            InitializeComponent();

            sandwiches = new List<SandwichPredefinido>();
            Cesta = new List<SandwichPredefinido>();

            cargarSandwiches();
        }

        private void cargarSandwiches()
        {
            string consulta = "SELECT Id, Nombre, Precio FROM PRODUCTOS";

            SqlCommand comando = new SqlCommand(consulta,conexion);

            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            while(lector.Read())
            {
                int id = (int)lector["Id"];
                string nombre = lector["Nombre"].ToString();
                decimal precio = Convert.ToDecimal(lector["Precio"]);
                
                SandwichPredefinido sandwich = new SandwichPredefinido(id,nombre,precio);
                
                sandwiches.Add(sandwich);
            }

            lector.Close();

            foreach(SandwichPredefinido sandwich in sandwiches)
            {
                cbSandwiches.Items.Add(sandwich.getNombre());
            }
        }

        private void anadirSandwich()
        {
            if(cbSandwiches.Text != "" && udUnidades.Value > 0)
            {
                string nomSandwich = cbSandwiches.Text;

                foreach(SandwichPredefinido sandwich in sandwiches)
                {
                    if(nomSandwich.Equals(sandwich.getNombre()))
                    {
                        sandwich.setUnidades((int)udUnidades.Value);

                        ListViewItem item = new ListViewItem(nomSandwich);
                        
                        item.SubItems.Add(sandwich.getUnidades().ToString());
                        item.SubItems.Add(sandwich.getPrecioUnitario().ToString());

                        lvSandwich.Items.Add(item);

                        this.Cesta.Add(sandwich);    
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un sandwich y las unidades primero","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anadirSandwich();
            calcPrecioTotal();
        }

        private void calcPrecioTotal()
        {
            this.precioTotal = 0;

            foreach(SandwichPredefinido sandwich in Cesta)
            {
                this.precioTotal += sandwich.calcPrecio();
            }

            lblPrecioTotal.Text = this.precioTotal.ToString();
        }

        private void eliminarSandwich()
        {
            SandwichPredefinido sandwichAEliminar = null;

            if(lvSandwich.SelectedItems.Count > 0)
            {
                string nombre = lvSandwich.SelectedItems[0].Text;

                foreach (ListViewItem item in lvSandwich.SelectedItems)
                {
                    lvSandwich.Items.Remove(item);
                }

                foreach(SandwichPredefinido sandwich in Cesta)
                {
                    if(nombre.Equals(sandwich.getNombre()))
                    {
                        sandwichAEliminar = sandwich;
                    }
                }

                Cesta.Remove(sandwichAEliminar);

                calcPrecioTotal();
            }
            else
            {

                MessageBox.Show("Por favor, selecciona un ingrediente para eliminar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarSandwich();
        }
    }
}
