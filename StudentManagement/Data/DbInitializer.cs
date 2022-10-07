using Microsoft.AspNetCore.Identity;

namespace StudentManagement.Data;

internal class DbInitializer
{
    public static void Initialize(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        dbContext.Database.EnsureCreated();

        if (dbContext.Roles.Any())
            return;

        var roles = new IdentityRole[]
        {
            new IdentityRole { Name = "Student", NormalizedName = "STUDENT" },
            new IdentityRole { Name = "Teacher", NormalizedName = "TEACHER" },
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
        };

        foreach (var role in roles)
        {
            dbContext.Roles.Add(role);
        }

        dbContext.SaveChanges();
        
        if (dbContext.Users.Any())
            return;

        var admin = Activator.CreateInstance<IdentityUser>();
        admin.Email = "admin@admin.com";
        admin.EmailConfirmed = true;

        userManager.CreateAsync(admin, "Secret1!");

        userManager.AddToRoleAsync(admin, "Admin");
    }
}