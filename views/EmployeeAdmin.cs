using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using tugas_it_sofware.Database_models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace tugas_it_sofware.views
{
    public partial class EmployeeAdmin : Form
    {
        private string image;
        private string oldImage;
        private int editIndex = -1;
        public EmployeeAdmin()
        {
            InitializeComponent();
            BoxJob.Items.AddRange(new Job().GetJob().ToArray());
            this.fillDataEmployee();
        }

        private void fillDataEmployee()
        {

            DataEmployee.DataSource = new Employee().getAll();
        }

        private void clearInput()
        {
            BoxUsername.Text = null;
            BoxPassword.Text = null;
            BoxConfirm.Text = null;
            BoxName.Text = null;
            BoxEmail.Text = null;
            BoxAddress.Text = null;
            BoxDate.Text = null;
            BoxJob.Text = null;
            BoxPicture.Image = null;
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
                BoxUsername.Text.Equals("") &&
                BoxPassword.Text.Equals("") &&
                BoxConfirm.Text.Equals("") &&
                BoxName.Text.Equals("") &&
                BoxEmail.Text.Equals("") &&
                BoxJob.Text.Equals("") &&
                BoxAddress.Text.Equals("") &&
                this.image != null
                ))
            {
                if (BoxPassword.Text.Equals(BoxConfirm.Text))
                {
                    new Employee().Insert(BoxUsername.Text, BoxPassword.Text, BoxName.Text, BoxEmail.Text, BoxJob.Text, BoxAddress.Text, BoxDate.Value, this.image);

                    this.clearInput();

                    this.fillDataEmployee();
                }
                else MessageBox.Show("password dan confirm password salah");
            }
            else MessageBox.Show("dataharus terisi semua");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (this.editIndex != -1)
            {
                Object[] data = new Employee().findByUser(DataEmployee.Rows[this.editIndex].Cells[0].Value.ToString());

                this.image = (string)data[1];
                this.oldImage = (string)data[1];

                Save.Visible = true;
                Cencel.Visible = true;
                DataEmployee.Enabled = false;

                BoxUsername.Text = DataEmployee.Rows[this.editIndex].Cells[0].Value.ToString();
                BoxPassword.Text = (string)data[2];
                BoxConfirm.Text = (string)data[2];
                BoxName.Text = DataEmployee.Rows[this.editIndex].Cells[1].Value.ToString();
                BoxEmail.Text = DataEmployee.Rows[this.editIndex].Cells[2].Value.ToString();
                BoxAddress.Text = DataEmployee.Rows[this.editIndex].Cells[3].Value.ToString();
                BoxDate.Text = DataEmployee.Rows[this.editIndex].Cells[4].Value.ToString();
                BoxJob.Text = DataEmployee.Rows[this.editIndex].Cells[5].Value.ToString();
                try { BoxPicture.Image = Image.FromFile(this.image); } catch (Exception ex) { MessageBox.Show("tidak di temukan foto"); }
            }
        }

        private void DataEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) this.editIndex = e.RowIndex;
        }

        private void Cencel_Click(object sender, EventArgs e)
        {
            Save.Visible = false;
            Cencel.Visible = false;
            DataEmployee.Enabled = true;

            this.clearInput();

            this.image = null;
            this.editIndex = -1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && this.editIndex != -1)
            {
                int id = (int)new Employee().findByUser(DataEmployee.Rows[this.editIndex].Cells[0].Value.ToString())[0];
                new Employee().Delete(id);
                this.fillDataEmployee();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Object[] data = new Employee().findByUser(DataEmployee.Rows[this.editIndex].Cells[0].Value.ToString());
            if ((BoxUsername.Text != DataEmployee.Rows[this.editIndex].Cells[0].Value.ToString() ||
                BoxPassword.Text != data[2].ToString() ||
                BoxName.Text != DataEmployee.Rows[this.editIndex].Cells[1].Value.ToString() ||
                BoxEmail.Text != DataEmployee.Rows[this.editIndex].Cells[2].Value.ToString() ||
                BoxJob.Text != DataEmployee.Rows[this.editIndex].Cells[5].Value.ToString() ||
                BoxAddress.Text != DataEmployee.Rows[this.editIndex].Cells[3].Value.ToString() ||
                BoxDate.Text != DataEmployee.Rows[this.editIndex].Cells[4].Value.ToString() ||
                this.image != oldImage) && BoxPassword.Text.Equals(BoxConfirm.Text))
            {
                try { new Employee().Update((int) data[0], BoxUsername.Text, BoxPassword.Text, BoxName.Text, BoxEmail.Text, BoxJob.Text, BoxAddress.Text, BoxDate.Value, this.image); } catch(Exception ex) { MessageBox.Show(ex.Message); } finally {
                    Save.Visible = false;
                    Cencel.Visible = false;
                    DataEmployee.Enabled = true;

                    this.clearInput();

                    this.image = null;
                    this.editIndex = -1;
                    this.fillDataEmployee();
                }
            }
            else MessageBox.Show("data tidak ada yang berubah / password tidak sama");
        }
    }
}
