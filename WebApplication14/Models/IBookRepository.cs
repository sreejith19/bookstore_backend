using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int bookId);
        List<Book> GetBooksByCatId(int catId);
        List<Book> GetBooksByName(string name);
        Book GetBooksByIsbn(string isbn);
        List<Book> GetBooksByAuthor(string author);
        int AddBook(Book book);
        int EditBook(Book book);
        int DeleteBook(int bookId);
        bool Enable(int id);
        bool Disable(int id);
    }
}
