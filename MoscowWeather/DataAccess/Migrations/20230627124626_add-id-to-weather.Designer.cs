﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistense;

#nullable disable

namespace Persistense.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230627124626_add-id-to-weather")]
    partial class addidtoweather
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AirPressure")
                        .HasColumnType("integer");

                    b.Property<short>("Cloudiness")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("H")
                        .HasColumnType("integer");

                    b.Property<short>("Humidity")
                        .HasColumnType("smallint");

                    b.Property<double>("T")
                        .HasColumnType("double precision");

                    b.Property<double>("Td")
                        .HasColumnType("double precision");

                    b.Property<int>("VV")
                        .HasColumnType("integer");

                    b.Property<string>("WeatherState")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WindDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WindSpeed")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MoscowWeatherForecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
