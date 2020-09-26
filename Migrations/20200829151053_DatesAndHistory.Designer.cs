﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using excalidrawCloud.Data;

namespace excalidrawCloud.Migrations
{
    [DbContext(typeof(ExcalidrawContext))]
    [Migration("20200829151053_DatesAndHistory")]
    partial class DatesAndHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("excalidrawCloud.Models.Excalidraw", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("elements")
                        .HasColumnType("text");

                    b.Property<DateTime>("lastSaved")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<long>("owner")
                        .HasColumnType("bigint");

                    b.Property<string>("state")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Excalidraws");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Excalidraw");
                });

            modelBuilder.Entity("excalidrawCloud.Models.ExcalidrawHistory", b =>
                {
                    b.HasBaseType("excalidrawCloud.Models.Excalidraw");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasDiscriminator().HasValue("ExcalidrawHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
