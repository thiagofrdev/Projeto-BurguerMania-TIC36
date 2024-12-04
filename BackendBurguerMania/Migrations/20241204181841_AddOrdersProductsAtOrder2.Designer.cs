﻿// <auto-generated />
using BackendBurguerMania.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendBurguerMania.Migrations
{
    [DbContext(typeof(BurguerManiaContext))]
    [Migration("20241204181841_AddOrdersProductsAtOrder2")]
    partial class AddOrdersProductsAtOrder2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackendBurguerMania.Models.Category", b =>
                {
                    b.Property<int>("ID_Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Category"));

                    b.Property<string>("Description_Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name_Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Path_Image_Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID_Category");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.Order", b =>
                {
                    b.Property<int>("ID_Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Order"));

                    b.Property<int>("Status_ID")
                        .HasColumnType("integer");

                    b.Property<decimal>("Value_Order")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ID_Order");

                    b.HasIndex("Status_ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.OrdersProducts", b =>
                {
                    b.Property<int>("ID_OrdersProducts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_OrdersProducts"));

                    b.Property<int>("Order_ID")
                        .HasColumnType("integer");

                    b.Property<int>("Product_ID")
                        .HasColumnType("integer");

                    b.HasKey("ID_OrdersProducts");

                    b.HasIndex("Order_ID");

                    b.HasIndex("Product_ID");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.Product", b =>
                {
                    b.Property<int>("ID_Product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Product"));

                    b.Property<string>("Base_Description_Product")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<int>("Category_ID")
                        .HasColumnType("integer");

                    b.Property<string>("Full_Description_Product")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<string>("Name_Product")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Path_Image_Product")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price_Product")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ID_Product");

                    b.HasIndex("Category_ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.Status", b =>
                {
                    b.Property<int>("ID_Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Status"));

                    b.Property<string>("Name_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID_Status");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.Users", b =>
                {
                    b.Property<int>("ID_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_User"));

                    b.Property<string>("Email_User")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Name_User")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password_Hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.UsersOrders", b =>
                {
                    b.Property<int>("ID_UserOrders")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_UserOrders"));

                    b.Property<int>("Order_ID")
                        .HasColumnType("integer");

                    b.Property<int>("UserID_User")
                        .HasColumnType("integer");

                    b.Property<int>("User_ID")
                        .HasColumnType("integer");

                    b.HasKey("ID_UserOrders");

                    b.HasIndex("Order_ID");

                    b.HasIndex("UserID_User");

                    b.ToTable("UsersOrders");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.Order", b =>
                {
                    b.HasOne("BackendBurguerMania.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("Status_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.OrdersProducts", b =>
                {
                    b.HasOne("BackendBurguerMania.Models.Order", "Order")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("Order_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendBurguerMania.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.Product", b =>
                {
                    b.HasOne("BackendBurguerMania.Models.Category", "Categories")
                        .WithMany()
                        .HasForeignKey("Category_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.UsersOrders", b =>
                {
                    b.HasOne("BackendBurguerMania.Models.Order", "Order")
                        .WithMany("UsersOrders")
                        .HasForeignKey("Order_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendBurguerMania.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendBurguerMania.Models.Order", b =>
                {
                    b.Navigation("OrdersProducts");

                    b.Navigation("UsersOrders");
                });
#pragma warning restore 612, 618
        }
    }
}