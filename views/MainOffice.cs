﻿using System;
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
    public partial class MainOffice : Form
    {
        int id;
        public MainOffice(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            new ReservationEmpolyee(id).Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            new CheckInEmployee().Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            new RequestAdditionalItemsEmployee().Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            new CheckOutEmployee().Show();
        }
    }
}
