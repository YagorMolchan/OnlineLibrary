using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineLibrary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registration f = new Registration();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnterOfUser f = new EnterOfUser();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EnterOfAdministrator f = new EnterOfAdministrator();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuestForm f = new GuestForm();
            f.ShowDialog();
        }
    }
}
