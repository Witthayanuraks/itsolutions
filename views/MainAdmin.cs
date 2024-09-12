using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tugas_it_sofware.views
{
    public partial class MainAdmin : Form
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void roomTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RoomTypeAdmin().Show();
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RoomAdmin().Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmployeeAdmin().Show();
        }

        private void foodAndDrinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FoodAndDrinkAdmin().Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ItemsAdmin().Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }
    }
}
