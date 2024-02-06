using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Code1stUsersRoles.Data;

public class SeedUsersRoles
{
    private readonly List<IdentityRole> _roles;
    private readonly List<IdentityUser> _users;
    private readonly List<IdentityUserRole<string>> _userRoles;
    public SeedUsersRoles()
    {
        _roles = GetRoles();
        _users = GetUsers();
        _userRoles = GetUserRoles(_users, _roles);
    }

    public List<IdentityRole> Roles { get { return _roles; } }
    public List<IdentityUser> Users { get { return _users; } }
    public List<IdentityUserRole<string>> UserRoles { get { return _userRoles; } }

    private List<IdentityRole> GetRoles()
    {

        // Seed Roles
        var adminRole = new IdentityRole("Admin");
        adminRole.NormalizedName = adminRole.Name!.ToUpper();

        var memberRole = new IdentityRole("Member");
        memberRole.NormalizedName = memberRole.Name!.ToUpper();

        List<IdentityRole> roles = new List<IdentityRole>() {
           adminRole,
           memberRole
        };

        return roles;
    }

    private List<IdentityUser> GetUsers()
    {

        string pwd = "P@$$w0rd";
        var passwordHasher = new PasswordHasher<IdentityUser>();

        // Seed Users
        var adminUser = new IdentityUser
        {
            UserName = "aa@aa.aa",
            Email = "aa@aa.aa",
            EmailConfirmed = true,
        };
        adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
        adminUser.NormalizedEmail = adminUser.Email.ToUpper();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

        var memberUser = new IdentityUser
        {
            UserName = "mm@mm.mm",
            Email = "mm@mm.mm",
            EmailConfirmed = true,
        };
        memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
        memberUser.NormalizedEmail = memberUser.Email.ToUpper();
        memberUser.PasswordHash = passwordHasher.HashPassword(memberUser, pwd);

        List<IdentityUser> users = new List<IdentityUser>() {
           adminUser,
           memberUser,
        };

        return users;
    }

    private List<IdentityUserRole<string>> GetUserRoles(List<IdentityUser> users, List<IdentityRole> roles)
    {
        // Seed UserRoles
        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[0].Id,
            RoleId = roles.First(q => q.Name == "Admin").Id
        });

        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[1].Id,
            RoleId = roles.First(q => q.Name == "Member").Id
        });

        return userRoles;
    }
}