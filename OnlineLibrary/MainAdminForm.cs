using Hotel;
using OnlineLibrary.Context;
using OnlineLibrary.Entities;
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
    public partial class MainAdminForm : Form
    {
        public MainAdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddingNewBook f = new AddingNewBook();
            f.ShowDialog();
        }

        private void LoadData()
        {
            List<string[]> books = new List<string[]>();

            using (LibraryContext entities = new LibraryContext())
            {
                foreach (Book b in entities.Books)
                {
                    books.Add(new string[6]);
                    books[books.Count - 1][0] = b.Id.ToString();
                    books[books.Count - 1][1] = b.Name;
                    books[books.Count - 1][2] = b.Author;
                    books[books.Count - 1][3] = b.Genre;
                    books[books.Count - 1][4] = b.Size.ToString();
                    books[books.Count - 1][5] = b.Quantity.ToString();
                }

                foreach (string[] s in books)
                {
                    dataGridView1.Rows.Add(s);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string c = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            using (LibraryContext entities = new LibraryContext())
            {
                foreach (Book b in entities.Books)
                {
                    if (b.Id.ToString() == c)
                    {
                        DialogResult dr = MessageBox.Show("Вы действительно хотите удалить эту книгу?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            entities.Books.Remove(b);
                            break;
                        }
                        else return;
                    }
                }
                MessageBox.Show("Книга успешно удалена!!!");
                entities.SaveChanges();
            }
        }

        private void MainAdminForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainAdminForm.ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditingNewBook f = new EditingNewBook();
            f.TextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f.TextBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f.TextBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f.TextBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f.TextBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f.TextBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewUsers f = new ViewUsers();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeOfPassword f = new ChangeOfPassword();
            f.ShowDialog();
        }
    }
}
