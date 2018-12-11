using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineLibrary.Entities;
using OnlineLibrary.Context;

namespace OnlineLibrary
{
    public partial class GuestForm : Form
    {
        public GuestForm()
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

        private void GuestForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration f = new Registration();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuestForm.ActiveForm.Close();
        }
    }
}
