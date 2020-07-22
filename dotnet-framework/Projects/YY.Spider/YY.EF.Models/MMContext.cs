namespace YY.EF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MMContext : DbContext
    {
        public MMContext()
            : base("name=MMContext")
        {
        }

        public virtual DbSet<Image_001> Image_001 { get; set; }
        public virtual DbSet<ImageTitle> ImageTitle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image_001>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Image_001>()
                .Property(e => e.ImageId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Image_001>()
                .Property(e => e.Url)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ImageTitle>()
                .Property(e => e.ImageTitle1)
                .IsFixedLength();
        }
    }
}
