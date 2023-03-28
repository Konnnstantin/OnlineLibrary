using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary;
using Azure.Core;

namespace OnlineLibrary
{
    public class BookRepository
    {
        Book Book { get; set; }

        public Book OnCreateModel()
        {

            using (var db = new ContextApp(Book))
            {
               
                var books = new Book { Title = "Властелин колец:Братсво кольца", YearRelease = "1955г", Author = "Дж. Р. Р. Толкин", Genre = "Фэнтези", BookId = 1 };
                var books1 = new Book { Title = "99 франков", YearRelease = "2000г", Author = "Фредерик Бегбедер", Genre = "Роман", BookId = 2 };
                var books2 = new Book { Title = "Легенда о Сонной Лощине ", YearRelease = "1820", Author = "Ирвинг Вашингтон", Genre = "Рассказ", BookId = 3 };
                


                db.Books.AddRange(books, books1, books2);
                db.SaveChanges();

                Console.WriteLine("Добавление книги");

                return books;
            }
        }
        public void BookSelect()
        {
            using(var db = new ContextApp())
            {
                Console.WriteLine("Введите жанр который хотите получить");
                string genre = Console.ReadLine();
                db.Books.Where(_ => _.Genre == genre).Select(_=>_.Title);
                foreach (var book in db.Books)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                Console.WriteLine(db.Books.Where(_=>_.Author== author).Count());

                Console.WriteLine("Введите жанр который хотите получить");
                string genre1= Console.ReadLine();
                Console.WriteLine(db.Books.Where(_ => _.Genre == genre1));

              



            }
        }
        //public bool FindBook()
        //{
        //    using(var db = new ContextApp())
        //    {
        //    Console.WriteLine("Введите название книги и автора");
        //        string title = Console.ReadLine();
        //      return  db.Books.Find(_=>_.Title)

        //    }
            
        //}
    }
}
