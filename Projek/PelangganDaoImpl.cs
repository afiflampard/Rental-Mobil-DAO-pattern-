using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projek
{
    class PelangganDaoImpl : PelangganDao
    {
        private MySqlConnection conn;
        public PelangganDaoImpl(MySqlConnection conn)
        {
            this.conn = conn;
        }
        public void addPelanggan(Pelanggan pelanggan)
        {
            MySqlCommand cmd = new MySqlCommand("insert into pelanggan values(NULL,@no_ktp,@nama,@alamat,@no_telp)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@no_ktp", pelanggan.no_ktp);
            cmd.Parameters.AddWithValue("@nama", pelanggan.nama);
            cmd.Parameters.AddWithValue("@alamat", pelanggan.alamat);
            cmd.Parameters.AddWithValue("@no_telp", pelanggan.no_telp);
            cmd.ExecuteNonQuery();
            pelanggan.id_pelanggan = cmd.LastInsertedId;
            conn.Close();
        }

        public int deletePelanggan(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from pelanggan where id_pelanggan = @id", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            return count;
        }

        public List<Pelanggan> GetAllPelanggan()
        {
            string query = "select no_ktp,nama,alamat,no_telp from pelanggan";
            MySqlDataReader reader;
            List<Pelanggan> pelanggan = new List<Pelanggan>();

            try
            {
                conn.Open();
                MySqlCommand myCommand = new MySqlCommand(query, conn);
                reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    Pelanggan newPelanggan = new Pelanggan();
                    newPelanggan.no_ktp = (string)reader[0];
                    newPelanggan.nama = (string)reader[1];
                    newPelanggan.alamat = (string)reader[2];
                    newPelanggan.no_telp = (string)reader[3];
                    pelanggan.Add(newPelanggan);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return pelanggan;
        }

        public int updatePelanggan(Pelanggan pelanggan)
        {
            int count = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("update pelanggan set nama=@nama,alamat=@alamat,no_telp=@no_telp,no_ktp=@no_ktp where id_pelanggan=@id_pelanggan", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id_pelanggan", pelanggan.id_pelanggan);
                cmd.Parameters.AddWithValue("@nama", pelanggan.nama);
                cmd.Parameters.AddWithValue("@alamat", pelanggan.alamat);
                cmd.Parameters.AddWithValue("@no_telp", pelanggan.no_telp);
                count = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {

            }
            return count;
        }
    }
}
