
using Assignment3;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Assignment3.EntityFramework
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<User>? Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=assignment3;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.IdentityNumber).HasMaxLength(11).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.CreateDate).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.PasswordHash).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.PasswordSalt).IsRequired();
        }
    }
}
