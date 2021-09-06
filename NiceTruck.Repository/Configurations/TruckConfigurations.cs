using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NiceTruck.Domain.Entities;

namespace NiceTruck.Repository.Configurations
{
    public class TruckConfigurations : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.Property(p => p.Id).HasColumnName("id");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description).HasColumnName("ds_description");
            builder.Property(p => p.IdTruckModel).HasColumnName("id_truck_model");
            builder.Property(p => p.FabricationYear).HasColumnName("cd_fab_year");
            builder.Property(p => p.ModelYear).HasColumnName("cd_model_year");
            builder.Property(p => p.Active).HasColumnName("st_active");
            builder.Property(p => p.DateTimeCreated).HasColumnName("dt_created");
            builder.Property(p => p.DateTimeUpdated).HasColumnName("dt_updated");

            builder
                .ToTable("tb_truck")
                .HasOne(p => p.TruckModel)
                .WithMany(p => p.Trucks)
                .HasForeignKey(p => p.IdTruckModel);
        }
    }
}