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
    public partial class RoomAdmin : Form
    {
        private int editId = -1;
        private string editNumber = "";
        private String[] data;
        public RoomAdmin()
        {
            InitializeComponent();
            fillDataRoom();
            fillComboBox();
        }

        private void fillDataRoom()
        {
            DataRoom.DataSource = new Room().getAll();
        }

        private void fillComboBox()
        {
            BoxType.Items.AddRange(new RoomType().GetType().ToArray());
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (BoxNumber.Text != "" && BoxDescription.Text != "" && BoxFloor.Text != "" && BoxType.Text != "")
            {
                new Room().Insert(BoxNumber.Text, BoxFloor.Text, BoxDescription.Text, BoxType.Text);
                this.fillDataRoom();
                BoxNumber.Text = "";
                BoxDescription.Text = "";
                BoxFloor.Text = "";
                BoxType.Text = "";
            }
            else MessageBox.Show("data tidak lengkap");
        }

        private void DataRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.editNumber = DataRoom.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.editNumber != "")
            {
                try {
                    this.data = new Room().findByName(this.editNumber);

                    this.editId = Convert.ToInt32(this.data[0]);
                    BoxNumber.Text = this.data[1];
                    BoxType.Text = this.data[2]; 
                    BoxFloor.Text = this.data[3];
                    BoxDescription.Text = this.data[4];

                    BtnCencel.Visible = true;
                    BtnSave.Visible = true;
                    DataRoom.Enabled = false;

                } catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnCencel_Click(object sender, EventArgs e)
        {
            this.editId = -1;
            BoxNumber.Text = null;
            BoxType.Text = null;
            BoxFloor.Text = null;
            BoxDescription.Text = null;

            BtnCencel.Visible = false;
            BtnSave.Visible = false;
            DataRoom.Enabled = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (
                this.editId != -1 ||
                BoxNumber.Text != this.data[1] ||
                BoxType.Text != this.data[2] ||
                BoxFloor.Text != this.data[3] ||
                BoxDescription.Text != this.data[4]
              )
            {
                try
                {
                    new Room().Update(this.editId, BoxNumber.Text, BoxFloor.Text, BoxDescription.Text, BoxType.Text);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.editId = -1;
                    BoxNumber.Text = null;
                    BoxType.Text = null;
                    BoxFloor.Text = null;
                    BoxDescription.Text = null;

                    BtnCencel.Visible = false;
                    BtnSave.Visible = false;
                    DataRoom.Enabled = true;
                    this.fillDataRoom();
                }
            }
            else MessageBox.Show("Data masih sama");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && this.editId != -1)
            {
                new Room().Delete(this.editId);
                this.fillDataRoom();
            }
        }
    }
}
