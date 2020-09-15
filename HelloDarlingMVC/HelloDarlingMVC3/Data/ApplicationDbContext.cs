using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HelloDarlingMVC3.Models;
using Microsoft.AspNetCore.Identity;

namespace HelloDarlingMVC3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Appearance> Appearance { get; set; }
        public DbSet<Conversations> Conversations { get; set; }
        public DbSet<ConversationsMessages> ConversationsMessages { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Preference> Preference { get; set; }
        public DbSet<ProfileModel> ProfileModel { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<UserConversation> UserConversation { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProfileModel>().HasOne(e => e.UserPreference).WithOne(e => e.ProfileModel).HasForeignKey<ProfileModel>(f => f.Id);
            modelBuilder.Entity<ProfileModel>().HasOne(e => e.UserAppearance).WithOne(e => e.ProfileModel).HasForeignKey<ProfileModel>(f => f.Id);
            modelBuilder.Entity<ProfileModel>().HasOne(e => e.UserInterests).WithOne(e => e.ProfileModel).HasForeignKey<ProfileModel>(f => f.Id);
            //modelBuilder.Entity<ProfileModel>().HasOne(e => e.IdentityUser).WithOne().HasForeignKey<IdentityUser>(f => f.Id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ConversationsMessages>().HasKey(x => new { x.ConversationsId, x.MessageID });
            
            modelBuilder.Entity<ConversationsMessages>()
            .HasOne(xc => xc.Conversations)
            .WithMany(x => x.ConversationsMessages)
            .HasForeignKey(xc => xc.ConversationsId);

            modelBuilder.Entity<ConversationsMessages>()
            .HasOne(xc => xc.Messages)
            .WithMany(x => x.ConversationsMessages)
            .HasForeignKey(xc => xc.MessageID);


            modelBuilder.Entity<UserConversation>().HasKey(x => new { x.ProfileModelId, x.ConversationsId });


            modelBuilder.Entity<UserConversation>()
            .HasOne(xc => xc.ProfileModel)
            .WithMany(x => x.UserConversation)
            .HasForeignKey(xc => xc.ProfileModelId);

            modelBuilder.Entity<UserConversation>()
            .HasOne(xc => xc.Conversations)
            .WithMany(x => x.UserConversation)
            .HasForeignKey(xc => xc.ConversationsId);


            modelBuilder.Entity<Match>().HasKey(x => new { x.Profile1Id, x.Profile2Id });

            modelBuilder.Entity<Match>()
            .HasOne(xc => xc.Profile1)
            .WithMany()
            .HasForeignKey(xc => xc.Profile1Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
            .HasOne(xc => xc.Profile2)
            .WithMany(x => x.Matches)
            .HasForeignKey(xc => xc.Profile2Id);

        }
        #endregion

    }
}
