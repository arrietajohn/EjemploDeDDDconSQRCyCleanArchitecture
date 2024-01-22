﻿// <auto-generated />
using System;
using FinanzasPersonales.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanzasPersonales.Persistence.Migrations
{
    [DbContext(typeof(EfDatabeseContext))]
    [Migration("20240122032321_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ExpenseAndIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpenseMovementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IncomeMovementId")
                        .HasColumnType("int");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseMovementId");

                    b.HasIndex("IncomeMovementId");

                    b.ToTable("ExpenseAndIncomes");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ExpenseAndSavingBag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpenseMovementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("SavingBagMovementiD")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseMovementId");

                    b.HasIndex("SavingBagMovementiD");

                    b.ToTable("ExpenseAndSavingBags");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.FinancialMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FinancialMovement");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FinancialMovement");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ReviewRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestedUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestingUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequestedUserId");

                    b.HasIndex("RequestingUserId");

                    b.ToTable("ReviewRequests");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReviewRequestId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewedUserId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ViewAddress")
                        .HasColumnType("bit");

                    b.Property<bool>("ViewEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("ViewPhoneNumber")
                        .HasColumnType("bit");

                    b.Property<bool>("ViewPhoto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ReviewRequestId")
                        .IsUnique();

                    b.HasIndex("ReviewedUserId");

                    b.HasIndex("ReviewerUserId");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ExpenseMovement", b =>
                {
                    b.HasBaseType("FinanzasPersonales.Domain.Entities.FinancialMovement");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasIndex("CategoryId");

                    b.HasDiscriminator().HasValue("ExpenseMovement");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.IncomeMovement", b =>
                {
                    b.HasBaseType("FinanzasPersonales.Domain.Entities.FinancialMovement");

                    b.Property<decimal>("BalanceValue")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int?>("SavingBagMovementId")
                        .HasColumnType("int");

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValueSaved")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasIndex("SavingBagMovementId");

                    b.HasIndex("SourceId");

                    b.HasDiscriminator().HasValue("IncomeMovement");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.SavingBagMovement", b =>
                {
                    b.HasBaseType("FinanzasPersonales.Domain.Entities.FinancialMovement");

                    b.Property<decimal>("BalanceValue")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<DateTime?>("PostponementDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ProposedValue")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FinancialMovement", t =>
                        {
                            t.Property("BalanceValue")
                                .HasColumnName("SavingBagMovement_BalanceValue");
                        });

                    b.HasDiscriminator().HasValue("SavingBagMovement");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ExpenseAndIncome", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.ExpenseMovement", "ExpenseMovement")
                        .WithMany("ExpenseAndIncomes")
                        .HasForeignKey("ExpenseMovementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinanzasPersonales.Domain.Entities.IncomeMovement", "IncomeMovement")
                        .WithMany("ExpenseAndIncomes")
                        .HasForeignKey("IncomeMovementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ExpenseMovement");

                    b.Navigation("IncomeMovement");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ExpenseAndSavingBag", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.ExpenseMovement", "ExpenseMovement")
                        .WithMany("ExpenseAndSavingBags")
                        .HasForeignKey("ExpenseMovementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinanzasPersonales.Domain.Entities.SavingBagMovement", "SavingBagMovement")
                        .WithMany("ExpenseAndSavingBags")
                        .HasForeignKey("SavingBagMovementiD")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ExpenseMovement");

                    b.Navigation("SavingBagMovement");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.FinancialMovement", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.User", "User")
                        .WithMany("FinancialMovements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Review", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ReviewRequest", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.User", "RequestedUser")
                        .WithMany("ReceivedReviewRequests")
                        .HasForeignKey("RequestedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinanzasPersonales.Domain.Entities.User", "RequestingUser")
                        .WithMany("SentReviewRequests")
                        .HasForeignKey("RequestingUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RequestedUser");

                    b.Navigation("RequestingUser");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Reviewer", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.ReviewRequest", "ReviewRequest")
                        .WithOne("Reviewer")
                        .HasForeignKey("FinanzasPersonales.Domain.Entities.Reviewer", "ReviewRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinanzasPersonales.Domain.Entities.User", "ReviewedUser")
                        .WithMany("ReviewedUsers")
                        .HasForeignKey("ReviewedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinanzasPersonales.Domain.Entities.User", "ReviewerUser")
                        .WithMany("ReviewerUsers")
                        .HasForeignKey("ReviewerUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReviewRequest");

                    b.Navigation("ReviewedUser");

                    b.Navigation("ReviewerUser");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ExpenseMovement", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.Category", "Category")
                        .WithMany("ExpenseMovements")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.IncomeMovement", b =>
                {
                    b.HasOne("FinanzasPersonales.Domain.Entities.SavingBagMovement", "SavingBagMovement")
                        .WithMany("IncomeMovements")
                        .HasForeignKey("SavingBagMovementId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FinanzasPersonales.Domain.Entities.Source", "Source")
                        .WithMany("IncomeMovements")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SavingBagMovement");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Category", b =>
                {
                    b.Navigation("ExpenseMovements");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ReviewRequest", b =>
                {
                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.Source", b =>
                {
                    b.Navigation("IncomeMovements");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.User", b =>
                {
                    b.Navigation("FinancialMovements");

                    b.Navigation("ReceivedReviewRequests");

                    b.Navigation("ReviewedUsers");

                    b.Navigation("ReviewerUsers");

                    b.Navigation("SentReviewRequests");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.ExpenseMovement", b =>
                {
                    b.Navigation("ExpenseAndIncomes");

                    b.Navigation("ExpenseAndSavingBags");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.IncomeMovement", b =>
                {
                    b.Navigation("ExpenseAndIncomes");
                });

            modelBuilder.Entity("FinanzasPersonales.Domain.Entities.SavingBagMovement", b =>
                {
                    b.Navigation("ExpenseAndSavingBags");

                    b.Navigation("IncomeMovements");
                });
#pragma warning restore 612, 618
        }
    }
}
