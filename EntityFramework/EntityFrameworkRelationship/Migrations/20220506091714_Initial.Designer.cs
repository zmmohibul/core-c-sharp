﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkIntro.Migrations
{
    [DbContext(typeof(BrickContext))]
    [Migration("20220506091714_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Brick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Bricks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Brick");
                });

            modelBuilder.Entity("BrickAvailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableAmount")
                        .HasColumnType("int");

                    b.Property<int>("BrickId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrickId");

                    b.HasIndex("VendorId");

                    b.ToTable("BrickAvailability");
                });

            modelBuilder.Entity("BrickTag", b =>
                {
                    b.Property<int>("BricksId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("BricksId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("BrickTag");
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VendorName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("BasePlate", b =>
                {
                    b.HasBaseType("Brick");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("BasePlate");
                });

            modelBuilder.Entity("MinifigHead", b =>
                {
                    b.HasBaseType("Brick");

                    b.Property<bool>("IsDualSided")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("MinifigHead");
                });

            modelBuilder.Entity("BrickAvailability", b =>
                {
                    b.HasOne("Brick", "Brick")
                        .WithMany("BrickAvailability")
                        .HasForeignKey("BrickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vendor", "Vendor")
                        .WithMany("BrickAvailability")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brick");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("BrickTag", b =>
                {
                    b.HasOne("Brick", null)
                        .WithMany()
                        .HasForeignKey("BricksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Brick", b =>
                {
                    b.Navigation("BrickAvailability");
                });

            modelBuilder.Entity("Vendor", b =>
                {
                    b.Navigation("BrickAvailability");
                });
#pragma warning restore 612, 618
        }
    }
}
