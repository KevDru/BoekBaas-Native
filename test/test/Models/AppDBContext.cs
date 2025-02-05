using Microsoft.EntityFrameworkCore;

namespace test.models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=boekbaas", ServerVersion.Parse("8.0.30"));
            base.OnConfiguring(optionsBuilder);
        }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.SetNull); 

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)  
                .WithMany(g => g.Books) 
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.SetNull); 
        }
    }
}
