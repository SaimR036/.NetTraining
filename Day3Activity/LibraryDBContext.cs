using Microsoft.EntityFrameworkCore;
using T2.Models;

namespace Day3Activity
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Borrow>()
                .HasKey(b => new { b.sid, b.Bid });  // 👈 Composite key
        }

    }
}
