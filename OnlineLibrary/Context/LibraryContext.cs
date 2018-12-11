using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnlineLibrary.Entities;
using Hotel;

namespace OnlineLibrary.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext():base("LibraryContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
