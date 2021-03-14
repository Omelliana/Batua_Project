﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

namespace batuaShop.Migrations
{
    [DbContext(typeof(AppDbContent))]
    [Migration("20210312195937_SomeInitial")]
    partial class SomeInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("batuaShop.Data.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("dateTime");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("batuaShop.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bookId");

                    b.Property<int>("orderId");

                    b.Property<long>("price");

                    b.HasKey("id");

                    b.HasIndex("bookId");

                    b.HasIndex("orderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("batuaShop.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("bookid");

                    b.Property<long>("count");

                    b.Property<long>("price");

                    b.Property<string>("shopCartId");

                    b.HasKey("id");

                    b.HasIndex("bookid");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("WebApplication2.Data.Models.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoryId");

                    b.Property<bool>("favourite");

                    b.Property<string>("img");

                    b.Property<string>("longDesc");

                    b.Property<string>("name");

                    b.Property<long>("price");

                    b.Property<string>("shortDesc");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("WebApplication2.Data.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName");

                    b.Property<string>("desc");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("batuaShop.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("WebApplication2.Data.Models.Book", "book")
                        .WithMany()
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("batuaShop.Data.Models.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("batuaShop.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("WebApplication2.Data.Models.Book", "book")
                        .WithMany()
                        .HasForeignKey("bookid");
                });

            modelBuilder.Entity("WebApplication2.Data.Models.Book", b =>
                {
                    b.HasOne("WebApplication2.Data.Models.Category", "Category")
                        .WithMany("books")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
