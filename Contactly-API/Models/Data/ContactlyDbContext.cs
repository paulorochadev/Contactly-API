using Microsoft.EntityFrameworkCore;

namespace Contactly_API.Models.Data
{
    public class ContactlyDbContext : DbContext
    {
        public ContactlyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
