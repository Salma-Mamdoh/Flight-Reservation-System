using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bookingId;
            if (!int.TryParse(textBox1.Text, out bookingId))
            {
                MessageBox.Show("Please enter a valid Booking ID.", "Error");
                return;
            }

            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();

                // Check if the Booking_ID exists and the Booking_Date is within the last 24 hours
                using (SqlCommand command = new SqlCommand("SELECT Booking_Date FROM Booking WHERE Booking_ID = @Booking_ID", connection))
                {
                    command.Parameters.AddWithValue("@Booking_ID", bookingId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime bookingDate = reader.GetDateTime(0);

                            if (bookingDate >= DateTime.Now.AddHours(-24))
                            {
                                reader.Close(); // Close the reader before executing the delete command

                                // Delete the corresponding row
                                using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM Booking WHERE Booking_ID = @Booking_ID", connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@Booking_ID", bookingId);

                                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Booking with ID " + bookingId.ToString() + " has been canceled.", "Cancellation Confirmation");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error canceling booking.", "Error");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Booking with ID " + bookingId.ToString() + " cannot be canceled because it was made more than 24 hours ago.", "Cancellation Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Booking with ID " + bookingId.ToString() + " does not exist.", "Cancellation Error");
                        }
                    }
                }
            }

        }
    }
}
