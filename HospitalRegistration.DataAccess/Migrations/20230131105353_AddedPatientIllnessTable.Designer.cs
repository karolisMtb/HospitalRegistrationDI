﻿// <auto-generated />
using System;
using HospitalRegistration.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalRegistration.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230131105353_AddedPatientIllnessTable")]
    partial class AddedPatientIllnessTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoctorSpecialty", b =>
                {
                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecialtiesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DoctorsId", "SpecialtiesId");

                    b.HasIndex("SpecialtiesId");

                    b.ToTable("DoctorSpecialty");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.DoctorPatient", b =>
                {
                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorPatients");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Illness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Illnesses");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SignedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SignedOut")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.PatientIllness", b =>
                {
                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IlnessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid>("IllnessId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PatientId", "IlnessId");

                    b.HasIndex("IllnessId");

                    b.ToTable("PatientIllnesses");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DoctorSpecialties");
                });

            modelBuilder.Entity("DoctorSpecialty", b =>
                {
                    b.HasOne("HospitalRegistration.DataAccess.Entities.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalRegistration.DataAccess.Entities.Specialty", null)
                        .WithMany()
                        .HasForeignKey("SpecialtiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Doctor", b =>
                {
                    b.HasOne("HospitalRegistration.DataAccess.Entities.Department", null)
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.DoctorPatient", b =>
                {
                    b.HasOne("HospitalRegistration.DataAccess.Entities.Doctor", "Doctor")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalRegistration.DataAccess.Entities.Patient", "Patient")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.PatientIllness", b =>
                {
                    b.HasOne("HospitalRegistration.DataAccess.Entities.Illness", "Illness")
                        .WithMany("PatientIllnesses")
                        .HasForeignKey("IllnessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalRegistration.DataAccess.Entities.Patient", "Patient")
                        .WithMany("PatientIllnesses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Illness");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Department", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Doctor", b =>
                {
                    b.Navigation("DoctorPatients");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Illness", b =>
                {
                    b.Navigation("PatientIllnesses");
                });

            modelBuilder.Entity("HospitalRegistration.DataAccess.Entities.Patient", b =>
                {
                    b.Navigation("DoctorPatients");

                    b.Navigation("PatientIllnesses");
                });
#pragma warning restore 612, 618
        }
    }
}
