using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.Infrastructure.Configurations

{
    public class SeedItemData : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData
            (
                new Item
                {
                     Id=1,
                    Name="Water",
                      Point=4
                },
                new Item
                {
                    Id = 2,
                    Name = "Food",
                    Point = 3
                    
                },
                new Item
                {
                    Id = 3,
                    Name = "Medication",
                    Point = 2
                   
                },
               new Item
               {
                   Id = 4,
                   Name = "Ammunition",
                   Point = 1
               }
               
            );
        }
    }
}
