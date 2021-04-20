using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopAccGame.Models.MyData
{
    public partial class MyDatabase : DbContext
    {
        public MyDatabase()
            : base("name=MyDatabase")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<User_> User_ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.User_)
                .WillCascadeOnDelete(false);
        }
    }
}
