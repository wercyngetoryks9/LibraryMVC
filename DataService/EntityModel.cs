namespace DataService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=LibraryEntity")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }
        public virtual DbSet<DictBookGenre> DictBookGenres { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Borrows)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DictBookGenre>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.DictBookGenre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Borrows)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
