using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form1 : Form
    {
        private const bool V = false;
        private int userId;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True");
            con.Open();
            using (SqlCommand command = new SqlCommand("INSERT INTO [User] (Password, Street, City, Country, Fname, Mname, Lname, Email, DateOfBirth, Age, Phone_Number, Role) VALUES (@Password, @Street, @City, @Country, @Fname, @Mname, @Lname, @Email, @DateOfBirth, DATEDIFF(year, @DateOfBirth, GETDATE()), @Phone_Number, @Role)", con))
            {
                // Set the parameter values for the insert statement
                command.Parameters.AddWithValue("@Password", textBox2.Text);
                command.Parameters.AddWithValue("@Street", textBox3.Text);
                command.Parameters.AddWithValue("@City", textBox4.Text);
                command.Parameters.AddWithValue("@Country", textBox5.Text);
                command.Parameters.AddWithValue("@Fname", textBox8.Text);
                command.Parameters.AddWithValue("@Mname", textBox7.Text);
                command.Parameters.AddWithValue("@Lname", textBox6.Text);
                command.Parameters.AddWithValue("@Email", textBox1.Text);
                command.Parameters.AddWithValue("@DateOfBirth", textBox10.Text);
                command.Parameters.AddWithValue("@Phone_Number", textBox11.Text);
                command.Parameters.AddWithValue("@Role", comboBox1.Text);

                // Execute the insert statement
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Get the user ID of the newly inserted record
                    using (SqlCommand getIdCommand = new SqlCommand("SELECT @@IDENTITY", con))
                    {
                        userId = Convert.ToInt32(getIdCommand.ExecuteScalar());
                    }
                    MessageBox.Show("User created successfully.");

                    // If the user is a customer, insert their ID into the customer table and set the payment method to cash
                    if (comboBox1.Text == "Customer")
                    {
                        using (SqlCommand insertCustomerCommand = new SqlCommand("INSERT INTO Customer (Customer_ID, Payment_info) VALUES (@Customer_ID, @Payment_info)", con))
                        {
                            insertCustomerCommand.Parameters.AddWithValue("@Customer_ID", userId);
                            insertCustomerCommand.Parameters.AddWithValue("@Payment_info", "Cash");

                            int customerRowsAffected = insertCustomerCommand.ExecuteNonQuery();

                            if (customerRowsAffected > 0)
                            {
                                MessageBox.Show("Customer created successfully.");
                            }
                        }
                        this.Hide();
                        Form2 form22 = new Form2();
                        form22.ShowDialog();
                    }
                    else if (comboBox1.Text == "Admin")
                    {
                        using (SqlCommand insertCustomerCommand = new SqlCommand("INSERT INTO Admin (Admin_ID, Permissions) VALUES (@Admin_ID, @Permissions)", con))
                        {
                            insertCustomerCommand.Parameters.AddWithValue("@Admin_ID", userId);
                            insertCustomerCommand.Parameters.AddWithValue("@Permissions", "Full access");

                            int customerRowsAffected = insertCustomerCommand.ExecuteNonQuery();

                            if (customerRowsAffected > 0)
                            {
                                MessageBox.Show("Admin created successfully.");
                            }
                        }
                        this.Hide();
                        Form2 form22 = new Form2();
                        form22.ShowDialog();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
