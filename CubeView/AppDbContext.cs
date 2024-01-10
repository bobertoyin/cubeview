namespace CubeView;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<CubeReviewer>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}


