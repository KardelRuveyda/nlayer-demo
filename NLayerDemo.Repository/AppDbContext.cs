using Microsoft.EntityFrameworkCore;
using NLayerDemo.Core;
using NLayerDemo.Core.Model.Announcement;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NLayerDemo.Repository
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
