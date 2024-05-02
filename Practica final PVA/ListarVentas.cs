using Microsoft.Vbe.Interop;
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
    public partial class ListarVentas : Form
    {
        public ListarVentas()
        {
            InitializeComponent();
            ObtenerNumeroTotalVentas();
            ObtenerPrimeraColumnaList();
        }

        private int ObtenerNumeroTotalVentas()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT COUNT(*) AS TotalVentas FROM VENTAS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int totalVentas = (int)command.ExecuteScalar();

                lblTotalPedidos.Text = totalVentas.ToString();
                return totalVentas;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormularioAdmin formularioAdmin = new FormularioAdmin();
            formularioAdmin.Show();
        }

        private int Conteo = 1;
        private void ObtenerPrimeraColumnaList()
        {
            string connectionString = "server=(local)\\SQLEXPRESS;database=master; Integrated Security = SSPI";
            string query = "SELECT Id FROM VENTAS ORDER BY FechaVenta ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                int Id = (int)command.ExecuteScalar();

                string query2 = "SELECT FechaVenta FROM VENTAS WHERE Id = @ID";

                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@ID", Id);

                DateTime fechaVenta = (DateTime)command2.ExecuteScalar();

                string query3 = @"
                SELECT DV.NomProducto AS Producto
                FROM DETALLESVENTA DV
                INNER JOIN VENTAS V ON DV.IDVenta = V.Id
                WHERE DV.IDVenta = @ID";

                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@ID", Id);

                string nombre = (string)command3.ExecuteScalar();

                string query4 = "SELECT PrecioTotal FROM VENTAS WHERE Id = @Id";

                SqlCommand command4 = new SqlCommand(query4, connection);
                command4.Parameters.AddWithValue("@Id", Id);

                decimal precio = (decimal)command4.ExecuteScalar();

                string query5 = "SELECT DNI FROM VENTAS WHERE Id = @iD";

                SqlCommand command5 = new SqlCommand(query5, connection);
                command5.Parameters.AddWithValue("@iD", Id);

                string DNI = (string)command5.ExecuteScalar();

                ListViewItem item = new ListViewItem(Conteo.ToString());
                item.SubItems.Add(nombre.ToString());
                item.SubItems.Add(fechaVenta.ToShortDateString());
                item.SubItems.Add(precio.ToString());
                item.SubItems.Add(DNI.ToString());
                listView1.Items.Add(item);
            }
        }

    }
}