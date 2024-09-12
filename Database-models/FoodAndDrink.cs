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
    internal class FoodAndDrink : Database
    {
        public DataTable getAll()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT name, CASE WHEN type = 'F' THEN 'Food' ELSE 'Drink' END AS category, price FROM food_and_drinks;", this.conn))
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

        public int getId(string name)
        {
            int data = -1;
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM food_and_drinks WHERE name = @name;", this.conn))
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

        public string getPicture(string name)
        {
            string data = "";
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT photo FROM food_and_drinks WHERE name = @name;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) data = reader["photo"].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }

            return data;
        }

        public void Insert(string name, char type, int price, string photo)
        {
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO food_and_drinks(name, type, price, photo) VALUES (@name, @type, @price, @photo);", this.conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@photo", photo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }
        }

        public void Update(int id, string name, char type, int price, string photo)
        {
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE food_and_drinks SET name = @name, type = @type, price = @price, photo = @photo WHERE id = @id;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@photo", photo);

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
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM food_and_drinks WHERE id = @id;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { this.conn.Close(); }
        }
    }
}
