using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Code1stUsersRoles.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Use seed method here
        SeedUsersRoles seedUsersRoles = new();
        builder.Entity<IdentityRole>().HasData(seedUsersRoles.Roles);
        builder.Entity<IdentityUser>().HasData(seedUsersRoles.Users);
        builder.Entity<IdentityUserRole<string>>().HasData(seedUsersRoles.UserRoles);
    }
}
