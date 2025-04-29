using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bokingbarbershop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=FormDataDB;TrustServerCertificate=True;Integrated Security=True;";
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DataForm (Nama, Tanggal, Pilihan, Status) VALUES (@Nama, @Tanggal, @Pilihan, @Status)", con);
                cmd.Parameters.AddWithValue("@Nama", textBox1.Text);
                cmd.Parameters.AddWithValue("@Tanggal", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Pilihan", textBox2.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox1.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil disimpan!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=FormDataDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE DataForm SET Nama=@Nama, Tanggal=@Tanggal, Pilihan=@Pilihan, Status=@Status WHERE nama=@nama", con);
        
            cmd.Parameters.AddWithValue("@Nama", textBox1.Text);
            cmd.Parameters.AddWithValue("@Tanggal", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Pilihan", textBox2.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully!"); // Lebih baik menggunakan "Updated" untuk operasi update


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=FormDataDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM DataForm WHERE nama=@nama", con);
            cmd.Parameters.AddWithValue("@Nama", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DataForm", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=FormDataDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from DataForm", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); // tambahan agar tidak dobel saat run ulang
            comboBox1.Items.Add("Pelajar");
            comboBox1.Items.Add("Non Pelajar");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
