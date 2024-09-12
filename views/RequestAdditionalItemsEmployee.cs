using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tugas_it_sofware.Database_models;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace tugas_it_sofware.views
{
    public partial class RequestAdditionalItemsEmployee : Form
    {
        private bool deleteButton = false;
        public RequestAdditionalItemsEmployee()
        {
            InitializeComponent();
            fillType();
        }

        private void fillType()
        {
            comboBox1.Items.AddRange(new Room().getReservationRoom().ToArray());
            comboBox2.Items.AddRange(new Items().getAllName().ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                int reservation = new Reservation().FindIdByRoom(comboBox1.Text);
                dataGridView1.DataSource = new Items().getItemsByReservation(reservation);
                this.setTotal();

                if (!deleteButton)
                {
                    DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                    btnColumn.Name = "btnDelete";
                    btnColumn.HeaderText = "Option";
                    btnColumn.Text = "Remove";
                    btnColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(btnColumn);
                    deleteButton = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && numericUpDown1.Value != 0)
            {
                int rows = -1;
                bool find = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0] != null && row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(comboBox2.Text.ToString()))
                    {
                        find = true;
                        rows = row.Index;
                        break;
                    }
                }

                if(find)
                {
                    int qty = Convert.ToInt32(dataGridView1.Rows[rows].Cells[1].Value);
                    int subTotal = Convert.ToInt32(dataGridView1.Rows[rows].Cells[3].Value);
                    int itemId = new Items().getId(dataGridView1.Rows[rows].Cells[0].Value.ToString());
                    int reservation = new Reservation().FindIdByRoom(comboBox1.Text);
                    new RequestItems().Update(reservation, qty+ Convert.ToInt32(numericUpDown1.Value), subTotal+ Convert.ToInt32(textBox2.Text), itemId);
                }
                else
                {
                    int reservation = new Reservation().FindIdByRoom(comboBox1.Text);
                    int itemId = new Items().getId(comboBox2.Text);
                    int qty = Convert.ToInt32(numericUpDown1.Value);
                    int price = Convert.ToInt32(textBox2.Text);
                    new RequestItems().Insert(reservation, itemId, qty, price);
                }
                this.comboBox1_SelectedIndexChanged(sender, e);
            }
            this.setTotal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                int price = Convert.ToInt32(new Items().getPrice(comboBox2.Text));
                textBox1.Text = price.ToString();
                textBox2.Text = (price * numericUpDown1.Value).ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.numericUpDown1_ValueChanged(sender, e);
        }

        private void setTotal()
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0] != null && row.Cells[0].Value != null)
                {
                    total += Convert.ToInt32(row.Cells[3].Value);
                }
            }
            totalPrice.Text = total.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && !string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                DialogResult result = MessageBox.Show("Apakah Anda yakin ingin melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int reservation = new Reservation().FindIdByRoom(comboBox1.Text);
                    int itemId = new Items().getId(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    new RequestItems().Delete(reservation, itemId);
                    this.comboBox1_SelectedIndexChanged(sender, e);
                }
            }
        }
    }
}
