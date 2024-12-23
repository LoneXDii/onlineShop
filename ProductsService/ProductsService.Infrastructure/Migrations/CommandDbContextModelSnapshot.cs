﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsService.Infrastructure.Data;

#nullable disable

namespace ProductsService.Infrastructure.Migrations
{
    [DbContext(typeof(CommandDbContext))]
    partial class CommandDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriesId = 1,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 3,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 5,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 7,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 10,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 12,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 14,
                            ProductsId = 1
                        },
                        new
                        {
                            CategoriesId = 1,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 3,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 5,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 7,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 11,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 13,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 14,
                            ProductsId = 2
                        },
                        new
                        {
                            CategoriesId = 2,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 4,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 6,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 8,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 9,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 15,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 17,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 19,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 21,
                            ProductsId = 3
                        },
                        new
                        {
                            CategoriesId = 2,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 4,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 6,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 8,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 9,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 15,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 16,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 18,
                            ProductsId = 4
                        },
                        new
                        {
                            CategoriesId = 20,
                            ProductsId = 4
                        });
                });

            modelBuilder.Entity("ProductsService.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Smartphones"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Laptops"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Brand",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Brand",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "RAM",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "RAM",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "ROM",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 8,
                            Name = "ROM",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 9,
                            Name = "Processor",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 10,
                            Name = "Samsung",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 11,
                            Name = "Apple",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 12,
                            Name = "12GB",
                            ParentId = 5
                        },
                        new
                        {
                            Id = 13,
                            Name = "8GB",
                            ParentId = 5
                        },
                        new
                        {
                            Id = 14,
                            Name = "512GB",
                            ParentId = 7
                        },
                        new
                        {
                            Id = 15,
                            Name = "Apple",
                            ParentId = 4
                        },
                        new
                        {
                            Id = 16,
                            Name = "16GB",
                            ParentId = 6
                        },
                        new
                        {
                            Id = 17,
                            Name = "18GB",
                            ParentId = 6
                        },
                        new
                        {
                            Id = 18,
                            Name = "512GB",
                            ParentId = 8
                        },
                        new
                        {
                            Id = 19,
                            Name = "1024GB",
                            ParentId = 8
                        },
                        new
                        {
                            Id = 20,
                            Name = "M3",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 21,
                            Name = "M3 Pro",
                            ParentId = 9
                        });
                });

            modelBuilder.Entity("ProductsService.Domain.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Percent")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Discounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Percent = 15,
                            ProductId = 3,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ProductsService.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Samsung Galaxy S24 Ultra",
                            Price = 1119.99,
                            Quantity = 14
                        },
                        new
                        {
                            Id = 2,
                            Name = "IPhone 15 Pro",
                            Price = 999.0,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 3,
                            Name = "MacBook Pro 16'",
                            Price = 2499.0,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "MacBook Air 13'",
                            Price = 1099.0,
                            Quantity = 12
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("ProductsService.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsService.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductsService.Domain.Entities.Category", b =>
                {
                    b.HasOne("ProductsService.Domain.Entities.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ProductsService.Domain.Entities.Discount", b =>
                {
                    b.HasOne("ProductsService.Domain.Entities.Product", "Product")
                        .WithOne("Discount")
                        .HasForeignKey("ProductsService.Domain.Entities.Discount", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductsService.Domain.Entities.Category", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("ProductsService.Domain.Entities.Product", b =>
                {
                    b.Navigation("Discount");
                });
#pragma warning restore 612, 618
        }
    }
}
