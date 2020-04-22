using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projek
{
    class MobilDaoImpl : MobilDao
    {
        private MySqlConnection conn;

        public MobilDaoImpl(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public void Add(Mobil mobil, Rental rental)
        {
            MySqlCommand cmd = new MySqlCommand("insert into mobil values(NULL,@merk,@model,@tahun_buat,@no_Pol,@id_rental,@harga,@warna,@status)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@merk", mobil.merk);
            cmd.Parameters.AddWithValue("@model", mobil.model);
            cmd.Parameters.AddWithValue("@tahun_buat", mobil.tahun_buat);
            cmd.Parameters.AddWithValue("@no_Pol", mobil.no_Pol);
            cmd.Parameters.AddWithValue("@id_rental", rental.id);
            cmd.Parameters.AddWithValue("@harga", mobil.harga);
            cmd.Parameters.AddWithValue("@warna", mobil.warna);
            cmd.Parameters.AddWithValue("@status", mobil.status);
            cmd.ExecuteNonQuery();
            mobil.id_mobil = cmd.LastInsertedId;
            conn.Close();
        }

        public int delete(long id_mobil)
        {
            MySqlCommand cmd = new MySqlCommand("delete from mobil where id_rental = @id_mobil", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id_mobil", id_mobil);
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            return count;
        }

        public List<Mobil> GetAll()
        {
            string query = "select m.mobil,m.merk,m.model,m.tahun_buat,m.no_Pol,m.harga,m.warna,m.status,r.nama from mobil m join rental r on m.id = r.id";
            MySqlDataReader reader;
            List<Mobil> mobil = new List<Mobil>();

            try
            {
                conn.Open();
                MySqlCommand myCommand = new MySqlCommand(query, conn);
                reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    Mobil Newmobil = new Mobil();
                    Newmobil.merk = (string)reader[0];
                    Newmobil.model = (string)reader[1];
                    Newmobil.tahun_buat = (DateTime)reader[2];
                    Newmobil.no_Pol = (string)reader[3];
                    Newmobil.harga = (decimal)reader[4];
                    Newmobil.warna = (string)reader[5];
                    Newmobil.status = (Boolean)reader[6];
                    Rental rental = new Rental();
                    Newmobil.nama = rental.name;
                    Newmobil.nama = (string)reader[7];
                    mobil.Add(Newmobil);
                    
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return mobil;
        }

        public int update(Mobil mobil)
        {
            int count = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("update mobil set merk=@merk,model=@model,tahun_buat=@tahun_buat,no_Pol=@no_Pol,harga=@harga,warna=@warna,status=@status where id_mobil=@id_mobil", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@merk", mobil.merk);
                cmd.Parameters.AddWithValue("@model", mobil.model);
                cmd.Parameters.AddWithValue("@tahun_buat", mobil.tahun_buat);
                cmd.Parameters.AddWithValue("@no_Pol", mobil.no_Pol);
                cmd.Parameters.AddWithValue("@harga", mobil.harga);
                cmd.Parameters.AddWithValue("@warna", mobil.warna);
                cmd.Parameters.AddWithValue("@status", mobil.status);
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
