using Microsoft.EntityFrameworkCore;
using HATC.Models;

namespace HATC.Data
{
    public class HavenDbContext : DbContext
    {
        public HavenDbContext(
     DbContextOptions<HavenDbContext> options) : base(options) { }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<SessionItem> SessionItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}