﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon.Infrastructure.Data.PokemonContext;

#nullable disable

namespace Pokemon.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    [Migration("20220523110107_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Pokemon.Core.PokemonInfo", b =>
                {
                    b.Property<string>("PokemonInfoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PokemonInfoId");

                    b.ToTable("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
