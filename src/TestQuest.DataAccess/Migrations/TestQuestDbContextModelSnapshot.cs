﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("TestQuest.DataAccess.DbCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("category");

                    b.Property<string>("TestId")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbOption", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("id");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("option");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("options", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbQuestion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("id");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("answer");

                    b.Property<string>("DbTestId")
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("question");

                    b.HasKey("Id");

                    b.HasIndex("DbTestId");

                    b.ToTable("question", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbResultTest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("id");

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("DATE")
                        .HasColumnName("completed_at");

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("INT")
                        .HasColumnName("correct_answers");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("result");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.ToTable("result_test", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbTest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("id");

                    b.Property<byte>("AgeLimit")
                        .HasColumnType("smallint");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("VARCHAR")
                        .HasColumnName("author_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATE")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("difficulty");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("status");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("INT")
                        .HasColumnName("time_limit");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("INT")
                        .HasColumnName("total_questions");

                    b.HasKey("Id");

                    b.ToTable("test", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR")
                        .HasColumnName("id");

                    b.Property<string[]>("Achievements")
                        .IsRequired()
                        .HasColumnType("VARCHAR[]")
                        .HasColumnName("achievements");

                    b.Property<int>("Age")
                        .HasMaxLength(150)
                        .HasColumnType("INT")
                        .HasColumnName("age");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("email");

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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("password");

                    b.Property<int>("RatingPoints")
                        .HasColumnType("INT")
                        .HasColumnName("rating_points");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbCategory", b =>
                {
                    b.HasOne("TestQuest.DataAccess.DbTest", "Test")
                        .WithMany("Category")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("category");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbOption", b =>
                {
                    b.HasOne("TestQuest.DataAccess.DbQuestion", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("options");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbQuestion", b =>
                {
                    b.HasOne("TestQuest.DataAccess.DbTest", null)
                        .WithMany("Questions")
                        .HasForeignKey("DbTestId");
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbQuestion", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("TestQuest.DataAccess.DbTest", b =>
                {
                    b.Navigation("Category");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
