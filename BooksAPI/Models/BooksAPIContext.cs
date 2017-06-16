using System;
using Microsoft.EntityFrameworkCore;
namespace BooksAPI.Models
{
    public class BooksAPIContext : DbContext
    {
        public BooksAPIContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
