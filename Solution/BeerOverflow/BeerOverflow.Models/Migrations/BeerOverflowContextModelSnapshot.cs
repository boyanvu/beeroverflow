﻿// <auto-generated />
using System;
using BeerOverflow.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeerOverflow.Data.Migrations
{
    [DbContext(typeof(BeerOverflowContext))]
    partial class BeerOverflowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerOverflow.Data.Entities.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AlcByVol")
                        .HasColumnType("float");

                    b.Property<string>("BeerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("BeerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("BreweryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateUnlisted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeerName")
                        .IsUnique();

                    b.HasIndex("BeerTypeId");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlcByVol = 5.5999999999999996,
                            BeerName = "Possession Porter",
                            BeerTypeId = 1,
                            BreweryId = 1,
                            Description = "American beer"
                        },
                        new
                        {
                            Id = 2,
                            AlcByVol = 5.0,
                            BeerName = "Wexford Irish Cream Ale",
                            BeerTypeId = 3,
                            BreweryId = 3,
                            Description = "English beer"
                        },
                        new
                        {
                            Id = 3,
                            AlcByVol = 4.9000000000000004,
                            BeerName = "Hoegaarden",
                            BeerTypeId = 3,
                            BreweryId = 5,
                            Description = "Belge beer"
                        },
                        new
                        {
                            Id = 4,
                            AlcByVol = 5.0,
                            BeerName = "Heineken",
                            BeerTypeId = 3,
                            BreweryId = 4,
                            Description = "Dutch beer"
                        },
                        new
                        {
                            Id = 5,
                            AlcByVol = 4.5,
                            BeerName = "Corona Extra",
                            BeerTypeId = 2,
                            BreweryId = 6,
                            Description = "Mexican-Belge beer"
                        },
                        new
                        {
                            Id = 6,
                            AlcByVol = 4.0,
                            BeerName = "Snow",
                            BeerTypeId = 2,
                            BreweryId = 7,
                            Description = "Chinese beer"
                        },
                        new
                        {
                            Id = 7,
                            AlcByVol = 5.0,
                            BeerName = "Budweiser",
                            BeerTypeId = 2,
                            BreweryId = 1,
                            Description = "American beer"
                        },
                        new
                        {
                            Id = 8,
                            AlcByVol = 5.0,
                            BeerName = "Left Hand Milk Stout",
                            BeerTypeId = 4,
                            BreweryId = 8,
                            Description = "English beer"
                        },
                        new
                        {
                            Id = 9,
                            AlcByVol = 5.0,
                            BeerName = "Tsingtao",
                            BeerTypeId = 3,
                            BreweryId = 3,
                            Description = "Chinese beer"
                        },
                        new
                        {
                            Id = 10,
                            AlcByVol = 4.2000000000000002,
                            BeerName = "Coors Light",
                            BeerTypeId = 2,
                            BreweryId = 10,
                            Description = "English beer"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.BeerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("BeerTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Style of beer that was developed in London in the early eighteenth century.",
                            Type = "Porter"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Type of beer conditioned at low temperatures.",
                            Type = "Lager"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Type of beer brewed using a warm fermentation method",
                            Type = "Ale"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Dark, top-fermented beer with a number of variations, including dry stout, Baltic porter, milk stout, and imperial stout.",
                            Type = "Stout"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.Brewery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Description = "America",
                            Name = "Diamond Knot Brewery"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Description = "American brewery",
                            Name = "Anheuser-Busch"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 4,
                            Description = "English brewery",
                            Name = "Greene King"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 3,
                            Description = "Dutch brewery",
                            Name = "Heineken International"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Description = "Belge brewery",
                            Name = "Brouwerij van Hoegaarden"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 7,
                            Description = "Mexican brewery",
                            Name = "Grupo Modelo"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 9,
                            Description = "Chinese brewery",
                            Name = "CR Snow"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 1,
                            Description = "American brewery",
                            Name = "Left Hand Brewing"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 4,
                            Description = "Chinese brewery",
                            Name = "Tsingtao Brewery"
                        },
                        new
                        {
                            Id = 10,
                            CountryId = 1,
                            Description = "American brewery",
                            Name = "Coors Brewing Company"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "United States"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 4,
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Canada"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Switzerland"
                        },
                        new
                        {
                            Id = 9,
                            Name = "China"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Norway"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.RateReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInapropriate")
                        .HasColumnType("bit");

                    b.Property<int>("LikeReview")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("RateReviews");
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("UserId", "BeerId")
                        .IsUnique();

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "47bcc26a-c13d-4e6e-ae5b-acdac5960f91",
                            Description = "Admin role",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "d2d7fa72-ff04-4813-922f-b7b4644ad7c7",
                            Description = "User role",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.UserBeers", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DrankOn")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "BeerId");

                    b.HasIndex("BeerId");

                    b.ToTable("UserBeers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.Beer", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.BeerType", "BeerType")
                        .WithMany("Beers")
                        .HasForeignKey("BeerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Data.Entities.Brewery", "Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.Brewery", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.Country", "Country")
                        .WithMany("Breweries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.RateReview", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.Review", "Review")
                        .WithMany("RateReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Data.Entities.User", "User")
                        .WithMany("RateReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.Review", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.Beer", "Beer")
                        .WithMany("Reviews")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Data.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Data.Entities.UserBeers", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BeerOverflow.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
