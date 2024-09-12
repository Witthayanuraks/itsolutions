using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_it_sofware.Database_models
{
    internal class ReservationRoom: Database
    {
        public void Insert(int resevation, int room, DateTime start, int duration, int price, DateTime checkOut)
        {
            try { 
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO reservation_room(reservation_id, room_id, start_date_time, duration_nights, room_price, check_in_date_time, check_out_date_time) VALUES (@resevation, @room, @start, @duration, @price, @start, @checkOut);", this.conn))
                {
                    cmd.Parameters.AddWithValue("@resevation", resevation);
                    cmd.Parameters.AddWithValue("@room", room);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@checkOut", checkOut);
                    cmd.ExecuteNonQuery();

                }
                this.conn.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public int GetId(int resevation)
        {
            int id = -1;
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM reservation_room WHERE reservation_id = @id;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@id", resevation);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) id = Convert.ToInt32(reader["id"]);
                    }
                }
                this.conn.Close();
            }
            catch (Exception ex) { }

            return id;
        }
    }
}
