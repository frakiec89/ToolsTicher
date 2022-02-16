﻿// <auto-generated />
using System;
using BGTI.TechnologyLearningTools.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BGTI.TechnologyLearningTools.Migrations
{
    [DbContext(typeof(MySqlLiteContext))]
    partial class MySqlLiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ExamId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuestionWeight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuestionId");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.QuestionOption", b =>
                {
                    b.Property<int>("QuestionOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuestionOptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionOption");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.UserTest", b =>
                {
                    b.Property<int>("UserTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Count")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserTestId");

                    b.HasIndex("ExamId");

                    b.ToTable("UserTests");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.UserTestQuestion", b =>
                {
                    b.Property<int>("UserTestQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Count")
                        .HasColumnType("REAL");

                    b.Property<string>("Otvet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserTestId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserTestQuestionId");

                    b.HasIndex("UserTestId");

                    b.ToTable("UserTestQuestions");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.Question", b =>
                {
                    b.HasOne("BGTI.TechnologyLearningTools.Model.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.QuestionOption", b =>
                {
                    b.HasOne("BGTI.TechnologyLearningTools.Model.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.UserTest", b =>
                {
                    b.HasOne("BGTI.TechnologyLearningTools.Model.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("BGTI.TechnologyLearningTools.Model.UserTestQuestion", b =>
                {
                    b.HasOne("BGTI.TechnologyLearningTools.Model.UserTest", "UserTest")
                        .WithMany()
                        .HasForeignKey("UserTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTest");
                });
#pragma warning restore 612, 618
        }
    }
}