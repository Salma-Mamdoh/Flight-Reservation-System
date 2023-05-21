using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form4 : Form
    {
        private string email;
        public Form4(string email)
        {
            this.email = email;
            InitializeComponent();


            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Email, Password, Street, City, Country, Fname, Mname, Lname, DateOfBirth, Phone_Number FROM [User] WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display the user's information in the appropriate controls
                        // Display the user's information in the appropriate controls
                        textBox1.Text = reader["Email"].ToString();
                        textBox2.Text = reader["Password"].ToString();
                        textBox3.Text = reader["Street"].ToString();
                        textBox4.Text = reader["City"].ToString();
                        textBox5.Text = reader["Country"].ToString();
                        textBox8.Text = reader["Fname"].ToString();
                        textBox7.Text = reader["Mname"].ToString();
                        textBox6.Text = reader["Lname"].ToString();
                        textBox10.Text = reader["DateOfBirth"].ToString();
                        textBox11.Text = reader["Phone_Number"].ToString();


                        textBox1.Enabled = false;
                    }
                }
            }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
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

                string query = "UPDATE [User] SET Password = @Password, Street = @Street, City = @City, Country = @Country, Fname = @Fname, Mname = @Mname, Lname = @Lname, DateOfBirth = @DateOfBirth, Phone_Number = @Phone_Number WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", textBox2.Text);
                    command.Parameters.AddWithValue("@Street", textBox3.Text);
                    command.Parameters.AddWithValue("@City", textBox4.Text);
                    command.Parameters.AddWithValue("@Country", textBox5.Text);
                    command.Parameters.AddWithValue("@Fname", textBox8.Text);
                    command.Parameters.AddWithValue("@Mname", textBox7.Text);
                    command.Parameters.AddWithValue("@Lname", textBox6.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", SqlDbType.Date).Value = Convert.ToDateTime(textBox10.Text);
                    command.Parameters.AddWithValue("@Phone_Number", textBox11.Text);
                    command.Parameters.AddWithValue("@Email", textBox1.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User information updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No user found with that email address.");
                    }
                }
            }
        }
    }
}
