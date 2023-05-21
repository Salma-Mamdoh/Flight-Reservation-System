using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Testconnection
{
    public partial class Form13 : Form
    {
        public Form13()
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
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
            int requiredNumOfSeats = int.Parse(textBox1.Text);
            String Date = textBox5.Text;
            string sourceAirport = textBox2.Text;
            string destinationAirport = textBox3.Text;

            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-IFEL030Q;Initial Catalog=FlightReservation;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT f.Flight_ID, f.SourceAirport, f.Destination_Airport, f.FlightCalss_Type, f.NumOfAvaliableSeats, f.TakeOFF_time, f.ArrivaTime, a.Model, a.SeatsCapacity, a.CountryMade FROM Flight AS f INNER JOIN Aircraft AS a ON f.aircraftID = a.Aircraft_ID WHERE f.NumOfAvaliableSeats >= @requiredNumOfSeats AND f.TakeOFF_time = @Date AND f.SourceAirport = @sourceAirport AND f.Destination_Airport = @destinationAirport", con);

                cmd.Parameters.AddWithValue("@requiredNumOfSeats", requiredNumOfSeats);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@sourceAirport", sourceAirport);
                cmd.Parameters.AddWithValue("@destinationAirport", destinationAirport);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while retrieving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

