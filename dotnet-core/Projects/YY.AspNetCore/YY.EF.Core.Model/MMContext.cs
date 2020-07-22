namespace YY.EF.Core.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    public partial class MMContext : DbContext
    {
        public MMContext(DbContextOptions<MMContext> options) : base(options)
        {
            Console.WriteLine("This is MMContext DbContextOptions");
        }
        //public MMContext()
        //{

        //}
        public virtual DbSet<ImageTitle> ImageTitle { get; set; }
        public virtual DbSet<QuanTuWang> QuanTuWang { get; set; }
        public virtual DbSet<Rentiyishu> Rentiyishu { get; set; }
        public virtual DbSet<Xingganmeinv> Xingganmeinv { get; set; }
        public virtual DbSet<Xingganmote> Xingganmote { get; set; }
        public virtual DbSet<Zhenrenxiu> Zhenrenxiu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //不使用依赖注入，自己配置
           // var builder = new ConfigurationBuilder()
           //.SetBasePath(Directory.GetCurrentDirectory())
           //.AddJsonFile("appsettings.json");
           // var configuration = builder.Build();
           // var conn = configuration.GetConnectionString("MMDbConnection");
           // optionsBuilder.UseSqlServer(conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
