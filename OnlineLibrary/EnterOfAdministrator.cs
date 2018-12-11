using Hotel;
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
    public partial class EnterOfAdministrator : Form
    {
        public EnterOfAdministrator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Equals(Administrator.Username)) && (textBox2.Text.Equals(Administrator.Password)))
            {
                Administrator admin = Administrator.GetObject();
                if (admin != null)
                {
                    MessageBox.Show("Добро пожаловать в систему!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainAdminForm form = new MainAdminForm();
                    form.ShowDialog();
                }

                else MessageBox.Show("Ошибка входа в систему!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!(textBox2.Text.Equals(Administrator.Password)))
            {
                MessageBox.Show("Неверный пароль!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
