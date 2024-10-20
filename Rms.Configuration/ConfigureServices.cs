using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rms.BLL.Abstraction.Identity;
using Rms.BLL.Abstraction.Menus;
using Rms.BLL.Abstraction.Operation;
using Rms.BLL.Abstraction.Setup;
using Rms.BLL.Identity;
using Rms.BLL.Menus;
using Rms.BLL.Operation;
using Rms.BLL.Setup;
using Rms.Configuration.Services;
using Rms.Database.Database;
using Rms.Models.Common;
using Rms.Models.Common.Identity;
using Rms.Repo.Abstraction.Identity;
using Rms.Repo.Abstraction.Menus;
using Rms.Repo.Abstraction.Operation;
using Rms.Repo.Abstraction.Setup;
using Rms.Repo.Identity;
using Rms.Repo.Menus;
using Rms.Repo.Operation;
using Rms.Repo.Setup;


namespace Rms.Configuration
{
    public static class ConfigureServices
    {
        public static void Configure(IServiceCollection services, IConfiguration configruation)
        {
            //DbConnection
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configruation.GetConnectionString("DefaultConnection")));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUser, CurrentUserService>();
            services.AddScoped<IDateTime, DateTimeService>();


            //User
            services.AddTransient<IUserRoleManager, UserRoleManager>();
            services.AddTransient<IUserRoleRepo, UserRoleRepo>();

            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IUserRepository, UserRepository>();

            
            //Role
            services.AddTransient<IRoleMenuManager, RoleMenuManager>();
            services.AddTransient<IRoleMenuRepo, RoleMenuRepo>();

            //User
            services.AddTransient<IUserMenuManager, UserMenuManager>();
            services.AddTransient<IUserMenuRepo, UserMenuRepository>();

            //Menu
            services.AddTransient<IMenuManager, MenuManager>();
            services.AddTransient<IMenuRepository, MenuRepository>();

            //Customer
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            //Complex
            services.AddTransient<IComplexManager, ComplexManager>();
            services.AddTransient<IComplexRepository, ComplexRepository>();

            //GlobalSetup
            services.AddTransient<IGlobalSetupManager, GlobalSetupManager>();
            services.AddTransient<IGlobalSetupRepository, GlobalSetupRepository>();

            //Operation
            //Electric Bill 
            services.AddTransient<IElectricBillManager, ElectricBillManager>();
            services.AddTransient<IElectricBillRepository, ElectricBillRepository>();

            //Bill Collection
            services.AddTransient<IBillCollectionManager, BillCollectionManager>();
            services.AddTransient<IBillCollectionRepository, BillCollectionRepository>();

            //Rent Bill
            services.AddTransient<IRentBillManager, RentBillManager>();
            services.AddTransient<IRentBillRepository, RentBillRepository>();

            //Utility Bill
            services.AddTransient<IUtilityBillManager, UtilityBillManager>();
            services.AddTransient<IUtilityBillRepository, UtilityBillRepository>();

            //Common Operation
            services.AddTransient<ICommonOperaionManager, CommonOperaionManager>();
            services.AddTransient<ICommonOperaionRepository, CommonOperaionRepository>();
            

        }
    }
}
