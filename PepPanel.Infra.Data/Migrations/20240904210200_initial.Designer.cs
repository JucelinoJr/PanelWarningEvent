﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using PepPanel.Infra.Data.Context;

#nullable disable

namespace PepPanel.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240904210200_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PepPanel.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("EV_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("EV_CREATEDATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EV_DESCRIPTION");

                    b.Property<DateTime?>("EventDateTime")
                        .IsRequired()
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("EV_EVENTDATETIME");

                    b.Property<string>("Responsible")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("EV_RESPONSIBLE");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("EV_UPDATEDATE");

                    b.HasKey("Id");

                    b.ToTable("PP_EVENT");
                });

            modelBuilder.Entity("PepPanel.Domain.Entities.Warning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("WR_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("WR_CREATEDATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("WR_DESCRIPTION");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("WR_UPDATEDATE");

                    b.HasKey("Id");

                    b.ToTable("PP_WARNING");
                });
#pragma warning restore 612, 618
        }
    }
}
