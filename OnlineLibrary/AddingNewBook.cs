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
    public partial class AddingNewBook : Form
    {
        public AddingNewBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(textBox4.Text) <= 0)
            {
                MessageBox.Show("Значение количества книг должно быть больше 0!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (Int32.Parse(textBox5.Text) <= 0)
                {
                    MessageBox.Show("Значение количества страниц должно быть больше 0!", "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Book book = new Book
                    {
                        Name = textBox1.Text,
                        Author = textBox2.Text,
                        Genre = textBox3.Text,
                        Size = Int32.Parse(textBox5.Text),
                        Quantity = Int32.Parse(textBox4.Text)
                    };

                    LibraryContext h = new LibraryContext();
                    h.Books.Add(book);
                    h.SaveChanges();                   

                    MessageBox.Show("Информация о книге успешно добавлена!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }
        }
    }
}
