﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Contexts;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240601153832_Mig2")]
    partial class Mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_account");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("phone");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("FK_role");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Email = "mati.gorniak@gmail.com",
                            FirstName = "Mateusz",
                            LastName = "Gorniak",
                            Phone = "123456789",
                            RoleId = 1
                        },
                        new
                        {
                            AccountId = 2,
                            Email = "tomi.werner@gmail.com",
                            FirstName = "Tomasz",
                            LastName = "Werner",
                            Phone = "987654321",
                            RoleId = 2
                        },
                        new
                        {
                            AccountId = 3,
                            Email = "krzysiu.barteczko@gmail.com",
                            FirstName = "Krzysztof",
                            LastName = "Berteczko",
                            Phone = "456789123",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_category");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Category 1"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Category 2"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Category 3"
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("ProductDepth")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("depth");

                    b.Property<decimal>("ProductHeight")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("height");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("ProductWeight")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("weight");

                    b.Property<decimal>("ProductWidth")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("width");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductDepth = 1.3m,
                            ProductHeight = 2.8m,
                            ProductName = "Product 1",
                            ProductWeight = 0m,
                            ProductWidth = 2.1m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductDepth = 7.1m,
                            ProductHeight = 5.4m,
                            ProductName = "Product 2",
                            ProductWeight = 0m,
                            ProductWidth = 3m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductDepth = 3.9m,
                            ProductHeight = 5.2m,
                            ProductName = "Product 3",
                            ProductWeight = 0m,
                            ProductWidth = 2.1m
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.Product_Category", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("FK_category");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product_Categories");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_role");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "User"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Guest"
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.ShoppingCart", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("FK_account");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.HasKey("AccountId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Shopping_Carts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            ProductId = 1,
                            Amount = 20
                        },
                        new
                        {
                            AccountId = 2,
                            ProductId = 3,
                            Amount = 5
                        },
                        new
                        {
                            AccountId = 3,
                            ProductId = 2,
                            Amount = 10
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.Account", b =>
                {
                    b.HasOne("WebApplication2.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplication2.Models.Product_Category", b =>
                {
                    b.HasOne("WebApplication2.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApplication2.Models.ShoppingCart", b =>
                {
                    b.HasOne("WebApplication2.Models.Account", "Account")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApplication2.Models.Account", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("WebApplication2.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("WebApplication2.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("WebApplication2.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}