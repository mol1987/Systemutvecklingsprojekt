﻿// <auto-generated />
using System;
using HelloDarlingMVC3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelloDarlingMVC3.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200917105223_AddedPropertieToPreferences")]
    partial class AddedPropertieToPreferences
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelloDarlingMVC3.Models.Appearance", b =>
                {
                    b.Property<Guid>("ProfileModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EyeColor")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("HairColor")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Height")
                        .HasColumnType("varchar(32)");

                    b.HasKey("ProfileModelId");

                    b.ToTable("Appearance");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.Conversations", b =>
                {
                    b.Property<Guid>("ConversationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessagesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConversationsId");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.ConversationsMessages", b =>
                {
                    b.Property<Guid>("ConversationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConversationsId", "MessageID");

                    b.HasIndex("MessageID");

                    b.ToTable("ConversationsMessages");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.Interests", b =>
                {
                    b.Property<Guid>("ProfileModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Books")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Cars")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Language")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Movies")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Music")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Sports")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("TVgame")
                        .HasColumnType("varchar(32)");

                    b.HasKey("ProfileModelId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.Match", b =>
                {
                    b.Property<Guid>("Profile1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Profile2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Favorite")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Profile1Id", "Profile2Id");

                    b.HasIndex("Profile2Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.Messages", b =>
                {
                    b.Property<Guid>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConversationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MessageStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProfileModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageID");

                    b.HasIndex("ConversationsId");

                    b.HasIndex("ProfileModelId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.Preference", b =>
                {
                    b.Property<Guid>("ProfileModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferredGender")
                        .HasColumnType("int");

                    b.HasKey("ProfileModelId");

                    b.ToTable("Preference");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.ProfileModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentityNO")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UsersCategory")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProfileModel");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.UserConversation", b =>
                {
                    b.Property<Guid>("ProfileModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConversationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfileModelId", "ConversationsId");

                    b.HasIndex("ConversationsId");

                    b.ToTable("UserConversation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.ConversationsMessages", b =>
                {
                    b.HasOne("HelloDarlingMVC3.Models.Conversations", "Conversations")
                        .WithMany("ConversationsMessages")
                        .HasForeignKey("ConversationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelloDarlingMVC3.Models.Messages", "Messages")
                        .WithMany("ConversationsMessages")
                        .HasForeignKey("MessageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.Match", b =>
                {
                    b.HasOne("HelloDarlingMVC3.Models.ProfileModel", "Profile1")
                        .WithMany()
                        .HasForeignKey("Profile1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HelloDarlingMVC3.Models.ProfileModel", "Profile2")
                        .WithMany("Matches")
                        .HasForeignKey("Profile2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.Messages", b =>
                {
                    b.HasOne("HelloDarlingMVC3.Models.Conversations", null)
                        .WithMany("Messages")
                        .HasForeignKey("ConversationsId");

                    b.HasOne("HelloDarlingMVC3.Models.ProfileModel", null)
                        .WithMany("UserMessages")
                        .HasForeignKey("ProfileModelId");
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.ProfileModel", b =>
                {
                    b.HasOne("HelloDarlingMVC3.Models.Appearance", "UserAppearance")
                        .WithOne("ProfileModel")
                        .HasForeignKey("HelloDarlingMVC3.Models.ProfileModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelloDarlingMVC3.Models.Interests", "UserInterests")
                        .WithOne("ProfileModel")
                        .HasForeignKey("HelloDarlingMVC3.Models.ProfileModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelloDarlingMVC3.Models.Preference", "UserPreference")
                        .WithOne("ProfileModel")
                        .HasForeignKey("HelloDarlingMVC3.Models.ProfileModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HelloDarlingMVC3.Models.UserConversation", b =>
                {
                    b.HasOne("HelloDarlingMVC3.Models.Conversations", "Conversations")
                        .WithMany("UserConversation")
                        .HasForeignKey("ConversationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelloDarlingMVC3.Models.ProfileModel", "ProfileModel")
                        .WithMany("UserConversation")
                        .HasForeignKey("ProfileModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
