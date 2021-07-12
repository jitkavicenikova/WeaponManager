using Microsoft.EntityFrameworkCore;
using WeaponManager.Models;

namespace WeaponManager.Data
{
    public class WeaponManagerDbContext : DbContext
    {
        public DbSet<ColdWeapon> ColdWeapons { get; set; }
        public DbSet<Firearm> Firearms { get; set; }
        public DbSet<Pistol> Pistols { get; set; }
        public DbSet<Rifle> Rifles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public WeaponManagerDbContext() : base()
        {
            Database.EnsureCreated();
        }
       
    }
}
