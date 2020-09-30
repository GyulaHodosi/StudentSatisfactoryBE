﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentSatisfactoryBackend.Data;

namespace StudentSatisfactoryBackend.Migrations
{
    [DbContext(typeof(SurveyContext))]
    partial class SurveyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StudentSatisfactoryBackend.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "progbasics@code.cool",
                            Name = "Fullstack - Programming Basics"
                        },
                        new
                        {
                            Id = 2,
                            Email = "web@code.cool",
                            Name = "Fullstack - Web"
                        },
                        new
                        {
                            Id = 3,
                            Email = "oop@code.cool",
                            Name = "Fullstack - OOP"
                        },
                        new
                        {
                            Id = 4,
                            Email = "advanced@code.cool",
                            Name = "Fullstack - Advanced"
                        });
                });

            modelBuilder.Entity("StudentSatisfactoryBackend.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoteCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("StudentSatisfactoryBackend.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4363),
                            Title = "Codecool office staff has good response times when there's a question or problem"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4482),
                            Title = "There's a valid reaction (something happens) from Codecool office staff when I raise a problem."
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4489),
                            Title = "The process of study/job contracting, signing paperwork is smooth, communication about it is satisfactory."
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4496),
                            Title = "There's a cool atmosphere in Codecool which helps me to improve and stay motivated."
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4503),
                            Title = "I feel belonging to a group in Codecool and it satisfies me."
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4514),
                            Title = "Codecool is located in a great place (easily reachable, travel time from your home is okay)."
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4520),
                            Title = "Codecool office offers a clean and calm environment that is needed for me to focus on my studies."
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4527),
                            Title = "The theoretical materials provided by Codecool help my journey becoming a junior developer."
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4534),
                            Title = "The practical materials provided by Codecool help my journey becoming a junior developer."
                        },
                        new
                        {
                            Id = 10,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4542),
                            Title = "The requirements or competencies in the curriculum provided by Codecool are clear and help my journey becoming a software developer."
                        },
                        new
                        {
                            Id = 11,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4549),
                            Title = "I get enough professional help (either from my peers or from mentors) in order to improve in hard skills."
                        },
                        new
                        {
                            Id = 12,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4556),
                            Title = "I get enough professional help(either from my peers or from staff members) in order to improve in soft skills."
                        },
                        new
                        {
                            Id = 13,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4562),
                            Title = "I get enough emotional support (either from my peers or from staff members) when I need to."
                        },
                        new
                        {
                            Id = 14,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4569),
                            Title = "I believe that I will find a job suitable for me after graduating from Codecool."
                        },
                        new
                        {
                            Id = 15,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4576),
                            Title = "I would definitely need Codecool's help in finding my first job after graduating."
                        },
                        new
                        {
                            Id = 16,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4582),
                            Title = "I believe that there are enough positions to choose from after graduating from Codecool."
                        },
                        new
                        {
                            Id = 17,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4589),
                            Title = "Codecool's job interview preparation is a huge help for me to get a job I need."
                        },
                        new
                        {
                            Id = 18,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4597),
                            Title = "What do you think about the number of frontal lessons in Codecool?"
                        },
                        new
                        {
                            Id = 19,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4604),
                            Title = "What do you think about the amount of teamwork in Codecool?"
                        },
                        new
                        {
                            Id = 20,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4611),
                            Title = "What do you think about the amount of self-study time in Codecool?"
                        },
                        new
                        {
                            Id = 21,
                            Date = new DateTime(2020, 9, 30, 14, 28, 6, 881, DateTimeKind.Local).AddTicks(4617),
                            Title = "What do you think about the number of interactive workshops in Codecool?"
                        });
                });

            modelBuilder.Entity("StudentSatisfactoryBackend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PictureLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("StudentSatisfactoryBackend.Models.UserQuestion", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("UserId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("UserQuestions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentSatisfactoryBackend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentSatisfactoryBackend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentSatisfactoryBackend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentSatisfactoryBackend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentSatisfactoryBackend.Models.UserQuestion", b =>
                {
                    b.HasOne("StudentSatisfactoryBackend.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentSatisfactoryBackend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
