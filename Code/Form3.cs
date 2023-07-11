using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button13.Visible = false;
            button12.Visible = false;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve the email and password entered by the user
            string email = textBox1.Text;
            string password = textBox2.Text;

            // Query the database to see if there is a user with the entered email and password
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT * FROM [User] WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // If a user is found, check their role
                        reader.Read();
                        string role = reader.GetString(reader.GetOrdinal("Role"));

                        if (role == "Customer")
                        {
                            // If the user is a customer, show the buttons
                            MessageBox.Show("Customer Login successful.");

                            button1.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            button5.Visible = true;
                            button13.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Admin Login successful.");

                            button6.Visible = true;
                            button7.Visible = true;
                            button8.Visible = true;
                            button9.Visible = true;
                            button10.Visible = true;
                            button11.Visible = true;
                            button12.Visible = true;
                        }
                    }
                    else
                    {
                        // If the user is not found, display an error message
                        MessageBox.Show("Invalid email or password. Please try again.");
                    }
                }
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form6 form2 = new Form6();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            string email = textBox1.Text;
            Form4 form2 = new Form4(email);
            form2.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            string email = textBox1.Text;
            Form5 form2 = new Form5(email);
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form7 form2 = new Form7();
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            Form8 form2 = new Form8(email);
            form2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            Form12 form2 = new Form12(email);
            form2.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form9 form2 = new Form9();
            form2.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            Form10 form2 = new Form10(email);
            form2.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form11 form2 = new Form11();
            form2.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form13 form2 = new Form13();
            form2.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            Form4 form2 = new Form4(email);
            form2.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form13 form2 = new Form13();
            form2.ShowDialog();
        }
    }
}
