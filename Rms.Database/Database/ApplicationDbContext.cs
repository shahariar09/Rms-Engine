using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rms.Models.Common;
using Rms.Models.Common.Identity;
using Rms.Models.Entities.Identity;
using Rms.Models.Entities.Permissions;
using System.Reflection;
using Rms.Models.Entities.Menues;
using Rms.Models.DbModels.Views;
using Rms.Models.Entities.Setup;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Seed;
using System.Threading.Channels;


namespace Rms.Database.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IDateTime _dateTime;
        public ICurrentUser CurrentUserService { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUser cureCurrentUserService, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
            CurrentUserService = cureCurrentUserService;

        }


        //Setup
        public DbSet<GlobalSetup> GlobalSetups { get; set; }
        public DbSet<Complex> Complexs { get; set; }
        public DbSet<Customer> Customers { get; set; }


        //UserRole
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }




        //permission 
        public DbSet<PermissionModule> PermissionModules { get; set; }
        public DbSet<PermissionFeature> PermissionFeatures { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RoleFeaturePermission> RoleFeaturePermissions { get; set; }

        //Menu
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }

        //Operations
        public DbSet<ElectricBill> ElectricBills { get; set; }
        public DbSet<BillCollection> BillCollections { get; set; }
        public DbSet<GassBill> GassBills { get; set; }
        public DbSet<WaterBill> WaterBills { get; set; }
        public DbSet<RentAndUtilityBill> RentAndUtilityBills { get; set; }
        public DbSet<RentAndUtilityBillDetail> RentAndUtilityBillDetails { get; set; }
        public DbSet<UtilityBill> UtilityBills { get; set; }
        


        //View
        public DbSet<ElectricBillSummaryView> ElectricBillSummariesView { get; set; }
        public DbSet<RentAnUtilityBillSummaryView> RentAnUtilityBillSummariesView { get; set; }
        public DbSet<CusotmerWithServiceBillView> CusotmerWithServiceBillsView { get; set; }
        public DbSet<UtilityBillSummaryView> UtilityBillSummariesView { get; set; }
        


        //CpanelSeed See
        public DbSet<CpanelSeed> CpanelSeeds { get; set; }











        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:


                        entry.Entity.CreatedById = (string.IsNullOrEmpty(CurrentUserService.UserId) || CurrentUserService.UserId == "0") ? entry.Entity.CreatedById == null ? 0 : entry.Entity.CreatedById : long.Parse(CurrentUserService.UserId);
                        entry.Entity.CreatedOn = _dateTime.Now.AddHours(4);
                        //entry.Entity.UpdatedById = (string.IsNullOrEmpty(CurrentUserService.UserId) || CurrentUserService.UserId == "0") ? entry.Entity.CreatedById == null ? 0 : entry.Entity.CreatedById : long.Parse(CurrentUserService.UserId);
                        //entry.Entity.UpdatedOn = _dateTime.Now.AddHours(4);
                        entry.CurrentValues["IsSoftDelete"] = false;

                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedById = string.IsNullOrEmpty(CurrentUserService.UserId) ? 0 : long.Parse(CurrentUserService.UserId);
                        entry.Entity.UpdatedOn = _dateTime.Now.AddHours(4);
                        entry.Property(e => e.CreatedOn).IsModified = false;
                        entry.Property(e => e.CreatedById).IsModified = false;
                        //entry.CurrentValues["IsSoftDelete"] = false;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsSoftDelete"] = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = long.Parse(CurrentUserService.UserId);
                        entry.Entity.CreatedOn = _dateTime.Now.AddHours(4);
                        //entry.Entity.UpdatedById = long.Parse(CurrentUserService.UserId);
                        //entry.Entity.UpdatedOn = _dateTime.Now.AddHours(4);
                        entry.CurrentValues["IsSoftDelete"] = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedById = long.Parse(CurrentUserService.UserId);
                        entry.Entity.UpdatedOn = _dateTime.Now.AddHours(4);
                        entry.CurrentValues["IsSoftDelete"] = false;
                        entry.Property(e => e.CreatedOn).IsModified = false;
                        entry.Property(e => e.CreatedById).IsModified = false;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsSoftDelete"] = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return base.SaveChanges();
        }

        public int HardDeleteChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<VW_Product>().HasNoKey().ToView("VW_Product");

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd(); // Configure identity
            });

            modelBuilder.Entity<UserMenu>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd(); // Configure identity
            });

            modelBuilder.Entity<RentAndUtilityBillDetail>()
                   .HasOne(d => d.RentAndUtilityBill)
                   .WithMany(p => p.RentAndUtilityBillDetails)
                   .HasForeignKey(d => d.RentAndUtilityBillId)
                   .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RentAndUtilityBill>()
                   .HasOne(bill => bill.Customer)
                   .WithMany() // Assuming there is no collection in the Customer entity
                   .HasForeignKey(bill => bill.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = SetGlobalQueryFilterMethod.MakeGenericMethod(entityType.ClrType);
                    method.Invoke(this, new object[] { modelBuilder });
                }
            }

            modelBuilder.Entity<ElectricBillSummaryView>()
            .HasNoKey() 
            .ToView("VW_ElectricBillSummary");

            modelBuilder.Entity<RentAnUtilityBillSummaryView>()
          .HasNoKey()
          .ToView("VW_RentAndUtilityBillSummary");

            modelBuilder.Entity<CusotmerWithServiceBillView>()
          .HasNoKey()
          .ToView("VW_CusotmerWithServiceBill");

            modelBuilder.Entity<UtilityBillSummaryView>()
          .HasNoKey()
          .ToView("VW_UtilityBillSummary");

            






            base.OnModelCreating(modelBuilder);

        }


        private static readonly MethodInfo SetGlobalQueryFilterMethod = typeof(ApplicationDbContext)
        .GetMethod(nameof(SetGlobalQueryFilter), BindingFlags.NonPublic | BindingFlags.Static);

        private static void SetGlobalQueryFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : AuditableEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsSoftDelete);
        }


    }
}
