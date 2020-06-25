﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20200622044624_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.ProjectDetail", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectManager")
                        .IsRequired();

                    b.Property<string>("ProjectName")
                        .IsRequired();

                    b.HasKey("ProjectId");

                    b.ToTable("ProjectDetails");
                });

            modelBuilder.Entity("WebAPI.Models.UserDetails", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProjectDetailsProjectId");

                    b.Property<string>("UserAddress");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("ProjectDetailsProjectId");

                    b.ToTable("userDetails");
                });

            modelBuilder.Entity("WebAPI.Models.UserDetails", b =>
                {
                    b.HasOne("WebAPI.Models.ProjectDetail", "ProjectDetails")
                        .WithMany()
                        .HasForeignKey("ProjectDetailsProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
