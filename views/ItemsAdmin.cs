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
    public partial class ItemsAdmin : Form
    {
        private int editIndex = -1;
        public ItemsAdmin()
        {
            InitializeComponent();
            this.fillDataItems();
        }

        private void ItemsAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainAdmin().Show();
            this.Close();
        }
        private void DataItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.editIndex = e.RowIndex;
        }

        private void fillDataItems()
        {
            DataItems.DataSource = new Items().getAll();
        }

        private void clearInput()
        {
            BoxCompensation.Text = null;
            BoxName.Text = null;
            BoxPrice.Text = null;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (!(
                BoxCompensation.Text.Equals("") ||
                BoxPrice.Text.Equals("")) && 
                !BoxName.Text.Equals(""))
            {
                new Items().Insert(BoxName.Text, Convert.ToInt32(BoxPrice.Text), Convert.ToInt32(BoxCompensation.Text));
                this.Cencel_Click(sender, e);
                this.fillDataItems();
            }
            else MessageBox.Show("ada data yang null");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (this.editIndex != -1)
            {
                BoxName.Text = DataItems.Rows[this.editIndex].Cells[0].Value.ToString();
                BoxPrice.Text = DataItems.Rows[this.editIndex].Cells[1].Value.ToString();
                BoxCompensation.Text = DataItems.Rows[this.editIndex].Cells[2].Value.ToString();

                Save.Visible = true;
                Cencel.Visible = true;
                DataItems.Enabled = false;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int id = new Items().getId(DataItems.Rows[this.editIndex].Cells[0].Value.ToString());

            if (BoxName.Text != DataItems.Rows[this.editIndex].Cells[0].Value.ToString() ||
                BoxPrice.Text != DataItems.Rows[this.editIndex].Cells[1].Value.ToString() ||
                BoxCompensation.Text != DataItems.Rows[this.editIndex].Cells[2].Value.ToString())
            {
                new Items().Update(id, BoxName.Text, Convert.ToInt32(BoxPrice.Text), Convert.ToInt32(BoxCompensation.Text));

                this.Cencel_Click(sender, e);
                this.fillDataItems();
            }
        }

        private void Cencel_Click(object sender, EventArgs e)
        {
            this.clearInput();

            Save.Visible = false;
            Cencel.Visible = false;
            DataItems.Enabled = true;
            this.editIndex = -1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && this.editIndex != -1)
            {
                int id = new Items().getId(DataItems.Rows[this.editIndex].Cells[0].Value.ToString());
                new Items().Delete(id);
                this.fillDataItems();
            }
        }
    }
}
