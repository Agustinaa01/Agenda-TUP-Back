﻿// <auto-generated />
using Agenda_Tup_Back.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaTupBack.Migrations
{
    [DbContext(typeof(AgendaApiContext))]
    [Migration("20221210181452_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelularNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            CelularNumber = "+54341234975",
                            Email = "Amigo@gmail.com",
                            LastName = "Cruz",
                            Name = "Esmeralda",
                            TelephoneNumber = "4214587",
                            UserId = 2,
                            state = 0
                        },
                        new
                        {
                            Id = 3,
                            CelularNumber = "+54114567789",
                            LastName = "Romero",
                            Name = "Daniela",
                            UserId = 1,
                            state = 0
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Mary",
                            CelularNumber = "+54341345367",
                            LastName = "Martinez",
                            Name = "Maria",
                            UserId = 1,
                            state = 0
                        },
                        new
                        {
                            Id = 1,
                            Alias = "Juanito",
                            CelularNumber = "+543436789513",
                            Email = "Hijo@gmail.com",
                            LastName = "Castillo",
                            Name = "Juan",
                            UserId = 2,
                            state = 0
                        });
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupName = "Familia"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Clases de Matematica a las 17:30hs",
                            GroupName = "Amigos"
                        });
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "danaMolina@gmail.com",
                            LastName = "Molina",
                            Password = "456def",
                            Rol = 1,
                            UserName = "Dana",
                            state = 0
                        },
                        new
                        {
                            Id = 1,
                            Email = "ericaGomez@gmail.com",
                            LastName = "Lechuga",
                            Password = "123abc",
                            Rol = 0,
                            UserName = "Erica",
                            state = 0
                        });
                });

            modelBuilder.Entity("ContactGroup", b =>
                {
                    b.Property<int>("ContactsId")
                        .HasColumnType("int");

                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.HasKey("ContactsId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("ContactGroup");
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.Contact", b =>
                {
                    b.HasOne("Agenda_Tup_Back.Entities.User", "User")
                        .WithMany("Contact")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ContactGroup", b =>
                {
                    b.HasOne("Agenda_Tup_Back.Entities.Contact", null)
                        .WithMany()
                        .HasForeignKey("ContactsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agenda_Tup_Back.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agenda_Tup_Back.Entities.User", b =>
                {
                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
