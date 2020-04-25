using SapoLoyalty.DomainObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SapoLoyalty.EFConfiguration
{
    public class LoyaltyDbContext : DbContext
    {
        public LoyaltyDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        //public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        //public DbSet<Config> Configs { get; set; }
        //public DbSet<LoyaltyRand> LoyaltyRands { get; set; }
        //public DbSet<LoyaltyTrade> LoyaltyTrades { get; set; }
        public DbSet<Entity> GetEntities<Entity>() where Entity:BaseEntity
        {
            return Set<Entity>();  
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoyaltyCard>()
                .ToTable("LoyaltyCard")
                .HasKey(m => m.Id)
                .Property(m => m.ModifiedOn)
                .HasColumnName("ModifiedOn");
           modelBuilder.Entity<LoyaltyCard>()
                .HasRequired(m => m.LoyaltyCardType)
                .WithMany(t => t.LoyaltyCards)
                .HasForeignKey(m => m.LoyaltyCardTypeId);

            modelBuilder.Entity<LoyaltyCardType> ()
                .ToTable("LoyaltyCardType")
                .HasKey(m => m.Id);
            modelBuilder.Entity<Config>()
                .ToTable("Config")
                .HasKey(m => m.Id);

            modelBuilder.Entity<Transaction>()
                .ToTable("Transaction")
                .HasKey(m => m.Id)
                .HasRequired(m=>m.Card)
                .WithMany(t =>t.Transactions)
                .HasForeignKey(m=>m.LoyaltyCardId);
            base.OnModelCreating(modelBuilder);
           
                
        }
    }
}