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
using OnlineLibrary.Entities;

namespace OnlineLibrary
{
    public partial class EditingNewBook : Form
    {
        public EditingNewBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (LibraryContext entities = new LibraryContext())
            {
                foreach (Book b in entities.Books)
                {
                    if (b.Id == Int32.Parse(textBox6.Text))
                    {
                        b.Name = textBox1.Text;
                        b.Author = textBox2.Text;
                        b.Genre = textBox3.Text;
                        b.Size = Int32.Parse(textBox5.Text);
                        b.Quantity = Int32.Parse(textBox4.Text);
                        break;
                    }
                }
                entities.SaveChanges();
                MessageBox.Show("Редактирование данных завершено успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public System.Windows.Forms.TextBox TextBox1 { get { return this.textBox1; } }
        public System.Windows.Forms.TextBox TextBox2 { get { return this.textBox2; } }
        public System.Windows.Forms.TextBox TextBox3 { get { return this.textBox3; } }
        public System.Windows.Forms.TextBox TextBox4 { get { return this.textBox4; } }
        public System.Windows.Forms.TextBox TextBox5 { get { return this.textBox5; } }
        public System.Windows.Forms.TextBox TextBox6 { get { return this.textBox6; } }

        private void EditingNewBook_Load(object sender, EventArgs e)
        {
            textBox6.Enabled = false;
        }
    }
}
