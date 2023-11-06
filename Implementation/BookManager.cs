using AutoMapper;
using BookManagementAPI.DataBase;
using BookManagementAPI.Models;
using BookManagementAPI.Models.DTO;
using System.IO;
using System.Text;
using UglyToad.PdfPig;

namespace BookManagementAPI.Implementation
{
    public class BookManager : BaseManager
    {
        public BookManager(BooksDBContext context, IMapper mapper) 
            : base(context, mapper)
        {

        }

        public BookDTO GetBook(int id)
        {
            Book book = Context.Books.Find(id);
            BookDTO bookDTO = Mapper.Map<BookDTO>(book);

            return bookDTO;
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var allBooks = Context.Books.ToList();
            var map = Mapper.Map<List<Book>, List<BookDTO>>(allBooks);

            return map; 
        }

        public IEnumerable<BookDTO> SearchBooks(SearchBookDTO book)
        {
            var allBooks = Context.SearchBooks(book.Title, book.Author, book.Phrase);
            var map = Mapper.Map<List<Book>, List<BookDTO>>(allBooks);

            return map;
        }

        public void AddBook(AddBookDTO book)
        {
            Book newBook = Mapper.Map<Book>(book);
            StringBuilder builder = new StringBuilder();

            using (PdfDocument document = PdfDocument.Open(book.File.OpenReadStream()))
            {
                for (int i = 1; i <= document.NumberOfPages; i++)
                {
                    var page = document.GetPage(i);
                    builder.AppendLine(string.Join(" ", page.GetWords()));
                }
            }

            newBook.Content = builder.ToString();

            Context.Books.Add(newBook);
            Context.SaveChanges();
        }

        public void UpdateBook(BookDTO book)
        {
            Book oldBook = Context.Books.Find(book.ID);
            
            Mapper.Map(book, oldBook);
            Context.SaveChanges();
        }

        public void DeleteBook(int id) 
        {
            Book book = Context.Books.Find(id);

            Context.Books.Remove(book);
            Context.SaveChanges();
        }
    }
}
