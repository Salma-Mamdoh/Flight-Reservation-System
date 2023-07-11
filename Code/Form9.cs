using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            label3.Visible = false;
            label13.Visible = false;
            label4.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aircraftId;
            if (!int.TryParse(textBox1.Text, out aircraftId))
            {
                MessageBox.Show("Please enter a valid Aircraft ID.");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Aircraft WHERE Aircraft_ID = @Aircraft_ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Aircraft_ID", aircraftId);
                        int count = (int)command.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Aircraft with ID " + aircraftId + " does not exist.");
                            return;
                        }
                    }

                    query = "SELECT * FROM Aircraft WHERE Aircraft_ID = @Aircraft_ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Aircraft_ID", aircraftId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox4.Visible = true;
                                textBox5.Visible = true;
                                button2.Visible = true;
                                label3.Visible = true;
                                label13.Visible = true;
                                label4.Visible = true;
                                label5.Visible = true;

                                textBox5.Text = reader["Model"].ToString();
                                textBox3.Text = reader["CountryMade"].ToString();
                                textBox4.Text = reader["AvailabiltyStatus"].ToString();
                                textBox2.Text = reader["SeatsCapacity"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int aircraftId;
            if (!int.TryParse(textBox1.Text, out aircraftId))
            {
                MessageBox.Show("Please enter a valid Aircraft ID.");
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
                {
                    connection.Open();
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.Append("UPDATE Aircraft SET Model = @Model, CountryMade = @CountryMade, AvailabiltyStatus = @AvailabiltyStatus, SeatsCapacity = @SeatsCapacity WHERE Aircraft_ID = @Aircraft_ID");
                    string sqlQuery = strBuilder.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Model", textBox5.Text);
                        command.Parameters.AddWithValue("@CountryMade", textBox3.Text);
                        command.Parameters.AddWithValue("@AvailabiltyStatus", textBox4.Text);
                        command.Parameters.AddWithValue("@SeatsCapacity", textBox2.Text);
                        command.Parameters.AddWithValue("@Aircraft_ID", aircraftId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Aircraft info updated successfully.");

                            }
                            else
                            {
                                MessageBox.Show("No rows were affected.");
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
