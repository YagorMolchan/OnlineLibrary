using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Id_book { get; set; }
        public int Count { get; set; }
    }
}
