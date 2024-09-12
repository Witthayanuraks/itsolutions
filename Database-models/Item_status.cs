using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_it_sofware.Database_models
{
    internal class Item_status: Database
    {
        public List<string> getAllStatus()
        {
            List<string> status = new List<string>();
            try
            {
                this.conn.Open();
                using(MySqlCommand cmd = new MySqlCommand("SELECT name FROM item_status;", this.conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        status.Add(reader["id"].ToString());
                    }
                }
                this.conn.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
            return status;
        }
    }
}
