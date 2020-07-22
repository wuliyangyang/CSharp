namespace YY.EF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MMContext : DbContext
    {
        public MMContext()
            : base("name=MMDBContext")
        {
        }

        public virtual DbSet<ImageTitle> ImageTitle { get; set; }
        public virtual DbSet<QuanTuWang> QuanTuWang { get; set; }
        public virtual DbSet<Rentiyishu> Rentiyishu { get; set; }
        public virtual DbSet<Xingganmeinv> Xingganmeinv { get; set; }
        public virtual DbSet<Xingganmote> Xingganmote { get; set; }
        public virtual DbSet<Zhenrenxiu> Zhenrenxiu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageTitle>()
                .Property(e => e.ImageTitle1)
                .IsFixedLength();

            modelBuilder.Entity<ImageTitle>()
                .Property(e => e.ImageGroup)
                .IsFixedLength();

            modelBuilder.Entity<QuanTuWang>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<QuanTuWang>()
                .Property(e => e.Url)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QuanTuWang>()
                .Property(e => e.ImgSrc)
                .IsFixedLength();

            modelBuilder.Entity<QuanTuWang>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<Rentiyishu>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Rentiyishu>()
                .Property(e => e.ImageId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rentiyishu>()
                .Property(e => e.Url)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rentiyishu>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<Xingganmeinv>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Xingganmeinv>()
                .Property(e => e.ImageId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Xingganmeinv>()
                .Property(e => e.Url)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Xingganmeinv>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<Xingganmote>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Xingganmote>()
                .Property(e => e.ImageId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Xingganmote>()
                .Property(e => e.Url)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Xingganmote>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<Zhenrenxiu>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Zhenrenxiu>()
                .Property(e => e.ImageId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Zhenrenxiu>()
                .Property(e => e.Url)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Zhenrenxiu>()
                .Property(e => e.Category)
                .IsFixedLength();
        }
    }
}
