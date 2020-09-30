﻿// <auto-generated />
using System;
using MTS.DAL.DatabaseAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MTS.BL.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200930095223_creditChanges")]
    partial class creditChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MTS.DAL.Entities.Core.Credit.DALCredit", b =>
                {
                    b.Property<Guid>("CreditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreditCategoryFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GotFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkToImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MadeBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreditId");

                    b.HasIndex("CreditCategoryFK");

                    b.ToTable("Credits");

                    b.HasData(
                        new
                        {
                            CreditId = new Guid("3dc99482-c028-4e0e-a00b-70d581682c80"),
                            CreditCategoryFK = new Guid("670a3b19-5152-49c1-bf77-a05487852086"),
                            Description = "<p>Most, if not all icons came from this provider. This font came with the project when it was created. I kept it for its ease of use.</p>",
                            GotFrom = "Got from: <a href='https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor'>Blazor WebAssembly project builder</a>",
                            LinkToImage = "https://img.stackshare.io/service/3029/iconic.png",
                            MadeBy = "Made by: <a href='https://useiconic.com/open'>Open-Iconic</a>",
                            SubTitle = "<h5>Provider of fonts and icons</h5>",
                            Title = "<h4>Open Iconic</h4>"
                        },
                        new
                        {
                            CreditId = new Guid("6878653a-1375-4e2b-a77c-81ba248a221e"),
                            CreditCategoryFK = new Guid("670a3b19-5152-49c1-bf77-a05487852086"),
                            Description = "<p>Some tasks while creating an UI are repetative. Syncfusion helps by providing components for repetative use.</p>",
                            GotFrom = "Got from: <a href='https://www.syncfusion.com/products/communitylicense'>Syncfusion community license</a>",
                            LinkToImage = "https://cdn.syncfusion.com/content/images/Logo/Logo_150dpi.png",
                            MadeBy = "Made by: <a href='https://www.syncfusion.com/blazor-components'>Syncfusion website</a>",
                            SubTitle = "<h5>Easy to use premade Blazor components</h5>",
                            Title = "<h4>Syncfusion</h4>"
                        },
                        new
                        {
                            CreditId = new Guid("a1a2833d-d9c9-4688-8a88-e0e040626a9f"),
                            CreditCategoryFK = new Guid("2fc7c2b9-2bf2-4e98-9bf1-7f7238aebcfd"),
                            Description = "<p>Tim Corey provides many educational video's about programming in general but focused around C#. His goal is to make learning C# easier. Awesome guy.</p>",
                            GotFrom = "Got from: searching for tutorial video's on <a href='https://www.youtube.com'>YouTube</a> about C#",
                            LinkToImage = "https://avatars3.githubusercontent.com/u/1839873?s=400&v=4",
                            MadeBy = "Made by: <a href='https://www.youtube.com/timcorey'>Tim Corey's YouTube channel</a>",
                            SubTitle = "<h5>Youtuber with the best C# how-to video's</h5>",
                            Title = "<h4>Tim Corey</h4>"
                        });
                });

            modelBuilder.Entity("MTS.DAL.Entities.Core.Credit.DALCreditCategory", b =>
                {
                    b.Property<Guid>("CreditCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreditCategoryId");

                    b.ToTable("CreditCategories");

                    b.HasData(
                        new
                        {
                            CreditCategoryId = new Guid("670a3b19-5152-49c1-bf77-a05487852086"),
                            SubTitle = "<h5>Sources that made UI development easier</h5>",
                            Title = "<h4>Don't reinvent the wheel<h4>"
                        },
                        new
                        {
                            CreditCategoryId = new Guid("2fc7c2b9-2bf2-4e98-9bf1-7f7238aebcfd"),
                            SubTitle = "<h5>Sources that helped me gaining knoledge about programming related subjects</h5>",
                            Title = "<h4>Food for the brain<h4>"
                        });
                });

            modelBuilder.Entity("MTS.DAL.Entities.Core.DALUserAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Affix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmitted")
                        .HasColumnType("bit");

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

                    b.HasData(
                        new
                        {
                            Id = "4e9d76b7-9cba-4e17-be8a-3bafad8ceeee",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f27e3c2c-eacc-4878-aea5-60df61e93828",
                            Email = "mauricesoftwaresolution@outlook.com",
                            EmailConfirmed = true,
                            FirstName = "Maurice",
                            IsAdmitted = true,
                            LastName = "Slegtenhorst",
                            LockoutEnabled = true,
                            NormalizedEmail = "MAURICESOFTWARESOLUTION@OUTLOOK.COM",
                            NormalizedUserName = "MAURICESOFTWARESOLUTION@OUTLOOK.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==",
                            PhoneNumber = "0645377536",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "72b75e07-9663-408f-8363-aba387022d01",
                            TwoFactorEnabled = false,
                            UserName = "mauricesoftwaresolution@outlook.com"
                        },
                        new
                        {
                            Id = "c04b5af8-262e-497c-993f-1a46d4d1c977",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5aff2c2e-6045-4831-8f92-594e32645a02",
                            Email = "hanneke.slegtenhorst1@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Hanneke",
                            IsAdmitted = true,
                            LastName = "Slegtenhorst",
                            LockoutEnabled = true,
                            NormalizedEmail = "HANNEKE.SLEGTENHORST1@GMAIL.COM",
                            NormalizedUserName = "HANNEKE.SLEGTENHORST1@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==",
                            PhoneNumber = "060025553912",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "a31ad130-2d76-4bd6-837a-7f44db2ca2b3",
                            TwoFactorEnabled = false,
                            UserName = "hanneke.slegtenhorst1@gmail.com"
                        },
                        new
                        {
                            Id = "29e60a21-ff54-4182-bddc-8b4239335a6e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4840e617-4530-40d4-aa35-ea6901e75422",
                            Email = "privilegedemployee01@mss.nl",
                            EmailConfirmed = true,
                            FirstName = "PrivilegedEmployee_01",
                            IsAdmitted = true,
                            LastName = "None",
                            LockoutEnabled = true,
                            NormalizedEmail = "PRIVILEGEDEMPLOYEE01@MSS.NL",
                            NormalizedUserName = "PRIVILEGEDEMPLOYEE01@MSS.NL",
                            PasswordHash = "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==",
                            PhoneNumber = "060035678950",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "16674d82-7167-4b5d-9cdf-fc5a75116607",
                            TwoFactorEnabled = false,
                            UserName = "privilegedemployee01@mss.nl"
                        },
                        new
                        {
                            Id = "3b359123-4317-44b6-b068-f204a97c3c73",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f353699d-3f17-41ff-8998-e491b0c6fa6f",
                            Email = "employee01@mss.nl",
                            EmailConfirmed = true,
                            FirstName = "Employee_01",
                            IsAdmitted = true,
                            LastName = "None",
                            LockoutEnabled = true,
                            NormalizedEmail = "EMPLOYEE01@MSS.NL",
                            NormalizedUserName = "EMPLOYEE01@MTS.NL",
                            PasswordHash = "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==",
                            PhoneNumber = "060054542051",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "0ef5a3d7-7704-40f1-854a-1350619f71ce",
                            TwoFactorEnabled = false,
                            UserName = "Employee01@MTS.nl"
                        },
                        new
                        {
                            Id = "a6432b3b-b8ad-454d-9234-6d5eb53ec6cd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bbdd05d6-b3b8-4099-ad12-24b9dd68077f",
                            Email = "standarduser01@mts.nl",
                            EmailConfirmed = true,
                            FirstName = "StandardUser_01",
                            IsAdmitted = true,
                            LastName = "None",
                            LockoutEnabled = true,
                            NormalizedEmail = "STANDARDUSER01@MSS.NL",
                            NormalizedUserName = "STANDARDUSER01@MSS.NL",
                            PasswordHash = "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==",
                            PhoneNumber = "060001959870",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "f93c5d6f-140b-4803-a370-9299ab6b6b2e",
                            TwoFactorEnabled = false,
                            UserName = "standarduser01@mts.nl"
                        });
                });

            modelBuilder.Entity("MTS.DAL.Entities.Core.EditPageContent.DALPageSection", b =>
                {
                    b.Property<Guid>("PageSectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PageRoute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionNumber")
                        .HasColumnType("int");

                    b.HasKey("PageSectionId");

                    b.ToTable("PageSections");

                    b.HasData(
                        new
                        {
                            PageSectionId = new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"),
                            PageRoute = "Index",
                            SectionNumber = 0
                        },
                        new
                        {
                            PageSectionId = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            PageRoute = "Index",
                            SectionNumber = 1
                        });
                });

            modelBuilder.Entity("MTS.DAL.Entities.Core.EditPageContent.DALSectionPart", b =>
                {
                    b.Property<Guid>("SectionPartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PageSectionFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionPartId");

                    b.HasIndex("PageSectionFK");

                    b.ToTable("SectionParts");

                    b.HasData(
                        new
                        {
                            SectionPartId = new Guid("810f81e8-b851-4992-9b9a-84833182dfe5"),
                            Content = "<h4>About me and MSS</h4>",
                            PageSectionFK = new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"),
                            Type = "Title1"
                        },
                        new
                        {
                            SectionPartId = new Guid("591fb1ce-370c-408e-b241-8d11f08c1700"),
                            Content = "<strong>What is MSS?</strong>",
                            PageSectionFK = new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"),
                            Type = "Header1"
                        },
                        new
                        {
                            SectionPartId = new Guid("da19d6ba-2a2c-43d6-b4d1-8138f78fc3c1"),
                            Content = "<p>Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.</p>",
                            PageSectionFK = new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"),
                            Type = "Body1"
                        },
                        new
                        {
                            SectionPartId = new Guid("ff68faf3-4221-4dcd-a248-ec3260a84e39"),
                            Content = "<strong>Who is Maurice?</strong>",
                            PageSectionFK = new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"),
                            Type = "Header2"
                        },
                        new
                        {
                            SectionPartId = new Guid("bb11c814-21f0-436b-80bd-ca619a5495ae"),
                            Content = @"<p>I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.</p>
<p>Friends and especially family regularly ask me for help with electronics and software related matters. I think this is because I have been busy with software and hardware practically my whole life.</p>
<p>Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.</p>
<p>At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. After about a year I have successfully completed the process.</p>
<p>My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, I want to find out and test it. See what has gotten better or worse.</p>
<p>Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.</p>
<p>That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question</p>",
                            PageSectionFK = new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"),
                            Type = "Body2"
                        },
                        new
                        {
                            SectionPartId = new Guid("68daf39f-05d9-4822-90ae-e1177a38b396"),
                            Content = "<h4>Maurice Slegtenhorst</h4>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "Title1"
                        },
                        new
                        {
                            SectionPartId = new Guid("347e2eff-48f6-4ac7-a7f4-735383e5f2e8"),
                            Content = "<h5>C# Software Developer</h5>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "SubTitle1"
                        },
                        new
                        {
                            SectionPartId = new Guid("36540420-e487-41bb-bfa5-f25874ffb415"),
                            Content = "<strong>Contact information</strong>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "Header1"
                        },
                        new
                        {
                            SectionPartId = new Guid("48ce8771-c428-4f4e-b4d0-a1b5b4022e37"),
                            Content = "<div class=\"row\"><div class=\"col - 6\">Phone number:</div><div class=\"col - 6\">+31 645377536</div></div><div class=\"row\"><div class=\"col - 6\">Personal e-mail:</div><div class=\"col - 6\">maurice.slegtenhorst@outlook.com</div></div><div class=\"row\"><div class=\"col - 6\">Student e-mail</div><div class=\"col - 6\">maurice.slegtenhorst@itvitaelearning.nl</div></div></p>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "Body1"
                        },
                        new
                        {
                            SectionPartId = new Guid("16db04af-b2c7-409d-b56a-ad12b5f81149"),
                            Content = "<strong>What can he do?</strong>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "Header2"
                        },
                        new
                        {
                            SectionPartId = new Guid("03b8a39b-e700-441d-ab1b-4918a2b58c10"),
                            Content = "<p>C#, JavaScript, SQL, HTML5, CSS3, XAML and XML</p>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "Body2"
                        },
                        new
                        {
                            SectionPartId = new Guid("3df17a45-eaf7-41ec-8aa6-e7f250e8b15e"),
                            Content = "<strong>Maurice in a nutshell</strong>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "Header3"
                        },
                        new
                        {
                            SectionPartId = new Guid("9f5a6b7a-b9ea-4b13-8d66-567ff541b9a5"),
                            Content = "<p>Born on 27th of april 1991 and living in The Netherlands sinds then. Loves coding and fiddling with electronics. Likes to go for a jog or socialize</p>",
                            PageSectionFK = new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"),
                            Type = "Body3"
                        });
                });

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

                    b.HasData(
                        new
                        {
                            Id = "0b6383b6-09b2-4694-857f-97e43e8337c3",
                            ConcurrencyStamp = "073ae7bf-4981-456e-8095-e947fc5faea0",
                            Name = "administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "35e74155-6145-4f2f-a517-1ef43a8f2e9a",
                            ConcurrencyStamp = "6eaaa42b-a89d-4aff-aea9-db11c84697b1",
                            Name = "privilegedemployee",
                            NormalizedName = "PRIVILEGEDEMPLOYEE"
                        },
                        new
                        {
                            Id = "89b2c433-c5ab-468a-a1b8-e00356311f01",
                            ConcurrencyStamp = "49492850-7207-4d42-9a4c-485da3803bb7",
                            Name = "employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "bf87512d-438b-4dab-a4ff-5857c12012f0",
                            ConcurrencyStamp = "baa82893-4839-48d1-ad9c-01e29f4b7dba",
                            Name = "volenteer",
                            NormalizedName = "VOLENTEER"
                        },
                        new
                        {
                            Id = "8f1cb419-6140-4e39-84fa-d22b1205b3dc",
                            ConcurrencyStamp = "c4810578-bf65-41a4-8009-5fc8b2c0c41f",
                            Name = "privilegeduser",
                            NormalizedName = "PRIVILEGEDUSER"
                        },
                        new
                        {
                            Id = "35196f9b-aab8-425a-ab74-37441ad84eaf",
                            ConcurrencyStamp = "5becea24-3184-49ea-b585-b515fce47598",
                            Name = "standarduser",
                            NormalizedName = "STANDARDUSER"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "4e9d76b7-9cba-4e17-be8a-3bafad8ceeee",
                            RoleId = "0b6383b6-09b2-4694-857f-97e43e8337c3"
                        },
                        new
                        {
                            UserId = "c04b5af8-262e-497c-993f-1a46d4d1c977",
                            RoleId = "0b6383b6-09b2-4694-857f-97e43e8337c3"
                        },
                        new
                        {
                            UserId = "29e60a21-ff54-4182-bddc-8b4239335a6e",
                            RoleId = "35e74155-6145-4f2f-a517-1ef43a8f2e9a"
                        },
                        new
                        {
                            UserId = "3b359123-4317-44b6-b068-f204a97c3c73",
                            RoleId = "89b2c433-c5ab-468a-a1b8-e00356311f01"
                        },
                        new
                        {
                            UserId = "a6432b3b-b8ad-454d-9234-6d5eb53ec6cd",
                            RoleId = "35196f9b-aab8-425a-ab74-37441ad84eaf"
                        });
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

            modelBuilder.Entity("MTS.DAL.Entities.Core.Credit.DALCredit", b =>
                {
                    b.HasOne("MTS.DAL.Entities.Core.Credit.DALCreditCategory", null)
                        .WithMany("DALCredits")
                        .HasForeignKey("CreditCategoryFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MTS.DAL.Entities.Core.EditPageContent.DALSectionPart", b =>
                {
                    b.HasOne("MTS.DAL.Entities.Core.EditPageContent.DALPageSection", "DALPageSection")
                        .WithMany("DALSectionParts")
                        .HasForeignKey("PageSectionFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("MTS.DAL.Entities.Core.DALUserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MTS.DAL.Entities.Core.DALUserAccount", null)
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

                    b.HasOne("MTS.DAL.Entities.Core.DALUserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MTS.DAL.Entities.Core.DALUserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}