using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models

{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Books books, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Books.BookId == books.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = books,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }


        public virtual void RemoveItem(Books book)
        {
            Items.RemoveAll(x => x.Books.BookId == book.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        //public double CalculateTotal()
        //{
        //    double sum = Items.Sum(x => x.Quantity * 25);
        //    return sum;
        //}

        public double CalcualteTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Books.Price);

            return sum;
        }

        public int TotalBook()
        {
            int sum = Items.Sum(x => x.Quantity++);

            return sum;
        }

    }



    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }

        public Books Books { get; set; }

        public int Quantity { get; set; }
    }

}
