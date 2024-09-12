using MySql.Data.MySqlClient;
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
    public partial class RoomTypeAdmin : Form
    {
        private string image;
        private string editName = "";
        private int getId = -1;
        String[] data;

        public RoomTypeAdmin()
        {
            InitializeComponent();
            fillDataRoomType();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Pilih Gambar";
            openFileDialog.Filter = "File Gambar|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.image = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(this.image);
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if(NameBox.Text != "" && Convert.ToInt32(PriceBox.Text.ToString()) != 0 && CapacityBox.Value != 0 && this.image != "") 
            {
                try { 
                    new RoomType().Insert(NameBox.Text.ToString(), Convert.ToInt32(PriceBox.Text.ToString()), Convert.ToInt32(CapacityBox.Value) , this.image);
                } catch { }
                this.fillDataRoomType();
            }
        }

        private void fillDataRoomType()
        {
            DataRoomType.DataSource = new RoomType().getAll();
        }

        private void DataRoomType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.editName = DataRoomType.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!(this.editName.Equals("")))
            {
                BtnSave.Visible = true;
                BtnCancel.Visible = true;

                try { 
                    this.data = new RoomType().find(this.editName);

                    this.image = this.data[3];
                    pictureBox.Image = Image.FromFile(this.image);
                    NameBox.Text = this.data[0];
                    CapacityBox.Value = Convert.ToInt32(this.data[1]);
                    PriceBox.Text = this.data[2];
                    getId = (int) Convert.ToInt32(this.data[4]);
                } catch(Exception ex) {
                    MessageBox.Show("Data image tidak di temukan");
                    this.data = new RoomType().find(this.editName);

                    this.image = this.data[3];
                    pictureBox.Image = null;
                    NameBox.Text = this.data[0];
                    CapacityBox.Value = Convert.ToInt32(this.data[1]);
                    PriceBox.Text = this.data[2];
                    getId = (int)Convert.ToInt32(this.data[4]);
                } finally {
                    DataRoomType.Enabled = false;
                    BtnUpdate.Enabled = false;
                }
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            NameBox.Text = null;
            CapacityBox.Value = 0;
            PriceBox.Text = null;
            getId = -1;
            BtnSave.Visible = false;
            BtnCancel.Visible = false;
            BtnUpdate.Enabled = true;
            DataRoomType.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (
                this.image != this.data[3] ||
                this.data[0] != NameBox.Text ||
                CapacityBox.Value != Convert.ToInt32(this.data[1]) ||
                this.data[2] != PriceBox.Text)
            {
                try
                {
                    new RoomType().Update(this.getId, NameBox.Text, Convert.ToInt32(PriceBox.Text), Convert.ToInt32(CapacityBox.Value), this.image);
                    this.fillDataRoomType();
                } catch { }
            } else MessageBox.Show("tidak ada data yang berubah");

            BtnUpdate.Enabled = true;
            DataRoomType.Enabled = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("apakah anda yakin ?","konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (this.editName != null)
            {
                if (res == DialogResult.Yes)
                {
                    new RoomType().Delete(this.editName);
                    this.fillDataRoomType();
                }
            }
            else MessageBox.Show("tidak ada yang di pilih");
        }

        private void RoomTypeAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainAdmin().Show();
            this.Close();
        }
    }
}
