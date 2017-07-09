using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ECommerce.Models;

namespace ECommerce.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    [Migration("20170420233339_FirstMigration2")]
    partial class FirstMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ECommerce.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<int?>("ProductId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ECommerce.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ECommerce.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductName");

                    b.Property<int>("ProductQuantity");

                    b.Property<string>("ProductUrl");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ECommerce.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ECommerce.Models.Customer", b =>
                {
                    b.HasOne("ECommerce.Models.Product")
                        .WithMany("Customers")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ECommerce.Models.Order", b =>
                {
                    b.HasOne("ECommerce.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECommerce.Models.Product", "Product")
                        .WithMany("Order")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
