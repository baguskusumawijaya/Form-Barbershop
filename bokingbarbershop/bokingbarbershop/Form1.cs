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
        private DataFormOperations dataOps;
        public Form1()
        {
            InitializeComponent();
            dataOps = new DataFormOperations();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataOps.InsertData(
                    textBox1.Text,
                    dateTimePicker1.Value,
                    textBox2.Text,
                    comboBox1.Text,
                    comboBox2.Text,
                    comboBox3.Text
                );
                MessageBox.Show("Data berhasil ditambahkan!");
                TampilkanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal insert data: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                dataOps.UpdateData(
                    textBox1.Text,
                    dateTimePicker1.Value,
                    textBox2.Text,
                    comboBox1.Text,
                    comboBox2.Text,
                    comboBox3.Text
                );
                MessageBox.Show("Data berhasil diupdate!");
                TampilkanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update data: " + ex.Message);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataOps.DeleteData(textBox1.Text);
                MessageBox.Show("Data berhasil dihapus!");
                TampilkanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus data: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Nama"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Tanggal"].Value);
                textBox2.Text = row.Cells["Pilihan"].Value.ToString();
                comboBox1.Text = row.Cells["Status"].Value.ToString();
                comboBox2.Text = row.Cells["NamaKaryawan"].Value.ToString();
                comboBox3.Text = row.Cells["Jam"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void TampilkanData()
        {
            DataTable dt = dataOps.GetAllData();
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); 
            comboBox1.Items.Add("Pelajar");
            comboBox1.Items.Add("Non Pelajar");

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Bagus");
            comboBox2.Items.Add("Dymas");
            comboBox2.Items.Add("Adit");

            comboBox3.Items.Clear();
            comboBox3.Items.Add("09:00");
            comboBox3.Items.Add("10:00");
            comboBox3.Items.Add("11:00");
            comboBox3.Items.Add("12:00");
            comboBox3.Items.Add("14:00");
            comboBox3.Items.Add("15:00");
            comboBox3.Items.Add("16:00");
            comboBox3.Items.Add("17:00");
            comboBox3.Items.Add("18:00");
            comboBox3.Items.Add("19:00");
            comboBox3.Items.Add("20:00");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
