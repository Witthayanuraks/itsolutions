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
    public partial class CheckInEmployee : Form
    {
        private bool male = false;
        private bool find = false;
        public CheckInEmployee()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Reservation().findByCode(BokingCode.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

            if (textBox2.Text.Length >= 5)
            {
                String[] data = new Custommer().findForCheckIn(textBox2.Text);
                if (data != null)
                {
                    this.find = true;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;

                    textBox3.Text = data[0];
                    textBox4.Text = data[2];
                    textBox5.Text = data[4];
                    textBox6.Text = data[1];
                }
                else
                {
                    this.find = false;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;

                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.male = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.male = false;
        }
        private void ResetForm()
        {
            this.BokingCode.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.BokingCode.Text) &&
                !string.IsNullOrEmpty(this.textBox2.Text) &&
                !string.IsNullOrEmpty(this.textBox3.Text) &&
                !string.IsNullOrEmpty(this.textBox4.Text) &&
                !string.IsNullOrEmpty(this.textBox5.Text) &&
                !string.IsNullOrEmpty(this.textBox6.Text))
            {
                string numberRoom = dataGridView1.Rows[0].Cells[0].Value.ToString();
                if (this.find) MessageBox.Show($"room nummber :{numberRoom}");
                else
                {
                    new Custommer().Insert(textBox3.Text, textBox6.Text, textBox4.Text, this.male ? 'M':'F', textBox2.Text, Convert.ToInt32(textBox2.Text));
                    this.ResetForm();
                }
            }
            else MessageBox.Show("tolong isi semua data");
        } 
    }
}
