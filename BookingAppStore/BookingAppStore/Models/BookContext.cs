using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace BookingAppStore.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set;}
        public DbSet<Purchase> Purchases { get; set;}
    }

    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "War and Peace", Author = "Lev Tolstoy", Price = 220 });
            db.Books.Add(new Book { Name = "Fathers and Children", Author = "I. Turgenev", Price = 180 });
            db.Books.Add(new Book { Name = "Seagull", Author = "A. Chehov", Price = 150 });

            base.Seed(db);
        }
    }
}