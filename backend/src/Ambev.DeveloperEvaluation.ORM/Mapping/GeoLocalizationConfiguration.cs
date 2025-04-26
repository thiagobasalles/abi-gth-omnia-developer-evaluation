using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class GeoLocalizationConfiguration : IEntityTypeConfiguration<GeoLocation>
    {
        public void Configure(EntityTypeBuilder<GeoLocation> builder)
        {
            builder
                .ToTable("GeoLocalizations");

            builder
                .HasKey(g => g.Id);

            builder
                .HasOne(g => g.Address)
                .WithOne(g => g.Geolocation)
                .HasForeignKey<GeoLocation>(g => g.AddressId);

        }
    }
}
