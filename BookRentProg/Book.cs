using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookRentProg
{
    internal class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Type { get; set; }
        public DateTime? Published { get; set; }
        public override string ToString()
        {
            return $"{Author}-{Title}";
        }
    }
}
