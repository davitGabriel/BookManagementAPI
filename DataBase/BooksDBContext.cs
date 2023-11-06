using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.DataBase
{
    public class BooksDBContext : DbContext
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options) 
            : base(options)
        {
         
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public List<Book> SearchBooks(string title = null, string author = null, string phrase = null)
        {
            return Books?.FromSql($"SearchBooksByCriteria {title}, {author}, {phrase}").ToList();
        } 
    }
}
