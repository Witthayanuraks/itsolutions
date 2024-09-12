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
    public partial class FoodAndDrinkAdmin : Form
    {
        private readonly string[] listType = { "Food", "Drink" };
        private string image;
        private string oldImage;
        private int editIndex = -1;
        public FoodAndDrinkAdmin()
        {
            InitializeComponent();
            BoxType.Items.AddRange(listType);
            this.fillDataFD();
        }

        private void fillDataFD()
        {
            DataFD.DataSource = new FoodAndDrink().getAll();
        }

        private char getType()
        {
            return BoxType.Text.Equals(listType[0]) ? 'F' : 'D';
        }
        private void clearInput()
        {
            BoxName.Text = null;
            BoxPicture.Image = null;
            BoxPrince.Text = null;
            BoxType.Text = null;
            this.image = null;
            this.editIndex = -1;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Pilih Gambar";
            openFileDialog.Filter = "File Gambar|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.image = openFileDialog.FileName.ToString();
                BoxPicture.Image = Image.FromFile(this.image);
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (!(
                BoxName.Text == "" ||
                BoxPrince.Text == "" ||
                BoxType.Text == "" ||
                this.image == null))
            {
                new FoodAndDrink().Insert(BoxName.Text, this.getType(),Convert.ToInt32(BoxPrince.Text), this.image);
                this.clearInput();
                this.fillDataFD();
            }
            else MessageBox.Show("Data tidak boleh kosong");
        }

        private void Cencel_Click(object sender, EventArgs e)
        {
            this.clearInput();

            DataFD.Enabled = true;
            Cencel.Visible = false;
            Save.Visible = false;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && this.editIndex != -1)
            {
                int id = new FoodAndDrink().getId(DataFD.Rows[this.editIndex].Cells[0].Value.ToString());

                new FoodAndDrink().Delete(id);
                this.fillDataFD();
            }
        }

        private void DataFD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.editIndex = e.RowIndex;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (this.editIndex != -1)
            {
                BoxName.Text = DataFD.Rows[this.editIndex].Cells[0].Value.ToString();
                BoxType.Text = DataFD.Rows[this.editIndex].Cells[1].Value.ToString();
                BoxPrince.Text = DataFD.Rows[this.editIndex].Cells[2].Value.ToString();

                try
                {
                    string photo = new FoodAndDrink().getPicture(DataFD.Rows[this.editIndex].Cells[0].Value.ToString());
                    this.image = photo;
                    this.oldImage = photo;
                    BoxPicture.Image = Image.FromFile(photo);
                }
                catch (Exception ex) { MessageBox.Show("image tidak ada"); this.image = ""; }

                DataFD.Enabled = false;
                Cencel.Visible = true;
                Save.Visible = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (this.image == "") MessageBox.Show("perbaiki foto");
            else if (BoxName.Text != DataFD.Rows[this.editIndex].Cells[0].Value.ToString() ||
                BoxType.Text != DataFD.Rows[this.editIndex].Cells[1].Value.ToString() ||
                BoxPrince.Text != DataFD.Rows[this.editIndex].Cells[2].Value.ToString() ||
                this.image != this.oldImage)
            {
                FoodAndDrink data = new FoodAndDrink();
                data.Update(data.getId(DataFD.Rows[this.editIndex].Cells[0].Value.ToString()), BoxName.Text, getType(), Convert.ToInt32(BoxPrince.Text), this.image);

                this.clearInput();
                this.fillDataFD();
                DataFD.Enabled = true;
                Cencel.Visible = false;
                Save.Visible = false;
            }
        }

        private void FoodAndDrinkAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainAdmin();
            this.Close();
        }
    }
}
