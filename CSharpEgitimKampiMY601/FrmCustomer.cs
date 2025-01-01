using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampiMY601
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        string connectionString = "Server = localhost; port = 5432; Database = CSharpEgitimKampi601CustomerDb; user Id= postgres; Password = 123";

        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = new NpgsqlCommand("SELECT * FROM Customers", connection);
            var dataAdapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = new NpgsqlCommand("INSERT INTO Customers(CustomerName, CustomerSurname, CustomerCity) VALUES(@customerName, @customerSurname, @customerCity)", connection);
            command.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            command.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            command.Parameters.AddWithValue("@customerCity", txtCustomerCity.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ekleme işlemi başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = new NpgsqlCommand("DELETE FROM Customers WHERE CustomerId = @customerId", connection);
            command.Parameters.AddWithValue("@customerId", int.Parse(txtCustomerId.Text));
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Silme işlemi başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCustomers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = new NpgsqlCommand("UPDATE Customers SET CustomerName = @customerName, CustomerSurname = @customerSurname, CustomerCity = @customerCity WHERE CustomerId = @customerId", connection);
            command.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            command.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            command.Parameters.AddWithValue("@customerCity", txtCustomerCity.Text);
            command.Parameters.AddWithValue("@customerId", int.Parse(txtCustomerId.Text));
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Güncelleme işlemi başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAllCustomers();
        }
    }
}
