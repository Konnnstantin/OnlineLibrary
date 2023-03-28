using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class ContextApp : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public ContextApp(User user)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public ContextApp()
        {
            Database.EnsureCreated();
        }
        public ContextApp(Book book)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptions)
        {
            contextOptions.UseSqlServer(@"Data Source=WIN-85C9GVH5HUD\SQLEXPRESS01;Database=EF;Trusted_Connection=True; Trust Server Certificate = true;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasMany(x => x.Books).WithOne(_ => _.User).HasForeignKey(_ => _.BookId);
        //}



    }
}
