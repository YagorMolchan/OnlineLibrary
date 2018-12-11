using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel;
using OnlineLibrary.Context;


namespace OnlineLibrary
{
    public partial class ViewUsers : Form
    {
        public ViewUsers()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewUsers.ActiveForm.Close();
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            List<string[]> data = new List<string[]>();
            using (LibraryContext entities = new LibraryContext())
            {
                foreach (User u in entities.Users)
                {
                    data.Add(new string[8]);
                    data[data.Count - 1][0] = u.Id.ToString();
                    data[data.Count - 1][1] = u.Lastname.ToString();
                    data[data.Count - 1][2] = u.Firstname.ToString();
                    data[data.Count - 1][3] = u.Phone.ToString();
                    data[data.Count - 1][4] = u.Mail;
                    data[data.Count - 1][5] = u.Passport.ToString();
                    data[data.Count - 1][6] = u.Username.ToString();
                    data[data.Count - 1][7] = u.Password.ToString();
                }
            }

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string c = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            using (LibraryContext entities = new LibraryContext())
            {
                foreach (User u in entities.Users)
                {
                    if (u.Id.ToString() == c)
                    {
                        DialogResult dr = MessageBox.Show("Вы действительно хотите удалить этого пользователя?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            entities.Users.Remove(u);
                            break;
                        }
                        else return;
                    }
                }
                MessageBox.Show("Пользователь успешно удален!!!");
                entities.SaveChanges();
            }
        }
    }
}
