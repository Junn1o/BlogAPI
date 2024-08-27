﻿// <auto-generated />
using System;
using BlogAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240815065039_InitialDatabaseMigrationv5.2")]
    partial class InitialDatabaseMigrationv52
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogAPI.Model.Domain.category", b =>
                {
                    b.Property<Guid>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.chapter", b =>
                {
                    b.Property<Guid>("chapter_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("chapter_content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chapter_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("volume_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("chapter_id");

                    b.HasIndex("volume_id");

                    b.ToTable("chapter");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.credential", b =>
                {
                    b.Property<Guid>("cred_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("cred_createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("cred_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cred_roleid")
                        .HasColumnType("int");

                    b.Property<string>("cred_userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("cred_id");

                    b.HasIndex("cred_roleid");

                    b.HasIndex("user_id")
                        .IsUnique();

                    b.ToTable("credential");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.post", b =>
                {
                    b.Property<Guid>("post_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("post_createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("post_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("post_hidden")
                        .HasColumnType("bit");

                    b.Property<bool>("post_status")
                        .HasColumnType("bit");

                    b.Property<string>("post_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("post_type")
                        .HasColumnType("bit");

                    b.Property<Guid>("post_user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("post_id");

                    b.HasIndex("post_user_id");

                    b.ToTable("post");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.post_category_temp", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("category_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("post_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("category_id");

                    b.HasIndex("post_id");

                    b.ToTable("post_category_temp");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.role", b =>
                {
                    b.Property<int>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("role_id"));

                    b.Property<string>("role_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.user", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("gender")
                        .HasColumnType("bit");

                    b.Property<string>("user_avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("user_birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.volume", b =>
                {
                    b.Property<Guid>("volume_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("post_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("volume_createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("volume_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("volume_id");

                    b.HasIndex("post_id");

                    b.ToTable("volume");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.chapter", b =>
                {
                    b.HasOne("BlogAPI.Model.Domain.volume", "volume")
                        .WithMany("chapter")
                        .HasForeignKey("volume_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("volume");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.credential", b =>
                {
                    b.HasOne("BlogAPI.Model.Domain.role", "role")
                        .WithMany("credential")
                        .HasForeignKey("cred_roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogAPI.Model.Domain.user", "user")
                        .WithOne("credential")
                        .HasForeignKey("BlogAPI.Model.Domain.credential", "user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.post", b =>
                {
                    b.HasOne("BlogAPI.Model.Domain.user", "user")
                        .WithMany("post")
                        .HasForeignKey("post_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.post_category_temp", b =>
                {
                    b.HasOne("BlogAPI.Model.Domain.category", "category")
                        .WithMany("post_category_temp")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogAPI.Model.Domain.post", "post")
                        .WithMany("post_category_temp")
                        .HasForeignKey("post_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("post");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.volume", b =>
                {
                    b.HasOne("BlogAPI.Model.Domain.post", "post")
                        .WithMany("volume")
                        .HasForeignKey("post_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.category", b =>
                {
                    b.Navigation("post_category_temp");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.post", b =>
                {
                    b.Navigation("post_category_temp");

                    b.Navigation("volume");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.role", b =>
                {
                    b.Navigation("credential");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.user", b =>
                {
                    b.Navigation("credential")
                        .IsRequired();

                    b.Navigation("post");
                });

            modelBuilder.Entity("BlogAPI.Model.Domain.volume", b =>
                {
                    b.Navigation("chapter");
                });
#pragma warning restore 612, 618
        }
    }
}
