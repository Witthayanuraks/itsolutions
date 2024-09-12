using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_it_sofware.Database_models
{
    internal class Custommer: Database
    {
        public DataTable getEmployee()
        {
             DataTable data = new DataTable();
            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT name, email, CASE WHEN gender = 'M' THEN 'Male' ELSE 'Female' END AS gender FROM customer;", this.conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    data.Load(reader);
                }

                this.conn.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
            return data;
        }

        public int GetId(string name)
        {
            int id = -1;
            try
            {
                this.conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM customer WHERE name = @name;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) id = Convert.ToInt32(reader["id"]);
                    }
                }

                this.conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return id;
        }

        public String[] findForCheckIn(string number)
        {
            bool find = false;
            String[] list = new String[5];
            try {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer WHERE phone_number LIKE @phoneNumber", this.conn))
                {
                    cmd.Parameters.AddWithValue("@phoneNumber","%"+ number +"%");
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows && reader.Read())
                        {
                            find = true;
                            list[0] = reader["name"].ToString();
                            list[1] = reader["nik"].ToString();
                            list[2] = reader["email"].ToString();
                            list[3] = reader["gender"].ToString();
                            list[4] = reader["age"].ToString();
                        }
                    }
                }
                this.conn.Close();
            } catch(Exception ex) { MessageBox.Show(ex.Message); } 
            if (find) return list;
            return null;
        }

        public void Insert(string name, string nik, string email, char gender, string phone, int age)
        {
            try {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO customer(name, nik, email, gender, phone_number, age) VALUES (@name, @nik, @email, @gender, @phone, @age);", this.conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@nik", nik);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.ExecuteNonQuery();
                }
                this.conn.Close();
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
