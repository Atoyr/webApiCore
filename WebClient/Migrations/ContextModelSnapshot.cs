﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebClient.Models.Database;

namespace WebClient.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebClient.Models.Database.Approval", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("ApplicationDateTime")
                        .HasColumnName("APPLICATION_DATETIME");

                    b.Property<int>("CompId")
                        .HasColumnName("COMP_ID");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("CREATE_DATETIME");

                    b.Property<string>("CreateUser")
                        .HasColumnName("CREATE_USER");

                    b.Property<string>("No")
                        .HasColumnName("NO");

                    b.Property<string>("SlipNo")
                        .HasColumnName("SLIP_NO");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnName("UPDATE_DATETIME");

                    b.Property<string>("UpdateUser")
                        .HasColumnName("UPDATE_USER");

                    b.HasKey("Id");

                    b.ToTable("APPROVAL");
                });

            modelBuilder.Entity("WebClient.Models.Database.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .HasColumnName("CODE");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("CREATE_DATETIME");

                    b.Property<string>("CreateUser")
                        .HasColumnName("CREATE_USER");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnName("UPDATE_DATETIME");

                    b.Property<string>("UpdateUser")
                        .HasColumnName("UPDATE_USER");

                    b.HasKey("Id");

                    b.ToTable("COMPANY");
                });

            modelBuilder.Entity("WebClient.Models.Database.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("CompanyId")
                        .HasColumnName("COMPANY_ID");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("CREATE_DATETIME");

                    b.Property<string>("CreateUser")
                        .HasColumnName("CREATE_USER");

                    b.Property<string>("Position")
                        .HasColumnName("POSITION");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnName("UPDATE_DATETIME");

                    b.Property<string>("UpdateUser")
                        .HasColumnName("UPDATE_USER");

                    b.Property<Guid>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("EMPLOYEE");
                });

            modelBuilder.Entity("WebClient.Models.Database.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .HasColumnName("CODE");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("CREATE_DATETIME");

                    b.Property<string>("CreateUser")
                        .HasColumnName("CREATE_USER");

                    b.Property<byte[]>("Icon")
                        .HasColumnName("ICON");

                    b.Property<string>("Mail")
                        .HasColumnName("MAIL");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .HasColumnName("PASSWORD");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnName("UPDATE_DATETIME");

                    b.Property<string>("UpdateUser")
                        .HasColumnName("UPDATE_USER");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("WebClient.Models.Database.Employee", b =>
                {
                    b.HasOne("WebClient.Models.Database.Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebClient.Models.Database.User")
                        .WithMany("Employees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
