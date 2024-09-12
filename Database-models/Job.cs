using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_it_sofware.Database_models
{
    internal class Job: Database
    {
        public List<string> GetJob()
        {
            List<string> job = new List<string>();
            this.conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("SELECT name FROM job;", this.conn)) 
            { 
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        job.Add(reader["name"].ToString());
                    }
                }
            }
            this.conn.Close();
            return job;
        }
    }
}
