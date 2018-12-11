using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ChangeOfPassword : Form
    {
        public ChangeOfPassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeOfPassword.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != Administrator.Password)
            {
                MessageBox.Show("Неверный старый пароль!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox3.Text.Length > 20)
            {
                MessageBox.Show("Пароль должен быть длиной не более 20 символов!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Не подтвержден пароль!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Не соотвествуют пароли!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!textBox3.Text.Equals(""))
            {
                Administrator.Password = textBox3.Text;
                MessageBox.Show("Пароль изменен успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ChangeOfPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
