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
using System.Data.SqlClient;

namespace OnlineLibrary
{
    public partial class Basket : Form
    {
        public Basket()
        {
            InitializeComponent();
        }

        private void Basket_Load(object sender, EventArgs e)
        {
            List<string[]> books = new List<string[]>();

            using (LibraryContext context = new LibraryContext())
            {
                var query = context.Orders.Join(context.Books,
                    o => o.Id_book,
                    b => b.Id,
                    (o, b) =>
                    new
                    {
                        Id = o.Id,
                        Name = b.Name,
                        Author = b.Author,
                        Genre = b.Genre,
                        Size = b.Size,
                        Count = o.Count
                    });

                foreach(var item in query)
                {
                    books.Add(new string[6]);
                    books[books.Count - 1][0] = item.Id.ToString();
                    books[books.Count - 1][1] = item.Name;
                    books[books.Count - 1][2] = item.Author;
                    books[books.Count - 1][3] = item.Genre;
                    books[books.Count - 1][4] = item.Size.ToString();
                    books[books.Count - 1][5] = item.Count.ToString();
                }               

                foreach (string[] s in books)
                {
                    dataGridView1.Rows.Add(s);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-U2ONRPK\\SQLEXPRESS;Initial Catalog=OnlineLibraryDb;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Update Books Set quantity-=@count Where Id in Select Id_book From Orders", sqlConnection);

            using (LibraryContext context = new LibraryContext())
            {

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    command.Parameters.AddWithValue("@count", Int32.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                    command.ExecuteNonQuery();

                }

                foreach (Book book in context.Books)
                {
                    context.Books.Attach(book);
                    context.Entry(book).Property(b => b.Quantity).IsModified = true;
                }

                //    context.SaveChanges();                
                //}
                MessageBox.Show("Заказ успешно оформлен!!!");
            }
        }
    }
}
