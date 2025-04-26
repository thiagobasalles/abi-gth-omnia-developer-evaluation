﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Products");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .HasMaxLength(100);

            builder
                .Property(p => p.Description)
                .HasMaxLength(1000);

            builder
                .Property(p => p.Category)
                .HasMaxLength (100);

            builder
                .Property(p => p.Image)
                .HasMaxLength (300);
        }
    }
}
