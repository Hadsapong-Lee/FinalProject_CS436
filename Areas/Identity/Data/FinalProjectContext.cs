using FinalProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Data;

public class FinalProjectContext : IdentityDbContext<FinalProjectUser>
{
    public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var admin = new IdentityRole("admin");
        admin.NormalizedName = "admin";

        var department = new IdentityRole("department");
        department.NormalizedName = "department";

        var warehouse = new IdentityRole("warehouse");
        warehouse.NormalizedName = "warehouse";

        builder.Entity<IdentityRole>().HasData(admin, department, warehouse);
        builder.ApplyConfiguration(new FinalProjectUserEntityConfiguration());
    }
}

public class FinalProjectUserEntityConfiguration: IEntityTypeConfiguration<FinalProjectUser> 
{ 
    public void Configure(EntityTypeBuilder<FinalProjectUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.MobilePhone).HasMaxLength(255);
    }
}