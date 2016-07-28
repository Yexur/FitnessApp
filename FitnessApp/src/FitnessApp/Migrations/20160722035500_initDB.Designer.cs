using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FitnessApp;

namespace FitnessApp.Migrations
{
    [DbContext(typeof(FitnessAppContext))]
    [Migration("20160722035500_initDB")]
    partial class initDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitnessApp.Models.FitnessClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfClass");

                    b.Property<string>("EndTime")
                        .IsRequired();

                    b.Property<int?>("FitnessClassType_Id");

                    b.Property<int?>("Instructors_Id");

                    b.Property<int?>("Locations_Id");

                    b.Property<string>("StartTime")
                        .IsRequired();

                    b.Property<bool>("Status");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClassType_Id");

                    b.HasIndex("Instructors_Id");

                    b.HasIndex("Locations_Id");

                    b.ToTable("FitnessClass");
                });

            modelBuilder.Entity("FitnessApp.Models.FitnessClassType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Status");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.ToTable("FitnessClassType");
                });

            modelBuilder.Entity("FitnessApp.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("FitnessApp.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("FitnessApp.Models.RegistrationRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("FitnessClass_Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("Updated");

                    b.Property<bool>("WaitListed");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClass_Id");

                    b.ToTable("RegistrationRecord");
                });

            modelBuilder.Entity("FitnessApp.Models.FitnessClass", b =>
                {
                    b.HasOne("FitnessApp.Models.FitnessClassType", "FitnessClassType")
                        .WithMany("FitnessClass")
                        .HasForeignKey("FitnessClassType_Id");

                    b.HasOne("FitnessApp.Models.Instructor", "Instructor")
                        .WithMany("FitnessClass")
                        .HasForeignKey("Instructors_Id");

                    b.HasOne("FitnessApp.Models.Location", "Location")
                        .WithMany("FitnessClass")
                        .HasForeignKey("Locations_Id");
                });

            modelBuilder.Entity("FitnessApp.Models.RegistrationRecord", b =>
                {
                    b.HasOne("FitnessApp.Models.FitnessClass", "FitnessClass")
                        .WithMany("RegistrationRecords")
                        .HasForeignKey("FitnessClass_Id");
                });
        }
    }
}
