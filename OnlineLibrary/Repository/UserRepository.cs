using OnlineLibrary.EF;
using OnlineLibrary.Entities;
using OnlineLibrary.Interfaces;

namespace OnlineLibrary.Repository
{
    public class UserRepository : IRepository<User>
    {
        ContextApp Db = new ContextApp();
        public void Add()
        {
            using(Db)
            {
                Console.WriteLine("введите имя пользователя и емайл");
                var user = new User { Name = Console.ReadLine(), Email = Console.ReadLine() };  
                Db.Add(user);
                Db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (Db)
            {
                var user = Db.Users.Where(_ => _.Id == id).FirstOrDefault();
                if (user != null)
                {
                    Db.Users.Remove(user);
                    Db.SaveChanges();
                }
            }
        }
        public User Read(int id)
        {
            using (Db)
            {
                var user = Db.Users.Where(_ => _.Id == id).FirstOrDefault();
                return user;
            }
        }

        public IEnumerable<User> ReadAll()
        {
            using (Db)
            {
                return Db.Users.ToList();
            }

        }

        public void Update(int id)
        {
            using (Db)
            {
                var user = Db.Users.Where(_ => _.Id == id).FirstOrDefault();
                if (user != null)
                {
                    Console.WriteLine("Введите новое имя");
                    user.Name = Console.ReadLine();
                }
                Db.SaveChanges();
            }
        }
    }
}
