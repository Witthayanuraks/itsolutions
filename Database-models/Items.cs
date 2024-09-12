using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace tugas_it_sofware.Database_models
{
    internal class Items : Database
    {
        public DataTable getAll()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT name, request_prince AS `Request Prince`, conpensation_free AS `Conpensation Free` FROM item;", this.conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }

            return dt;
        }
        public string getPrice(string name)
        {
            int dt = 0;

            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT request_prince FROM item WHERE name = @name;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt = Convert.ToInt32(reader["request_prince"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }

            return dt.ToString();
        }
        public List<string> getAllName()
        {
            List<string> dt = new List<string>();

            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT name FROM item;", this.conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Add(reader["name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }

            return dt;
        }


        public int getId(string name)
        {
            int data = -1;
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM item WHERE name = @name;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) data = Convert.ToInt32(reader["id"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }

            return data;
        }

        public DataTable getItemsByReservation(int reservation)
        {
            DataTable dt = new DataTable();
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT i.name AS item, rri.qty AS 'Quantity', i.request_prince AS 'item price', rri.total_price AS 'sub total' FROM reservation_request_item rri JOIN item i ON rri.item_id = i.id WHERE rri.reservation_room_id = @reservation;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@reservation", reservation);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return dt;
        }

        public void Insert(string name, int prince, int compensation)
        {
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO item(name, request_prince, conpensation_free) VALUES (@name, @prince, @compensation);", this.conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@prince", prince);
                    cmd.Parameters.AddWithValue("@compensation", compensation);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }
        }

        public void Update(int id, string name, int prince, int compensation)
        {
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE item SET name = @name, request_prince = @prince, conpensation_free = @compensation WHERE id = @id;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@prince", prince);
                    cmd.Parameters.AddWithValue("@compensation", compensation);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }
        }

        public void Delete(int id)
        {
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM item WHERE id = @id;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }
        } 

        public DataTable getDataUsingRoom(string room)
        {
            DataTable data = new DataTable();
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT item.name AS item, reservation_request_item.qty AS Quantity, item.conpensation_free AS 'Compensation fee', reservation_request_item.total_price AS 'Sub total' FROM room JOIN reservation_room ON room.id = reservation_room.room_id JOIN reservation ON reservation_room.reservation_id = reservation.id JOIN reservation_request_item ON reservation.id = reservation_request_item.reservation_room_id JOIN item ON reservation_request_item.item_id = item.id WHERE room.room_number = @room;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@room", room);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    data.Load(reader);
                }
                this.conn.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }

            return data;
        }
    }
}
