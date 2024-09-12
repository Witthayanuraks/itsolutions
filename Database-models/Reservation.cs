using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_it_sofware.Database_models
{
    internal class Reservation: Database
    {
        private string code;
        public string getCode()
        {
            return this.code;
        }
        private string GenerateRandomBookingCode(int length)
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            return new string(result);
        }

        public void Insert(int employee, int customer)
        {
            this.code = GenerateRandomBookingCode(5);
            this.conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO reservation(date_time, employee_id, customer_id, booking_code) VALUES (@date, @employee, @customer, @code);", this.conn))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Today);
                cmd.Parameters.AddWithValue("@employee", employee);
                cmd.Parameters.AddWithValue("@customer", customer);
                cmd.Parameters.AddWithValue("@code", this.code);
                cmd.ExecuteNonQuery();
            }
            this.conn.Close();
        }

        public int GetId()
        {
            int id = -1;
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM reservation WHERE booking_code = @code;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@code", this.code);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) id = Convert.ToInt32(reader["id"]);
                    }
                }
                this.conn.Close();
            } catch(Exception ex) { }

            return id;
        }

        public int GetId(string bookingCode)
        {
            int id = -1;
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM reservation WHERE booking_code = @code;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@code", bookingCode);
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

        public DataTable findByCode(string bookingCode)
        {
            DataTable dataTable = new DataTable();
            try {
                this.conn.Open();
                using(MySqlCommand cmd = new MySqlCommand("SELECT room.room_number, room.room_floor, room_type.name AS room_type, reservation_room.start_date_time FROM reservation JOIN reservation_room ON reservation.id = reservation_room.reservation_id JOIN room ON reservation_room.room_id = room.id JOIN room_type ON room.room_type_id = room_type.id LEFT JOIN reservation_check_out ON reservation.id = reservation_check_out.reserfation_room_id WHERE reservation.booking_code = @code AND reservation_check_out.id IS NULL;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@code", bookingCode);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    } 
                }
                this.conn.Close();
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
            return dataTable;
        }

        public int FindIdByRoom(string room)
        {
            int id = -1;
            try { 
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT reservation.id FROM reservation JOIN reservation_room ON reservation.id = reservation_room.reservation_id JOIN room ON reservation_room.room_id = room.id WHERE room.room_number = @room;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@room", room);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) id = Convert.ToInt32(reader["id"]);
                    }
                }
                this.conn.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
            return id;
        }
    } 
}
