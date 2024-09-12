using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace tugas_it_sofware.Database_models
{
    internal class Employee: Database
    {
        public int isLogin(string username, string password)
        {
            int id = -1;
            try
            {
                this.conn.Open();
                using(MySqlCommand cmd = new MySqlCommand("SELECT id FROM employee WHERE username = @username AND password = @password;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) id = Convert.ToInt32(reader["ID"]);
                    }
                }
                this.conn.Close();
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
            return id;
        }

        public DataTable getAll()
        {
            DataTable data = new DataTable();
            this.conn.Open();

            using (MySqlCommand cmd = new MySqlCommand("SELECT e.username, e.name, e.email, e.address, DATE_FORMAT(e.date_of_birth, '%Y-%m-%d') AS birth, j.name AS job\r\nFROM employee e\r\nJOIN job j ON e.job_id = j.id;\r\n", this.conn))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); 
                data.Load(reader);
            }

            this.conn.Close();
            return data;
        }

        public Object[] findByUser(string username)
        {
            Object[] data = new Object[3];

            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT id, photo, password FROM employee WHERE username = @username;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data[0] = Convert.ToInt32(reader["id"]);
                            data[1] = reader["photo"].ToString();
                            data[2] = reader["password"].ToString();

                        }
                    }
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); } finally { this.conn.Close(); }
            return data;
        }

        public void Insert(string username, string password, string name, string email, string job, string address, DateTime date, string image)
        {
            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO employee (username, password, name, email, address, date_of_birth, job_id, photo) VALUES (@username, @password, @name, @email, @address, @day, (SELECT id FROM job WHERE name = @job), @image);", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@job", job);
                    cmd.Parameters.AddWithValue("@day", date);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@image", image);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void Update(int id, string username, string password, string name, string email, string job, string address, DateTime date, string image)
        {
            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("UPDATE employee SET username = @username, password = @password, name = @name, email = @email, address = @address, date_of_birth = @day, job_id = (SELECT id FROM job WHERE name = @job), photo = @image WHERE id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@job", job);
                    cmd.Parameters.AddWithValue("@day", date);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void Delete(int id)
        {
            try {
                this.conn.Open();
                using(MySqlCommand cmd = new MySqlCommand("DELETE FROM employee WHERE id = @id;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            } catch(Exception ex) { MessageBox.Show(ex.Message); } finally { this.conn.Close(); }
        }
    }

}
