﻿// <auto-generated />
using System;
using Ldis_Project_Reliz.Server.LdisDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ldis_Project_Reliz.Server.Migrations
{
    [DbContext(typeof(DbContextApplication))]
    partial class DbContextApplicationModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("ChatMessage", b =>
                {
                    b.Property<long>("ChatsId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MessagesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatsId", "MessagesId");

                    b.HasIndex("MessagesId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("ChatTag", b =>
                {
                    b.Property<long>("ChatsId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TagsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ChatTag");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<long>("ChatsId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Chat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Actual")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoDeletingUser")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("AvatarId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountUsers")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long?>("GenreId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameChat")
                        .HasColumnType("TEXT");

                    b.Property<long?>("VisibleId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("GenreId");

                    b.HasIndex("VisibleId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameGenre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodeImg")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ForwardedFromId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("MessageTypeId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("deletedByReceiver")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("deletedBySender")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("edited")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ForwardedFromId");

                    b.HasIndex("MessageTypeId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.MessageType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeMessage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MessageTypes");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Reaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameReaction")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("TagName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Actual")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("AvatarId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Enail")
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAdress")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsRegidtred")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Phonenumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("RegisteredAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Visible", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeVisible")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Visibles");
                });

            modelBuilder.Entity("MessageReaction", b =>
                {
                    b.Property<long>("MessagesId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ReactionsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MessagesId", "ReactionsId");

                    b.HasIndex("ReactionsId");

                    b.ToTable("MessageReaction");
                });

            modelBuilder.Entity("MessageUser", b =>
                {
                    b.Property<long>("MessagesId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MessagesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("MessageUser");
                });

            modelBuilder.Entity("ChatMessage", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.Message", null)
                        .WithMany()
                        .HasForeignKey("MessagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatTag", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Chat", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Image", "Avatar")
                        .WithMany("Chats")
                        .HasForeignKey("AvatarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.Genre", "Genre")
                        .WithMany("Chats")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.Visible", "Visible")
                        .WithMany("Chats")
                        .HasForeignKey("VisibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avatar");

                    b.Navigation("Genre");

                    b.Navigation("Visible");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Message", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.User", "ForwardedFrom")
                        .WithMany("ForwardedMessages")
                        .HasForeignKey("ForwardedFromId");

                    b.HasOne("Ldis_Team_Project.Models.MessageType", "MessageType")
                        .WithMany("Messages")
                        .HasForeignKey("MessageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForwardedFrom");

                    b.Navigation("MessageType");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.User", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Image", "Avatar")
                        .WithMany("Users")
                        .HasForeignKey("AvatarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("MessageReaction", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Message", null)
                        .WithMany()
                        .HasForeignKey("MessagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.Reaction", null)
                        .WithMany()
                        .HasForeignKey("ReactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MessageUser", b =>
                {
                    b.HasOne("Ldis_Team_Project.Models.Message", null)
                        .WithMany()
                        .HasForeignKey("MessagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ldis_Team_Project.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Genre", b =>
                {
                    b.Navigation("Chats");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Image", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.MessageType", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.User", b =>
                {
                    b.Navigation("ForwardedMessages");
                });

            modelBuilder.Entity("Ldis_Team_Project.Models.Visible", b =>
                {
                    b.Navigation("Chats");
                });
#pragma warning restore 612, 618
        }
    }
}