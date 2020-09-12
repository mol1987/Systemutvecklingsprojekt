using Microsoft.EntityFrameworkCore;
using HelloDarlingMVC.Models;
using System.Linq;

namespace HelloDarlingMVC.Data
{
    public class HelloDarlingContext : DbContext
	{
		public HelloDarlingContext(DbContextOptions options) : base(options) { }
		// here goes all the table of the database
		//public DbSet<*table*> TableName { get; set; }

		public DbSet<User> User { get; set; }

        public DbSet<Appearance> Appearance { get; set; }

        public DbSet<Interests> Interests { get; set; }

        public DbSet<Match> Match { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<Preference> Preference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<User>().HasMany<Messages>(p => p.UserMessages).WithOne(e => e.Sender).HasForeignKey(e => e.SenderId).HasConstraintName("FK_Messages_Sender");
            modelBuilder.Entity<User>().HasMany<Messages>(p => p.UserMessages).WithOne(e => e.Receiver).HasForeignKey(e => e.ReceiverId).HasConstraintName("FK_Messages_Receiver");
            */

            modelBuilder.Entity<User>().HasOne<Interests>(p => p.UserInterests).WithOne(e => e.user);
            modelBuilder.Entity<User>().HasOne<Preference>(p => p.UserPreference).WithOne(e => e.user);
            modelBuilder.Entity<User>().HasOne<Appearance>(p => p.UserAppearance).WithOne(e => e.user);

            modelBuilder.Entity<Match>().HasKey(vf => new { vf.UserMatchingId, vf.UserMatcheeId });

            modelBuilder.Entity<Messages>().HasOne<User>(e => e.Sender).WithOne().HasForeignKey<User>(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Messages>().HasOne<User>(e => e.Receiver).WithOne().HasForeignKey<User>(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
