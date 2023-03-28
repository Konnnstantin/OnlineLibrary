using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class UserRepository
    {
       User User { get; set; }
        public User OnCreateUser()
        {
            using (
            var db = new ContextApp(User))
            {
                var user = new User { Name = "Владимир", Email = "Vl@gmail.com" };
                var user1 = new User { Name = "Дмитрий", Email = "Blog@gmail.com" };
                var user2 = new User { Name = "Роман", Email = "Pol@gmail.com" };

                db.Users.AddRange(user, user1, user2);
                Console.WriteLine("Добавление пользователя");
                db.SaveChanges();

                return user;

                db.Users.RemoveRange();
                db.SaveChanges();
            }
        }

        public void SelectUsersId()
        {
            using (var db = new ContextApp())
            {
                Console.WriteLine("Введите число Id");
                int id = int.Parse(Console.ReadLine());

                switch (id)
                {
                    case 1:
                        var user = db.Users.Where(_ => _.Id == id).FirstOrDefault();
                        Console.WriteLine(user?.Name + " " + user?.Email);

                        Console.WriteLine("Хотите изменить имя");
                        string name = Console.ReadLine();
                        if (name == "Да")
                        {
                            Console.WriteLine("Введите новое Имя");
                            user.Name = Console.ReadLine();
                        }
                        Console.WriteLine(user?.Name + user?.Email);
                        break;
                    case 2:
                        var user1 = db.Users.Where(_ => _.Id == id).FirstOrDefault();
                        Console.WriteLine(user1?.Name + " " + user1?.Email);
                        break;
                    case 3:
                        var user2 = db.Users.Where(_ => _.Id == id).FirstOrDefault();
                        Console.WriteLine(user2?.Name + " " + user2?.Email);
                        break;
                    default:
                        Console.WriteLine("Не правильно введен id");
                        break;
                };
                db.SaveChanges();
            }
        }

    }
}
