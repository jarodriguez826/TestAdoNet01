using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestAdoNet01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dgvData.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString =
            "Data Source=(local);Initial Catalog=PruebaSQL;"
            + "Integrated Security=true";

            string queryString = "SELECT * FROM dbo.TUsers";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConn);

                try
                {
                    sqlConn.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    dgvData.DataSource = dataTable;
                    
                    
                    /*
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string data = reader[0].ToString() + " " + reader[1] 
                            + " " + reader[2] + " " + reader[3];
                        MessageBox.Show(data);
                    }

                    reader.Close();
                    **/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } finally
                {
                    sqlConn.Close();
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string connectionString =
            "Data Source=(local);Initial Catalog=PruebaSQL;"
            + "Integrated Security=true";

            string queryString = "INSERT INTO TUsers(id, nombre, username, pass) " +
                "VALUES(@id, @nombre, @username, @pass)";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConn);

                try
                {
                    sqlConn.Open();
                    command.Parameters.AddWithValue("@id", txtId.Text);
                    command.Parameters.AddWithValue("@nombre", txtName.Text);
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@pass", txtPass.Text);

                    int result = command.ExecuteNonQuery();
                    MessageBox.Show("Registros agregados = " + result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString =
            "Data Source=(local);Initial Catalog=PruebaSQL;"
            + "Integrated Security=true";

            string queryString = "UPDATE TUsers SET nombre=@nombre, username=@username, " +
                "pass=@pass WHERE id=@id";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConn);

                try
                {
                    sqlConn.Open();
                    command.Parameters.AddWithValue("@id", 18390360);
                    command.Parameters.AddWithValue("@nombre", "Eduardo Botero");
                    command.Parameters.AddWithValue("@username", "ebuser");
                    command.Parameters.AddWithValue("@pass", "ebuser");

                    int result = command.ExecuteNonQuery();
                    MessageBox.Show("Registros actualizados = " + result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }
    }
}
