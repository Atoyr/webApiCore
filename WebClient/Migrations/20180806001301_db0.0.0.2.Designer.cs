﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebClient.Models.Database;

namespace WebClient.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20180806001301_db0.0.0.2")]
    partial class db0002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("WebClient.Models.Database.ApprovalRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("CompId")
                        .HasColumnName("COMP_ID");

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

                    b.ToTable("APPROVAL_ROUTE");
                });

            modelBuilder.Entity("WebClient.Models.Database.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS");

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

            modelBuilder.Entity("WebClient.Models.Database.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<Guid>("CompId")
                        .HasColumnName("COMP_ID");

                    b.Property<Guid?>("CompanyId");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnName("CREATE_DATETIME");

                    b.Property<string>("CreateUser")
                        .HasColumnName("CREATE_USER");

                    b.Property<string>("DeptCode")
                        .HasColumnName("DEPT_CODE");

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnName("END_DATETIME");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.Property<int>("Order")
                        .HasColumnName("ORDER");

                    b.Property<Guid?>("OrganizationId");

                    b.Property<Guid>("ParentId")
                        .HasColumnName("PARENT_ID");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnName("START_DATETIME");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnName("UPDATE_DATETIME");

                    b.Property<string>("UpdateUser")
                        .HasColumnName("UPDATE_USER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ORGANIZATION");
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

                    b.Property<string>("Hash")
                        .HasColumnName("HASH");

                    b.Property<byte[]>("Icon")
                        .HasColumnName("ICON");

                    b.Property<string>("Mail")
                        .HasColumnName("MAIL");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.Property<byte[]>("Salt")
                        .HasColumnName("SALT");

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

            modelBuilder.Entity("WebClient.Models.Database.Organization", b =>
                {
                    b.HasOne("WebClient.Models.Database.Company")
                        .WithMany("Organizations")
                        .HasForeignKey("CompanyId");

                    b.HasOne("WebClient.Models.Database.Organization")
                        .WithMany("Children")
                        .HasForeignKey("OrganizationId");
                });
#pragma warning restore 612, 618
        }
    }
}
