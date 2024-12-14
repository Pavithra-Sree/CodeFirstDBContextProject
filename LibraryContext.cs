using CodeFirstDBContextProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDBContextProject
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure book table
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(u => u.ToTable("BookAuthor"));

            // Configure Author table
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Author>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Configure Publisher table
            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            modelBuilder.Entity<Publisher>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Publisher>()
                .Property(a => a.Name)
                .HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LibraryConnection"));
        }
    }
}
