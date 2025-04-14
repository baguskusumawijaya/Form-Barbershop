namespace member_barbershop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Username atau Password tidak boleh kosong");
            else
            if (textBox1.Text == "admin" && textBox2.Text == "123456")
                MessageBox.show("Anda berhasil login");
            else
                MessageBox.Show("Username atau Password salah");
        }
    }
}
