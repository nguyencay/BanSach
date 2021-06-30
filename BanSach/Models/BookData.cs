using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BanSach.Models
{
    public partial class BookData : DbContext
    {
        public BookData()
            : base("name=BookData")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Image)
                .IsFixedLength();
        }
    }
}
