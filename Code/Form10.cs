using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form10 : Form
    {
        private int userId;
        private string email;
        public Form10(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
                strBuilder.Append("INSERT INTO Flight (SourceAirport, Destination_Airport, FlightCalss_Type, NumOfAvaliableSeats, TakeOFF_time, ArrivaTime, aircraftID, airportCode, adminID) VALUES (@SourceAirport, @Destination_Airport, @FlightCalss_Type, @NumOfAvaliableSeats, @TakeOFF_time, @ArrivaTime, @aircraftID, @airportCode, @adminID); SELECT SCOPE_IDENTITY() AS FlightID;");
                string sqlQuery = strBuilder.ToString();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@SourceAirport", textBox1.Text);
                    command.Parameters.AddWithValue("@Destination_Airport", textBox6.Text);
                    command.Parameters.AddWithValue("@FlightCalss_Type", comboBox1.Text);
                    command.Parameters.AddWithValue("@NumOfAvaliableSeats", textBox2.Text);
                    command.Parameters.AddWithValue("@TakeOFF_time", textBox3.Text);
                    command.Parameters.AddWithValue("@ArrivaTime", textBox5.Text);
                    command.Parameters.AddWithValue("@aircraftID", textBox4.Text);
                    command.Parameters.AddWithValue("@airportCode", textBox7.Text);
                    command.Parameters.AddWithValue("@adminID", userId); // Set the adminID parameter to the user ID

                    // Execute the query and retrieve the Flight ID
                    object flightId = command.ExecuteScalar();

                    if (flightId != null)
                    {
                        MessageBox.Show("Flight added successfully. Flight ID: " + flightId.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Failed to add flight.");
                    }
                }
            }
        }
    }
}
