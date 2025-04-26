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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder
                .Property(a => a.City)
                .HasMaxLength(100);
            builder
                .Property(a => a.Street)
                .HasMaxLength(200);
            builder
                .Property(a => a.Number)
                .HasMaxLength(7);
            builder
                .Property(a => a.Zipcode)
                .HasMaxLength(50);

            builder
                .HasOne(a => a.User)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(u => u.UserId);
        }
    }
}
