using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_it_sofware.Database_models
{
    internal class Room: Database
    {
        public DataTable getAll()
        {
            this.conn.Open();
            DataTable data = new DataTable();

            using (MySqlCommand cmd = new MySqlCommand("SELECT room.room_number AS `room number`, room_type.name AS `room type`, room.room_floor AS `room floor`, room.description FROM room JOIN room_type ON room.room_type_id = room_type.id;", this.conn))
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                data.Load(dr);
            }
            this.conn.Close();
            return data;
        }

        public DataTable GetAvaliableRoom(string type)
        {
            this.conn.Open();
            DataTable data = new DataTable();

            using (MySqlCommand cmd = new MySqlCommand("SELECT room.room_number,room.room_floor, room_type.room_price, room.description FROM room LEFT JOIN reservation_room ON room.id = reservation_room.room_id LEFT JOIN room_type ON room.room_type_id = room_type.id WHERE reservation_room.id IS NULL AND room_type.name = @type;", this.conn))
            {
                cmd.Parameters.AddWithValue("@type", type);
                MySqlDataReader dr = cmd.ExecuteReader();
                data.Load(dr);
            }
            this.conn.Close();
            return data;
        }

        public List<string> getReservationRoom()
        {
            List<string> list = new List<string>();
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT room.room_number FROM room JOIN reservation_room ON room.id = reservation_room.room_id;", this.conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr["room_number"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return list;
        }

        public int GetId(string number) 
        {
            int id = -1;
            try {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM room WHERE room_number = @number;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@number", number);
                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) id = Convert.ToInt32(dr["id"]);
                    }
                }
                this.conn.Close();
            } catch { }
            return id;
        }

        public String[] findByName(string name)
        {
            this.conn.Open();
            String[] data = new String[5];
            using (MySqlCommand cmd = new MySqlCommand("SELECT room.id, room.room_number, room_type.name AS room_type, room.room_floor, room.description FROM room JOIN room_type ON room.room_type_id = room_type.id WHERE room.room_number = @number;", this.conn))
            {
                cmd.Parameters.AddWithValue("@number", name);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        data[0] = dr["id"].ToString();
                        data[1] = dr["room_number"].ToString();
                        data[2] = dr["room_type"].ToString();
                        data[3] = dr["room_floor"].ToString();
                        data[4] = dr["description"].ToString();
                    }
                }
            }
            this.conn.Close();
            return data;
        }

        public void Insert(string number, string floor, string description, string type)
        {
            this.conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO room (room_type_id, room_number, room_floor, description) SELECT id, @number, @floor, @description FROM room_type WHERE name = @type;", this.conn))
            {
                cmd.Parameters.AddWithValue("@number", number);
                cmd.Parameters.AddWithValue("@floor", floor);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@type", type);

                cmd.ExecuteNonQuery();
            }
            this.conn.Close();
        }

        public void Update(int id, string number, string floor, string description, string type)
        {
            this.conn.Open();
            using (MySqlCommand cmd =  new MySqlCommand("UPDATE room SET room_type_id = (SELECT id FROM room_type WHERE name = @type), room_number = @number, room_floor = @floor, description = @description WHERE id = @id;", this.conn))
            {
                cmd.Parameters.AddWithValue("@number", number);
                cmd.Parameters.AddWithValue("@floor", floor);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            this.conn.Close();
        }

        public void Delete(int id) 
        { 
            this.conn.Open();
            using(MySqlCommand cmd = new MySqlCommand("DELETE FROM room WHERE id = @id;", this.conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            this.conn.Close();
        }

        public List<string> getForCheckOut()
        {
            List<string> list = new List<string>();
            try
            {
                this.conn.Open();
                using(MySqlCommand cmd = new MySqlCommand("SELECT room.room_number FROM room JOIN reservation_room ON room.id = reservation_room.room_id LEFT JOIN reservation_check_out ON reservation_room.id = reservation_check_out.reserfation_room_id LEFT JOIN reservation ON reservation_room.reservation_id = reservation.id WHERE reservation_check_out.id IS NULL;", this.conn))
                {
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(reader["room_number"].ToString());
                    }
                }
                this.conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return list;
        }
    }
}
