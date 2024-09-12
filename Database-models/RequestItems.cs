using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_it_sofware.Database_models
{
    internal class RequestItems: Database
    {
        public void Insert(int reservation, int item, int qty, int price)
        {
            try {
                this.conn.Open();
                using(MySqlCommand cmd =  new MySqlCommand("INSERT INTO reservation_request_item(reservation_room_id, item_id, qty, total_price) VALUES (@reservation, @item, @qty, @price);", this.conn))
                {
                    cmd.Parameters.AddWithValue("@reservation", reservation);
                    cmd.Parameters.AddWithValue("@item", item);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
                this.conn.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Update(int reservation, int qty, int price, int item)
        {
            try
            {
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE reservation_request_item SET qty = @qty, total_price = @price WHERE reservation_room_id = @reservation AND item_id= @item;", this.conn))
                {
                    cmd.Parameters.AddWithValue("@reservation", reservation);
                    cmd.Parameters.AddWithValue("@item", item);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
                this.conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Delete(int reservation, int item)
        {
            try { 
                this.conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM reservation_request_item WHERE reservation_room_id = @reservation AND item_id = @items; ", this.conn))
                {
                    cmd.Parameters.AddWithValue("@reservation", reservation);
                    cmd.Parameters.AddWithValue("@items", item);
                    cmd.ExecuteNonQuery();
                }
                this.conn.Close();
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
