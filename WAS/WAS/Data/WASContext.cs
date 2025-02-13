using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WAS.Data;

namespace WAS.Data
{
    public class WASContext(DbContextOptions<WASContext> options) : IdentityDbContext<AppUser>(options)
    {
    }
}
