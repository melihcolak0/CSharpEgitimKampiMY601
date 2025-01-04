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
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        string connectionString = "Server = localhost; port = 5432; " +
            "Database = CSharpEgitimKampi601CustomerDb;" +
            " user Id= postgres; Password = 123";

        public void ListEmployee()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            //var dataAdapter = new NpgsqlDataAdapter("SELECT * FROM Employees", connection);
            var dataAdapter = new NpgsqlDataAdapter("SELECT e.employeeId, e.employeeName, e.employeeSurname," +
                " e.employeeSalary, d.departmentName FROM Employees e INNER JOIN Departments d " +
                "ON e.departmentId = d.departmentId", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        public void ListDepartment() // Combobox'a departman çekme
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var dataAdapter = new NpgsqlDataAdapter("SELECT * FROM Departments", connection);
            DataTable dataTable  = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbDepartment.DisplayMember = "departmentName";
            cmbDepartment.ValueMember = "departmentId";
            cmbDepartment.DataSource = dataTable;
            connection.Close();
        }

        public void AddEmployee()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = new NpgsqlCommand("INSERT INTO Employees(employeeName, employeeSurname," +
                " employeeSalary, departmentId) VALUES(@p1, @p2, @p3, @p4)", connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", decimal.Parse(txtSalary.Text));
            command.Parameters.AddWithValue("@p4", int.Parse(cmbDepartment.SelectedValue.ToString()));
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ekleme işlemi başarılı.", "Bilgilendirme", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            ListEmployee();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            ListEmployee();
            ListDepartment();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListEmployee();
        }        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }
    }
}
