using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestAppilication.Repository.Models;

#nullable disable

namespace TestAppilication.Repository
{
    public partial class WebApiDbContext : DbContext
    {
        public WebApiDbContext()
        {
        }

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBank> TblBanks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBank>(entity =>
            {
                entity.Property(e => e.BankName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
