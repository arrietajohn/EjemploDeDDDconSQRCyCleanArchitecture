
using FinanzasPersonales.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanzasPersonales.Persistence.Database;
public class EfDatabeseContext : DbContext
{
    public EfDatabeseContext() { }

    public EfDatabeseContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<ExpenseAndIncome> ExpenseAndIncomes { get; set; }
    public DbSet<ExpenseAndSavingBag> ExpenseAndSavingBags { get; set; }
    public DbSet<ExpenseMovement> ExpenseMovements { get; set; }
    public DbSet<IncomeMovement> IncomeMovements { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
    public DbSet<ReviewRequest> ReviewRequests { get; set; }
    public DbSet<SavingBagMovement> SavingBagMovements { get; set; }
    public DbSet<Source> Sources { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ReviewRequest>()
            .HasOne(rr => rr.RequestingUser)
            .WithMany(u => u.SentReviewRequests)
            .HasForeignKey(rr => rr.RequestingUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ReviewRequest>()
            .HasOne(rr => rr.RequestedUser)
            .WithMany(u => u.ReceivedReviewRequests)
            .HasForeignKey(rr => rr.RequestedUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reviewer>()
           .HasOne(r => r.ReviewerUser)
           .WithMany(u => u.ReviewerUsers)
           .HasForeignKey(r => r.ReviewerUserId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reviewer>()
            .HasOne(r => r.ReviewedUser)
            .WithMany(u => u.ReviewedUsers)
            .HasForeignKey(r => r.ReviewedUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ReviewRequest>()
                .HasOne(rr => rr.Reviewer)
                .WithOne(r => r.ReviewRequest)
                .HasForeignKey<Reviewer>(r => r.ReviewRequestId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ExpenseAndIncome>()
            .Property(i => i.Value)
            .HasColumnType("DECIMAL(18,2)");

        builder.Entity<ExpenseAndIncome>()
           .Property(i => i.Percentage)
           .HasColumnType("DECIMAL(18,2)");

        builder.Entity<ExpenseAndSavingBag>()
            .Property(i => i.Percentage)
            .HasColumnType("DECIMAL(18,2)");

        builder.Entity<ExpenseAndSavingBag>()
            .Property(i => i.Value)
            .HasColumnType("DECIMAL(18,2)");

        builder.Entity<FinancialMovement>()
            .Property(i => i.Value)
            .HasColumnType("DECIMAL(18,2)");

        builder.Entity<IncomeMovement>()
            .Property(i => i.BalanceValue)
            .HasColumnType("DECIMAL(18,2)");

        builder.Entity<IncomeMovement>()
          .Property(i => i.ValueSaved)
          .HasColumnType("DECIMAL(18,2)");

        builder.Entity<SavingBagMovement>()
          .Property(i => i.ProposedValue)
          .HasColumnType("DECIMAL(18,2)");
        
        builder.Entity<SavingBagMovement>()
            .Property(i => i.BalanceValue)
            .HasColumnType("DECIMAL(18,2)");
        
        builder.Entity<SavingBagMovement>()
            .Property(i => i.Percentage)
            .HasColumnType("DECIMAL(18,2)");

  
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(builder);
    
}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("ConnectionString",
                b => b.MigrationsAssembly("FinanzasPersonales.Persistence"));
        }
    }

}


