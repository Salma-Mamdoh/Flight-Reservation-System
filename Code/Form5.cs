using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form5 : Form
    {
        private int userId;
        private string email;
        public Form5(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

                if (userId != null && userId != -1)
                {
                    // Update the payment method for the current customer
                    using (SqlCommand command = new SqlCommand("UPDATE Customer SET Payment_info = @Payment_info WHERE Customer_ID = @Customer_ID", connection))
                    {
                        command.Parameters.AddWithValue("@Payment_info", comboBox2.Text);
                        command.Parameters.AddWithValue("@Customer_ID", userId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Payment method updated.");
                        }
                        else
                        {
                            Console.WriteLine("Error updating payment method.");
                        }
                    }

                    // Insert a new record into the `Booking` table and retrieve the Booking_ID
                    using (SqlCommand command = new SqlCommand("INSERT INTO Booking(Customer_Name, Booking_Date, NumSeats, Customer_Customer_ID, flightID, Fsource, Destination, FlightClass) VALUES(@Customer_Name, @Booking_Date, @NumSeats, @Customer_Customer_ID, @flightID, @Fsource, @Destination, @FlightClass); SELECT CAST(scope_identity() AS int);", connection))
                    {
                        command.Parameters.AddWithValue("@Customer_Name", textBox1.Text);
                        command.Parameters.AddWithValue("@Booking_Date", DateTime.Now);
                        command.Parameters.AddWithValue("@NumSeats", int.Parse(textBox2.Text));
                        command.Parameters.AddWithValue("@Customer_Customer_ID", userId);
                        command.Parameters.AddWithValue("@flightID", 1);
                        command.Parameters.AddWithValue("@Fsource", textBox3.Text);
                        command.Parameters.AddWithValue("@Destination", textBox4.Text);
                        command.Parameters.AddWithValue("@FlightClass", comboBox1.Text);

                        int bookingId = (int)command.ExecuteScalar();

                        if (bookingId > 0)
                        {
                            MessageBox.Show("Booking successful. Your Booking ID is " + bookingId.ToString(), "Booking Confirmation");
                        }
                        else
                        {
                            Console.WriteLine("Error booking flight.");
                        }
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
