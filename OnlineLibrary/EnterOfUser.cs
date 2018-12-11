using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineLibrary.Context;
using Hotel;


namespace OnlineLibrary
{
    public partial class EnterOfUser : Form
    {
        public EnterOfUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (LibraryContext entities = new LibraryContext())
            {
                foreach (User user in entities.Users)
                {
                    if ((textBox1.Text == user.Username) && (textBox2.Text == user.Password))
                    {
                        MessageBox.Show("Аутентификация пройдена!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserForm userForm = new UserForm();
                        userForm.ShowDialog();
                        break;
                    }
                    if ((textBox1.Text == user.Username) && (textBox2.Text != user.Password))
                    {
                        MessageBox.Show("Неверный логин!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    if ((textBox2.Text == user.Password) && (textBox1.Text != user.Username))
                    {
                        MessageBox.Show("Неверный пароль!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
        }
    }
}
