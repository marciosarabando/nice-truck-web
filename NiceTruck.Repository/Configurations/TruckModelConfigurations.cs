using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiceTruck.Domain.Entities;

namespace NiceTruck.Repository.Configurations
{
    public class TruckModelConfigurations : IEntityTypeConfiguration<TruckModel>
    {
        public void Configure(EntityTypeBuilder<TruckModel> builder)
        {
            builder.Property(p => p.Id).HasColumnName("id");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description).HasColumnName("ds_description");
            builder.Property(p => p.Active).HasColumnName("st_active");
            builder.Property(p => p.DateTimeCreated).HasColumnName("dt_created");
            builder.Property(p => p.DateTimeUpdated).HasColumnName("dt_updated");

            builder
                .ToTable("tb_truck_model")
                .HasMany(p => p.Trucks)
                .WithOne(p => p.TruckModel);

            builder.HasData(new[]{
                new TruckModel { Id = 1, Description = "FH", Active = true, DateTimeCreated = DateTime.Now },
                new TruckModel { Id = 2, Description = "FM", Active = true, DateTimeCreated = DateTime.Now },
            });
        }
    }
}