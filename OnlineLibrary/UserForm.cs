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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
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

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(textBox1.Text) <=0 )
            {
                MessageBox.Show("Количество книг должно быть больше 0!!!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Order o = new Order
                {
                    Id_book = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                    Count = Int32.Parse(textBox1.Text)
                };
                LibraryContext libraryContext = new LibraryContext();
                libraryContext.Orders.Add(o);
                libraryContext.SaveChanges();
                MessageBox.Show("Книга упешно добавлена в корзину!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserForm.ActiveForm.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Basket f = new Basket();
            f.ShowDialog();
        }
    }
}
