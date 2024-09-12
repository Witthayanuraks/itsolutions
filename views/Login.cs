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
using tugas_it_sofware.views;

namespace tugas_it_sofware
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (boxUsername.Text != "" && boxPassword.Text != "") try {
                    int id = new Employee().isLogin(boxUsername.Text, boxPassword.Text);
                    if (boxUsername.Text.Equals("Admin") && boxPassword.Text.Equals("Admin"))
                    {
                        new MainAdmin().Show();
                        this.Hide();
                    }
                    else if (id != -1)
                    {
                        MessageBox.Show("berhasil login");
                        new MainOffice(id).Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Username / Password salah");
                } catch(Exception ex) { MessageBox.Show(ex.Message); }
            else MessageBox.Show("username / pasword tidak boleh kosong");
        }
    }
}
