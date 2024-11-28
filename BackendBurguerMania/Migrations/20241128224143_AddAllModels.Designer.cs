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
    [Migration("20241128224143_AddAllModels")]
    partial class AddAllModels
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

                    b.Property<decimal>("Value_Order")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ID_Order");

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
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Category_ID")
                        .HasColumnType("integer");

                    b.Property<string>("Full_Description_Product")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

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

                    b.Property<int>("User_ID")
                        .HasColumnType("integer");

                    b.HasKey("ID_UserOrders");

                    b.ToTable("UsersOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
