﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestQuest.DataAccess;

#nullable disable

namespace TestQuest.DataAccess.Migrations
{
    [DbContext(typeof(TestQuestDbContext))]
    partial class TestQuestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestQuest.DataAccess.DbQuestion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("answer");

                    b.Property<string>("DbTestId")
                        .HasColumnType("text");

                    b.Property<List<string>>("Options")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("options");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("question");

                    b.HasKey("Id");

                    b.HasIndex("DbTestId");

                    b.ToTable("close_question", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbResultTest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("completed_at");

                    b.Property<byte>("CorrectAnswers")
                        .HasMaxLength(255)
                        .HasColumnType("TINYINT")
                        .HasColumnName("correct_answers");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("result");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.ToTable("result_test", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbTest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Category")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("difficulty");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<byte>("TimeLimit")
                        .HasMaxLength(255)
                        .HasColumnType("TINYINT")
                        .HasColumnName("time_limit");

                    b.Property<byte>("TotalQuestions")
                        .HasMaxLength(255)
                        .HasColumnType("TINYINT")
                        .HasColumnName("total_questions");

                    b.HasKey("Id");

                    b.ToTable("test", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int[]>("Achievements")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<byte>("Age")
                        .HasMaxLength(150)
                        .HasColumnType("TINYINT")
                        .HasColumnName("age");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.Property<int>("RatingPoints")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbQuestion", b =>
                {
                    b.HasOne("TestQuest.DataAccess.DbTest", null)
                        .WithMany("Questions")
                        .HasForeignKey("DbTestId");
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbTest", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
