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

        public DbSet<User> User { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MemberAnnouncement> MemberAnnouncements { get; set; }
        public DbSet<MemberCampaign> MemberCampaign { get; set; }
        public DbSet<MemberCampaignShared> MemberCampaignShared { get; set; }
        public DbSet<MemberSetting> MemberSetting { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
