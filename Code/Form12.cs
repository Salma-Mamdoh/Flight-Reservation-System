using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form12 : Form
    {
        private int userId;
        private string email;
        public Form12(string email)
        {
            this.email = email;
            InitializeComponent();
            button2.Visible = false;
            textBox1.Visible = false;
            textBox6.Visible = false;
            comboBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
            textBox4.Visible = false;
            textBox7.Visible = false;
            label2.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label13.Visible = false;
            label3.Visible = false;
            label7.Visible = false;
            label4.Visible = false;
            label8.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flightId;
            if (!int.TryParse(textBox8.Text, out flightId))
            {
                MessageBox.Show("Please enter a valid Flight ID.");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Flight WHERE Flight_ID = @Flight_ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Flight_ID", flightId);
                        int count = (int)command.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Flight with ID " + flightId + " does not exist.");
                            return;
                        }
                    }

                    query = "SELECT * FROM Flight WHERE Flight_ID = @Flight_ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Flight_ID", flightId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                button2.Visible = true;
                                textBox1.Visible = true;
                                textBox6.Visible = true;
                                comboBox1.Visible = true;
                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox5.Visible = true;
                                textBox4.Visible = true;
                                textBox7.Visible = true;
                                label2.Visible = true;
                                label6.Visible = true;
                                label5.Visible = true;
                                label13.Visible = true;
                                label3.Visible = true;
                                label7.Visible = true;
                                label4.Visible = true;
                                label8.Visible = true;


                                textBox1.Text = reader["SourceAirport"].ToString(); ;
                                textBox6.Text = reader["Destination_Airport"].ToString();
                                comboBox1.Text = reader["FlightCalss_Type"].ToString();
                                textBox2.Text = reader["NumOfAvaliableSeats"].ToString();
                                textBox3.Text = reader["TakeOFF_time"].ToString();
                                textBox5.Text = reader["ArrivaTime"].ToString();
                                textBox4.Text = reader["aircraftID"].ToString();
                                textBox7.Text = reader["airportCode"].ToString();

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int flightId;
            if (!int.TryParse(textBox8.Text, out flightId))
            {
                MessageBox.Show("Please enter a valid Flight ID.");
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
                    strBuilder.Append("UPDATE Flight SET SourceAirport = @SourceAirport, Destination_Airport = @Destination_Airport, FlightCalss_Type = @FlightCalss_Type, NumOfAvaliableSeats = @NumOfAvaliableSeats, TakeOFF_time = @TakeOFF_time, ArrivaTime = @ArrivaTime, adminID = @adminID, aircraftID = @aircraftID, airportCode = @airportCode WHERE Flight_ID = @Flight_ID");
                    string sqlQuery = strBuilder.ToString();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Set SQL parameters
                        command.Parameters.AddWithValue("@Flight_ID", flightId);
                        command.Parameters.AddWithValue("@SourceAirport", textBox1.Text);
                        command.Parameters.AddWithValue("@Destination_Airport", textBox6.Text);
                        command.Parameters.AddWithValue("@FlightCalss_Type", comboBox1.Text);
                        command.Parameters.AddWithValue("@NumOfAvaliableSeats", textBox2.Text);
                        command.Parameters.AddWithValue("@TakeOFF_time", textBox3.Text);
                        command.Parameters.AddWithValue("@ArrivaTime", textBox5.Text);
                        command.Parameters.AddWithValue("@adminID", userId);
                        command.Parameters.AddWithValue("@aircraftID", textBox4.Text);
                        command.Parameters.AddWithValue("@airportCode", textBox7.Text);

                        // Execute SQL query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Failed to update flight. Flight with ID " + flightId + " not found.");
                        }
                        else
                        {
                            MessageBox.Show("Flight with ID " + flightId + " updated successfully.");
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
