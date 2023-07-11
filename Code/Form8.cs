using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form8 : Form
    {
        private int userId;
        private string email;
        public Form8(string email)
        {
            this.email = email;
            InitializeComponent();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "SELECT User_ID FROM [User] WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader.GetInt32(0);
                            }
                        }
                    }

                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.Append("INSERT INTO Aircraft (Model, SeatsCapacity, CountryMade, AvailabiltyStatus, adminID) ");
                    strBuilder.Append("OUTPUT INSERTED.Aircraft_ID VALUES (@Model, @SeatsCapacity, @CountryMade, @AvailabiltyStatus, @adminID)");
                    string sqlQuery = strBuilder.ToString();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Model", textBox1.Text);
                        command.Parameters.AddWithValue("@SeatsCapacity", textBox2.Text);
                        command.Parameters.AddWithValue("@CountryMade", textBox3.Text);
                        command.Parameters.AddWithValue("@AvailabiltyStatus", textBox4.Text);
                        command.Parameters.AddWithValue("@adminID", userId);

                        int aircraftId = (int)command.ExecuteScalar();
                        Console.WriteLine("Aircraft ID: " + aircraftId);

                        if (aircraftId > 0)
                        {
                            MessageBox.Show("Aircraft added successfully. Aircraft ID: " + aircraftId);
                        }
                        else
                        {
                            MessageBox.Show("Error adding aircraft.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
