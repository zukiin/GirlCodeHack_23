using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using she_innovates.Models;

namespace she_innovates.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Post> Posts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

