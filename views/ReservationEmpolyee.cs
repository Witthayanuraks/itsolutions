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

namespace tugas_it_sofware.views
{
    public partial class ReservationEmpolyee : Form
    {
        private int selectRoom = -1;
        private int totalRoom;
        private int totalItems;
        private int empoly;
        private bool New = true;
        public ReservationEmpolyee(int employee)
        {
            InitializeComponent();
            InitializeDataGridView();
            FillDataCustomer();
            fillType();
            this.empoly = employee;
            radio2.Checked = true;
        }

        private void InitializeDataGridView()
        {
            AddCheckBoxColumn("Pilih");
            AddTextBoxColumn("Nama");
            AddTextBoxColumn("Email");
            AddTextBoxColumn("Gender");
            //
            AddTextBoxColumn1("Item");
            AddTextBoxColumn1("Quantity");
            AddTextBoxColumn1("Price");
            AddTextBoxColumn1("Subtotal");
            AddRemoveButtonColumn("Options");
        }

        private void AddCheckBoxColumn(string headerText)
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = headerText;
            checkBoxColumn.Name = $"{headerText.ToLower()}CheckBoxColumn";
            dataGridView1.Columns.Add(checkBoxColumn);
        }

        private void AddTextBoxColumn(string headerText)
        {
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = headerText;
            textColumn.Name = $"{headerText.ToLower()}TextColumn";
            dataGridView1.Columns.Add(textColumn);
        }

        private void AddTextBoxColumn1(string headerText)
        {
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = headerText;
            textColumn.Name = $"{headerText.ToLower()}TextColumn";
            dataGridView4.Columns.Add(textColumn);
        }
        private void AddRemoveButtonColumn(string headerText)
        {
            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn();
            removeColumn.HeaderText = headerText;
            removeColumn.Text = "Remove";
            removeColumn.UseColumnTextForButtonValue = true;
            dataGridView4.Columns.Add(removeColumn);
        }

        private void FillDataCustomer()
        {
            try
            {
                DataTable dt = new Custommer().getEmployee();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string name = row["name"].ToString();
                        string email = row["email"].ToString();
                        string gender = row["gender"].ToString();

                        dataGridView1.Rows.Add(false, name, email, gender);
                    }
                }
                else
                {
                    MessageBox.Show("Tidak ada data customer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void fillType()
        {
            BoxType.Items.AddRange(new RoomType().GetType().ToArray());
            BoxItems.Items.AddRange(new Items().getAllName().ToArray());
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.BoxType.Text != "") this.dataGridView2.DataSource = new Room().GetAvaliableRoom(this.BoxType.Text);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.selectRoom = e.RowIndex; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView2.SelectedRows[0].Index;
                object[] rowData = dataGridView2.Rows[rowIndex].Cells.Cast<DataGridViewCell>().Select(cell => cell.Value).ToArray();
                if (dataGridView3.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        dataGridView3.Columns.Add(column.Clone() as DataGridViewColumn);
                    }
                }

                dataGridView3.Rows.Add(rowData);
                dataGridView2.Rows.RemoveAt(rowIndex);
                this.setTotalPrice();

                TotalPrice.Text = this.totalRoom.ToString();
            }
            else
            {
                MessageBox.Show("Pilih satu baris untuk dipindahkan.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            this.dataGridView2.DataSource = new Room().GetAvaliableRoom(this.BoxType.Text);
            this.totalRoom = 0;
            TotalPrice.Text = (this.totalRoom + this.totalItems).ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0 && BoxItems.Text != "")
            {
                string price = new Items().getPrice(BoxItems.Text);
                int intPrice = Convert.ToInt32(price) * Convert.ToInt32(numericUpDown1.Value);

                textBox4.Text = price;
                textBox5.Text = intPrice.ToString();

            }
            else
            {
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void BoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.numericUpDown1_ValueChanged(sender, e);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (BoxItems.Text != "" && numericUpDown1.Value != 0)
            {
                dataGridView4.Rows.Add(BoxItems.Text, numericUpDown1.Value.ToString(), textBox4.Text, textBox5.Text);

                this.setTotalPrice();
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                dataGridView4.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void setTotalPrice()
        {
            int totalRoom = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells[0].Value != null) totalRoom += Convert.ToInt32(row.Cells[2].Value); 
            }

            if (textBox2.Text != "") this.totalRoom = totalRoom * Convert.ToInt32(textBox2.Text);
            else
            {
                textBox2.Text = "1";
                this.totalRoom = totalRoom * 1;
            }

            int totalItems = 0;
            foreach(DataGridViewRow row in dataGridView4.Rows)
            {
                if (row.Cells[0].Value != null) totalItems += Convert.ToInt32(row.Cells[3].Value);
            }

            this.totalItems = totalItems;

            TotalPrice.Text = (this.totalItems + this.totalRoom).ToString();
        }

        private string getCostumer()
        {
            string data = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBox = row.Cells[0] as DataGridViewCheckBoxCell;

                if (checkBox != null && Convert.ToBoolean(checkBox.Value) == true)
                {
                    if (row.Cells[1].Value != null) data = row.Cells[1].Value.ToString();
                }
            }
            return data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string data = this.New ? textBox8.Text : getCostumer();
            Reservation reservation = new Reservation();

            if (TotalPrice.Text != "0" && this.totalRoom != null) try
                {
                    if (this.New) new Custommer().Insert(textBox8.Text, textBox7.Text, textBox6.Text, comboBox1.Text == "Male" ? 'M' : 'F', textBox3.Text, this.CalculateAge(dateTimePicker3.Value));
                    reservation.Insert(this.empoly, new Custommer().GetId(data));
                    MessageBox.Show($"Code boking: {reservation.getCode()}");

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            int price = Convert.ToInt32(row.Cells[2].Value) * Convert.ToInt32(textBox2.Text);
                            int room = new Room().GetId(row.Cells[0].Value.ToString());
                            new ReservationRoom().Insert(
                                reservation.GetId(reservation.getCode()),
                                room,
                                dateTimePicker1.Value,
                                Convert.ToInt32(textBox2.Text),
                                price,
                                dateTimePicker2.Value
                                );

                        }
                    }

                    if (this.totalItems != null)
                    {
                        foreach (DataGridViewRow row in dataGridView4.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                new RequestItems().Insert(
                                    reservation.GetId(),
                                    new Items().getId(row.Cells[0].Value.ToString()),
                                    Convert.ToInt32(row.Cells[1].Value),
                                    Convert.ToInt32(row.Cells[3].Value)
                                    );
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[0].Index && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index != e.RowIndex)
                    {
                        DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        checkBoxCell.Value = false;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.ToLower();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && !row.Cells.Cast<DataGridViewCell>().Any(c => c.IsInEditMode)) 
                {
                    bool match = false;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(keyword))
                        {
                            match = true;
                            break;
                        }
                    }

                    row.Visible = match;
                }
            }
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            this.New = false;

            dataGridView1.Visible = true;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;

            textBox3.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            dateTimePicker3.Visible = false;

            label1.Visible = true;
            textBox1 .Visible = true;
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            this.New = true;

            dataGridView1.Visible = false;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;

            textBox3.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            comboBox1.Visible = true;
            dateTimePicker3.Visible = true; 

            label1.Visible = false;
            textBox1.Visible = false;
        }

        private int CalculateAge(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
