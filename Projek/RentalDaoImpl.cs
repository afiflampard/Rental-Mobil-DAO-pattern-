using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projek
{
    class RentalDaoImpl : rentalDao
    {
        private MySqlConnection conn;
        public RentalDaoImpl(MySqlConnection conn)
        {
            this.conn = conn;
        }
        public void Add(Rental rental)
        {
            MySqlCommand cmd = new MySqlCommand("insert into rental values(NULL,@nama,@alamat,@no_telp,@jumlah_mobil)",conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@nama", rental.name);
            cmd.Parameters.AddWithValue("@alamat", rental.alamat);
            cmd.Parameters.AddWithValue("@no_telp", rental.no_telp);
            cmd.Parameters.AddWithValue("@jumlah_mobil", rental.Jumlah_Mobil);
            cmd.ExecuteNonQuery();
            rental.id = cmd.LastInsertedId;
            conn.Close();
        }

        public int delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from rental where id_rental = @id", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id",id);
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            return count;
        }

        public List<Rental> GetAll()
        {
            string query = "select nama,alamat,no_telp,jumlah_mobil from rental";
            MySqlDataReader reader;
            List<Rental> rental = new List<Rental>();

            try
            {
                conn.Open();
                MySqlCommand myCommand = new MySqlCommand(query, conn);
                reader = myCommand.ExecuteReader();

                while(reader.Read()){
                    Rental newRental = new Rental();
                    newRental.name = (string)reader[0];
                    newRental.alamat = (string)reader[1];
                    newRental.no_telp = (string)reader[2];
                    newRental.Jumlah_Mobil = (int)reader[3];
                    rental.Add(newRental);
                }
                reader.Close();
                conn.Close();
            }catch(Exception ex)
            {
                
            }
            return rental;
        }

        public int update(Rental rental)
        {
            int count = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("update rental set nama=@name,alamat=@alamat,no_telp=@no_telp,jumlah_mobil=@Jumlah_Mobil where id_rental=@id_rental", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id_rental", rental.id);
                cmd.Parameters.AddWithValue("@name", rental.name);
                cmd.Parameters.AddWithValue("@alamat", rental.alamat);
                cmd.Parameters.AddWithValue("@no_telp", rental.no_telp);
                cmd.Parameters.AddWithValue("@jumlah_mobil", rental.Jumlah_Mobil);
                count = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySqlException ex)
            {

            }
            return count;
        }
    }
}
