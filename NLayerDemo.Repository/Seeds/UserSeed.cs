using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerDemo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
            {
                Id = 1,
                Name = "Kardel",
                Email = "ruveydakardelcetin@gmail.com",
                IsAdmin = true,
                Password = "123456",
                Surname = "Çetin",
                Telephone = "5305153061",
                CreatedDate = DateTime.Now
            },
            new User()
            {
                Id = 2,
                Name = "Rüveyda",
                Email = "kardelcetin@gmail.com",
                IsAdmin = true,
                Password = "123456",
                Surname = "Çetin",
                Telephone = "5305153062",
                CreatedDate = DateTime.Now
            }

            );
        }
    }
}
