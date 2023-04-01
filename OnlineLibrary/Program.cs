using Microsoft.EntityFrameworkCore;
using OnlineLibrary.EF;
using OnlineLibrary.Entities;
using OnlineLibrary.Repository;
{

    using (var Db = new ContextApp())
    {
        Db.Database.EnsureDeleted();
        Db.Database.EnsureCreated();

        var users = new User { Name = "Владимир", Email = "Vl@gmail.com" };
        var users1 = new User { Name = "Дмитрий", Email = "Blog@gmail.com" };
        var users2 = new User { Name = "Роман", Email = "Pol@gmail.com" };

        Db.Users.AddRange(users, users1, users2);

        var bookss = new Book { Title = "Властелин колец:Братсво кольца", YearRelease = "1955г", Author = "Дж. Р. Р. Толкин", Genre = "Фэнтези", User = users };
        var bookss1 = new Book { Title = "99 франков", YearRelease = "2000г", Author = "Фредерик Бегбедер", Genre = "Роман", User = users1 };
        var bookss2 = new Book { Title = "Легенда о Сонной Лощине ", YearRelease = "1820", Author = "Ирвинг Вашингтон", Genre = "Рассказ" };

        Db.Books.AddRange(bookss, bookss1, bookss2);

        Console.WriteLine("Создание базы данных");
        Db.SaveChanges();
    }

    UserRepository user = new UserRepository();
    Console.WriteLine(
            "Выберите действие для базы данных:\n" +
            "1 - Добавление нового пользователя\n" +
            "2 - Удаление пользователя\n" +
            "3 - Получение информации пользователя по Id\n" +
            "4 - Обновление имени пользователя по Id\n" +
            "5 - Получение информации обо всех пользователях");
    int a = int.Parse(Console.ReadLine());
    int id;
    switch (a)
    {
        case 1:
            user.Add();
            break;
        case 2:
            Console.WriteLine("Введите Id пользователя,чтобы удалить");
            id = int.Parse(Console.ReadLine());
            user.Delete(id);
            break;
        case 3:
            Console.WriteLine("Введите Id пользователя,чтобы узнать о нем информацию");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine(user.Read(id).Name + " " + user.Read(id).Email);
            break;
        case 4:
            Console.WriteLine("Введите Id пользователя,чтобы обновить имя");
            id = int.Parse(Console.ReadLine());
            user.Update(id);
            break;
        case 5:
            foreach (var item in user.ReadAll())
            {
                Console.WriteLine(item.Name + " " + item.Email);
            }
            break;
        default:
            Console.WriteLine("Не правильно введена команда");
            break;
    }

    BookRepository books = new BookRepository();
    Console.WriteLine(
           "Выберите действие для базы данных:\n" +
           "1 - Добавление нового пользователя\n" +
           "2 - Удаление пользователя\n" +
           "3 - Получение информации пользователя по Id\n" +
           "4 - Обновление имени пользователя по Id\n" +
           "5 - Получение информации обо всех пользователях\n" +
           "6 - Получение списка книг определенного жанра и вышедших между определенными годами\n" +
           "7 - Получение количества книг опрделенного автора в библиотеке\n" +
           "8 - Получать количество книг определенного жанра в библиотеке\n" +
           "9 - Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке\n" +
           "10 - Получать булевый флаг о том, есть ли определенная книга на руках у пользователя\n" +
           "11 = Получать количество книг на руках у пользователя\n" +
           "12 = Получение последней вышедшей книги\n" +
           "13 = Получение списка всех книг, отсортированного в алфавитном порядке по названию\n" +
           "14 = Получение списка всех книг, отсортированного в порядке убывания года их выхода");

    int b = int.Parse(Console.ReadLine());
    int idBook;
    switch (b)
    {
        case 1:
            books.Add();
            break;
        case 2:
            Console.WriteLine("Введите Id пользователя,чтобы удалить");
            idBook = int.Parse(Console.ReadLine());
            books.Delete(idBook);
            break;
        case 3:
            Console.WriteLine("Введите Id пользователя,чтобы узнать о нем информацию");
            idBook = int.Parse(Console.ReadLine());
            Console.WriteLine(books.Read(idBook).Title + " " + books.Read(idBook).YearRelease + " " + books.Read(idBook).Author + " " + books.Read(idBook).Genre);
            break;
        case 4:
            Console.WriteLine("Введите Id пользователя,чтобы обновить имя");
            idBook = int.Parse(Console.ReadLine());
            books.Update(idBook);
            break;
        case 5:
            foreach (var item in books.ReadAll())
            {
                Console.WriteLine(item.Title + " " + item.YearRelease + " " + item.Author + " " + item.Genre);
            }
            break;
        case 6:
            books.BookSelect();
            break;
        case 7:
            books.BookSelectCountAuthor();
            break;
        case 8:
            books.BookSelectCountGenre();
            break;
        case 9:
            books.FindBook();
            break;
        case 10:books.FindBookUser();
            break;
        case 11: books.CountBookUser();
            break;
        case 12: books.FindRealeseBook();
            break;
        case 13:
            foreach (var item in books.SortBookTitle())
            {
                Console.WriteLine(item.Title + " " + item.YearRelease + " " + item.Author + " " + item.Genre);
            }
            break;
        case 14:
            foreach (var item in books.SortBookRealese())
            {
                Console.WriteLine(item.Title + " " + item.YearRelease + " " + item.Author + " " + item.Genre);
            }
            break;
        default:
            Console.WriteLine("Не правильно введена команда");
            break;
    }


}
