using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using OnlineLibrary.Entities;
using OnlineLibrary.EF;
using OnlineLibrary.Interfaces;

namespace OnlineLibrary.Repository
{
    public class BookRepository : IRepository<Book>
    { 
        ContextApp Db = new ContextApp();
        public void Add()
        {
            using (Db)
            {
                Console.WriteLine("Введите название книги, год, автора, жанр");
                var book = new Book { Title = Console.ReadLine(), YearRelease = Console.ReadLine(), Author = Console.ReadLine(), Genre = Console.ReadLine() };
                Db.Add(book);
                Db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (Db)
            {
                var book = Db.Books.Where(_ => _.Id == id).FirstOrDefault();
                if (book != null)
                {
                    Db.Books.Remove(book);
                    Db.SaveChanges();
                }
            }
        }
        public Book Read(int id)
        {
            using (Db)
            {
                var book = Db.Books.Where(_ => _.Id == id).FirstOrDefault();
                return book;
            }
        }
        public IEnumerable<Book> ReadAll()
        {
            using (Db)
            {
                return Db.Books.ToList();
            }
        }
        public void Update(int id)
        {
            using (Db)
            {
                var book = Db.Books.Where(_ => _.Id == id).FirstOrDefault();
                if (book != null)
                {
                    Console.WriteLine("Введите новое имя");
                    book.YearRelease = Console.ReadLine();
                }
                Db.SaveChanges();
            }
        }
        public void BookSelect()
        {
            using (Db)
            {
                Console.WriteLine("Введите жанр и год книги, которую хотите получить");
                string genre = Console.ReadLine();
                string year = Console.ReadLine();
                var books = Db.Books.Where(_ => _.Genre == genre).Union(Db.Books.Where(_ => _.YearRelease == year));
                foreach (var book in books)
                {
                    Console.WriteLine(book.Author + " " + book.Genre + " " + book.Title + " " + book.YearRelease);
                }
            }
        }
        public void BookSelectCountAuthor()
        {
            Console.WriteLine("Введите автора книги,чтобы получить количество данного автора");
            string author = Console.ReadLine();
            Console.WriteLine(Db.Books.Where(_ => _.Author == author).Count());
        }
        public void BookSelectCountGenre()
        {
            Console.WriteLine("Введите жанр книги,чтобы получить количество данного жанра");
            string genre = Console.ReadLine();
            Console.WriteLine(Db.Books.Where(_ => _.Genre == genre).Count());
        }
        public void FindBook()
        {
            using (Db)
            {
                Console.WriteLine("Введите название книги и автора, чтобы узнать есть ли данная книга в библиотеке ");
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                Db.Books.Any(_ => _.Author == author);
            }
        }
        public void FindBookUser()
        {
            using (Db)
            {
                Console.WriteLine("Введите  название книги");
                var title = Console.ReadLine();
                var books = Db.Books.Include(_ => _.User).Any(_ => _.Title == title);
                Console.WriteLine(books);
            }
        }

        public void CountBookUser()
        {
            using (Db)
            {
                var books = Db.Books.Include(_ => _.User).Count();
                Console.WriteLine(books);
            }
        }
        public void FindRealeseBook()
        {
            using (Db)
            {
                Console.WriteLine(Db.Books.Max(_ => _.YearRelease));
            }
        }
        public IEnumerable<Book> SortBookTitle()
        {
            using (Db)
            {
                return Db.Books.OrderBy(_ => _.Title).ToList();
            }
        }
        public IEnumerable<Book> SortBookRealese()
        {
            using (Db)
            {
                return Db.Books.OrderByDescending(_ => _.YearRelease).ToList();
            }
        }

    }
}
