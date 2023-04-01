using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OnlineLibrary.Entities;


namespace OnlineLibrary.EF
{
    public class ContextApp : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptions)
        {
            contextOptions.UseSqlServer(@"Data Source=WIN-85C9GVH5HUD\SQLEXPRESS01;Database=EF;Trusted_Connection=True; Trust Server Certificate = true;");
        }
    }
}
