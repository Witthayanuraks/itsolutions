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
    public partial class CheckOutEmployee : Form
    {
        public CheckOutEmployee()
        {
            InitializeComponent();
            this.comboBox1.Items.AddRange(new Room().getForCheckOut().ToArray());
            this.comboBox2.Items.AddRange(new Items().getAllName().ToArray());
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Items().getDataUsingRoom(comboBox1.Text);
        }
    }
}
