using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bokingbarbershop
{
    internal class DataFormOperations
    {
        private string connectionString = @"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=FormDataDB;TrustServerCertificate=True;Integrated Security=True;";

        // INSERT data
        public void InsertData(string nama, DateTime tanggal, string pilihan, string status, string namaKaryawan, string jam)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DataForm (Nama, Tanggal, Pilihan, Status, NamaKaryawan, Jam) VALUES (@Nama, @Tanggal, @Pilihan, @Status, @NamaKaryawan, @Jam)", con);
                cmd.Parameters.AddWithValue("@Nama", nama);
                cmd.Parameters.AddWithValue("@Tanggal", tanggal);
                cmd.Parameters.AddWithValue("@Pilihan", pilihan);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@NamaKaryawan", namaKaryawan);
                cmd.Parameters.AddWithValue("@Jam", jam);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE data
        public void UpdateData(string nama, DateTime tanggal, string pilihan, string status, string namaKaryawan, string jam)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE DataForm SET Tanggal=@Tanggal, Pilihan=@Pilihan, Status=@Status, NamaKaryawan=@NamaKaryawan, Jam=@Jam WHERE Nama=@Nama", con);
                cmd.Parameters.AddWithValue("@Nama", nama);
                cmd.Parameters.AddWithValue("@Tanggal", tanggal);
                cmd.Parameters.AddWithValue("@Pilihan", pilihan);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@NamaKaryawan", namaKaryawan);
                cmd.Parameters.AddWithValue("@Jam", jam);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE data
        public void DeleteData(string nama)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM DataForm WHERE Nama=@Nama", con);
                cmd.Parameters.AddWithValue("@Nama", nama);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // SELECT all data
        public DataTable GetAllData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DataForm", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
