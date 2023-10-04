﻿// <auto-generated />
using System;
using Ldis_Team_Project.DbContextApplicationFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ldis_Team_Project.Migrations
{
    [DbContext(typeof(DbContextApplication))]
    partial class DbContextApplicationModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ChatMessage", b =>
                {
                    b.Property<int>("ChatIdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MessageIdId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatIdId", "MessageIdId");

                    b.HasIndex("MessageIdId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<int>("ChatIdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserIdId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatIdId", "UserIdId");

                    b.HasIndex("UserIdId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Actual")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChatName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Actual")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateSend")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Actual")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MessageUser", b =>
                {
                    b.Property<int>("MessageIdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserIdId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MessageIdId", "UserIdId");

                    b.HasIndex("UserIdId");

                    b.ToTable("MessageUser");
                });

            modelBuilder.Entity("ChatMessage", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.Message", null)
                        .WithMany()
                        .HasForeignKey("MessageIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MessageUser", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Message", null)
                        .WithMany()
                        .HasForeignKey("MessageIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
