using Otus.PublicSale.Core;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otus.PublicSale.DataAccess.Data
{
    /// <summary>
    /// Promo Code Factory Context
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Auctions
        /// </summary>
        public virtual DbSet<Auction> Auctions { get; set; }

        /// <summary>
        /// Auction Bets
        /// </summary>
        public virtual DbSet<AuctionBet> AuctionBets { get; set; }

        /// <summary>
        /// Auction Files
        /// </summary>
        public virtual DbSet<AuctionFile> AuctionFiles { get; set; }

        /// <summary>
        /// Auction Users
        /// </summary>
        public virtual DbSet<AuctionUser> AuctionUsers { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Favorites> Favorites { get; set; }

        public virtual DbSet<Subscriber> Subscribers { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {     
            //Database.EnsureDeleted(); 
            //Database.EnsureCreated();
        }        

        /// <summary>
        /// On Mode lCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Auction>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PriceStart).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceStep).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SellPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

               entity.Property(e => e.EndDate).HasColumnType("datetime");

            });

            modelBuilder.Entity<AuctionBet>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.AuctionBets)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bets_Auctions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuctionBets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bets_Users");
            });

            modelBuilder.Entity<AuctionFile>(entity =>
            {
                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.AuctionFiles)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuctionsFiles_Auctions");
            });

            modelBuilder.Entity<AuctionUser>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.AuctionUsers)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuctionsUsers_Auctions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuctionUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuctionsUsers_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {                
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                //entity.Property(e => e.Password).IsRequired();

                //entity.Property(e => e.BirthDay).IsRequired();

                //entity.Property(e => e.Phone).HasMaxLength(12);

                //entity.Property(e => e.Address).HasMaxLength(100);

                //entity.HasOne(d => d.Role)
                //    .WithMany(p => p.Users)
                //    .HasForeignKey(d => d.RoleId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Users_Roles");           
            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            // Default DB values
            //modelBuilder.Entity<Role>().HasData(new Role { Id = Constants.AdminRoleId, Name = "Admin" });
            //modelBuilder.Entity<Role>().HasData(new Role { Id = Constants.UserRoleId, Name = "User" });
            //modelBuilder.Entity<User>().HasData(new User { Id = Constants.DefaultAdminUserId, RoleId = Constants.AdminRoleId, FirstName = "BO", LastName = "Admin", Email = "admin@megaproject.com", Password = "1qaz@WSX" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
