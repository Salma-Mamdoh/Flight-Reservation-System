using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("IF EXISTS (SELECT * FROM Flight WHERE Flight_ID = @Flight_ID) ");
                strBuilder.Append("BEGIN ");
                strBuilder.Append("DELETE FROM Flight WHERE Flight_ID = @Flight_ID ");
                strBuilder.Append("SELECT @@ROWCOUNT AS RowsAffected ");
                strBuilder.Append("END");
                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Flight_ID", textBox1.Text);
                    object rowsAffected = command.ExecuteScalar();
                    if (rowsAffected != null && rowsAffected != DBNull.Value)
                    {
                        int rows = int.Parse(rowsAffected.ToString());
                        if (rows > 0)
                        {
                            MessageBox.Show("Flight deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Flight not found.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete flight.");
                    }
                }
            }
        }
    }
}
