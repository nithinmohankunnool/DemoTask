﻿// <auto-generated />
using System;
using DemoTaskProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoTaskProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoTaskProject.Models.SubTaskItem", b =>
                {
                    b.Property<int>("SubTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("SubFinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskItemTaskId")
                        .HasColumnType("int");

                    b.HasKey("SubTaskId");

                    b.HasIndex("TaskItemTaskId");

                    b.ToTable("SubTaskItems");
                });

            modelBuilder.Entity("DemoTaskProject.Models.TaskItem", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("TaskItems");
                });

            modelBuilder.Entity("DemoTaskProject.Models.SubTaskItem", b =>
                {
                    b.HasOne("DemoTaskProject.Models.TaskItem", "TaskItem")
                        .WithMany()
                        .HasForeignKey("TaskItemTaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
