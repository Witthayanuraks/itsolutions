using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace tugas_it_sofware.Database_models
{
    internal class RoomType: Database
    {
        public DataTable getAll()
        {
            this.conn.Open();
            DataTable data = new DataTable();

            using (MySqlCommand cmd = new MySqlCommand("SELECT name, capacity, room_price AS price FROM room_type;", this.conn))
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                data.Load(dr);
            }
            this.conn.Close();
            return data;
        }

        public String[] find(string name)
        {
            this.conn.Open();
            String[] data = new String[5];
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM room_type WHERE name = @name;", this.conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        data[0] = dr["name"].ToString();
                        data[1] = dr["capacity"].ToString();
                        data[2] = dr["room_price"].ToString();
                        data[3] = dr["photo"].ToString();
                        data[4] = dr["id"].ToString();
                    }
                }
            }
            this.conn.Close();
            return data;
        }

        public void Insert(string name, int price ,int capacity, string image)
        {
            this.conn.Open();

            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO room_type(name, capacity, room_price, photo) VALUES (@name, @capacity, @price, @photo);", this.conn))
            {
                cmd.Parameters.AddWithValue("@name",name);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@photo", image);

                cmd.ExecuteNonQuery();
            }

            this.conn.Close();
        }

        public void Update(int id, string name, int price, int capacity, string image)
        {
            this.conn.Open();

            using (MySqlCommand cmd = new MySqlCommand("UPDATE room_type SET name = @name, capacity = @capacity, room_price = @price, photo = @photo WHERE id = @id;", this.conn))
            {
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@photo", image);

                cmd.ExecuteNonQuery();
            }

            this.conn.Close();
        }

        public void Delete(string name)
        {
            this.conn.Open();

            using (MySqlCommand cmd=new MySqlCommand("DELETE FROM room_type WHERE name = @name;", this.conn))
            {
                cmd.Parameters.AddWithValue("@name",name);

                cmd.ExecuteNonQuery();
            }
            this.conn.Close();
        }

        public List<string> GetType() {

            List<string> data = new List<string>();

            this.conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("SELECT name FROM room_type;", this.conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(reader["name"].ToString());
                    }
                }
            }
            this.conn.Close();
            return data;
        }
    }
}
