using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HC_MIS.Models;
namespace HC_MIS.Data
{
    public class HC_DbContext : IdentityDbContext<ApplicationUser>
    {
        public HC_DbContext(DbContextOptions<HC_DbContext> options)
            : base(options)
        {
        }
        public DbSet<hc_dev> hc_development { get; set; }
        public virtual DbSet<Hflist> HFList { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public DbSet<hc_dgoffice> hc_dgoffice { get; set; }
        public DbSet<hc_hfAcknowledge> hc_hfAcknowledge { get; set; }
        public DbSet<hc_ackStatus> hc_ackStatus { get; set; }
        public DbSet<hc_hfbankdetails> hc_hfbankdetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "phs_User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "phs_Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("phs_UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("phs_UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("phs_UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("phs_RoleClaims");

            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("phs_UserTokens");
            });
        }
    }
}