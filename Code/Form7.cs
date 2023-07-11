using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form7 : Form
    {
        public Form7()
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Booking WHERE Booking_ID = @Booking_ID", connection))
                {
                    command.Parameters.AddWithValue("@Booking_ID", int.Parse(textBox1.Text));
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        // If the Booking_ID doesn't exist, display an error message
                        MessageBox.Show("Booking ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // If the Booking_ID exists, update the flight class and display a success message
                        reader.Close();
                        using (SqlCommand updateCommand = new SqlCommand("UPDATE Booking SET FlightClass = @FlightClass WHERE Booking_ID = @Booking_ID", connection))
                        {
                            updateCommand.Parameters.AddWithValue("@FlightClass", comboBox1.Text);
                            updateCommand.Parameters.AddWithValue("@Booking_ID", int.Parse(textBox1.Text));
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Flight class updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }
    }
}
