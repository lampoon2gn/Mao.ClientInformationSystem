using Mao.ClientInformationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mao.ClientInformationSystem.Infrastructure.Data
{
    public class ClientInformationSystemDbContext:DbContext
    {
        public ClientInformationSystemDbContext(DbContextOptions<ClientInformationSystemDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //action delegate takes a method with void return type
            modelBuilder.Entity<Employees>(ConfigureEmployees);
            modelBuilder.Entity<Clients>(ConfigureClients);
            modelBuilder.Entity<Interactions>(ConfigureInteractions);
            

        }

        private void ConfigureEmployees(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.Password).IsRequired(false).HasMaxLength(10);
            builder.Property(e => e.Designation).IsRequired(false).HasMaxLength(50);  
        }

        private void ConfigureClients(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired(false).HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired(false).HasMaxLength(50);
            builder.Property(c => c.Phones).IsRequired(false).HasMaxLength(30);
            builder.Property(c => c.Address).IsRequired(false).HasMaxLength(100);
            builder.Property(c => c.AddedOn).IsRequired(false).HasDefaultValueSql("getdate()");
        }
        private void ConfigureInteractions(EntityTypeBuilder<Interactions> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ClientId).IsRequired(false);
            builder.HasOne(i => i.Clients).WithMany(m => m.Interactions).HasForeignKey(r => r.ClientId);
            builder.Property(i => i.EmpId).IsRequired(false);
            builder.HasOne(i => i.Employees).WithMany(m => m.Interactions).HasForeignKey(r => r.EmpId);
            builder.Property(i => i.IntType).IsRequired(false).HasMaxLength(1);
            builder.Property(i => i.IntDate).IsRequired(false).HasDefaultValueSql("getdate()");
            builder.Property(i => i.Remarks).IsRequired(false).HasMaxLength(500);
        }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Interactions> Interactions { get; set; }

    }
}
