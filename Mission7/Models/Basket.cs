using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models

{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Books book, int qty, Books price)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty,
                    Price = price
                });
            }
            else
            {
                line.Quantity += qty;
            }

        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);
            return sum;
        }

    }



    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
        public Books Price { get; set; }

    }
}
