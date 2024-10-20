using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Rms.Models.Entities.Identity;
using Rms.Models.Entities.Menues;
using Rms.Models.Entities.Operation;
using Rms.Models.Entities.Operation.RentBill;
using Rms.Models.Entities.Setup;
using Rms.Models.IdentityDto;
using Rms.Models.Request.Operation;
using Rms.Models.Request.Operation.RentBill;
using Rms.Models.Request.Setup;
using Rms.Models.ReturnDto.Menu;
using Rms.Models.ReturnDto.Operation;
using Rms.Models.ReturnDto.Setup;


namespace Rms.BLL.Abstraction;

public class ConfigureAutoMapper : Profile
{
    public static void Configure(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConfigureAutoMapper));//MappingProfiles
    }

    public ConfigureAutoMapper()
    {
        //user 
        CreateMap<UserCreateDto, User>();
        CreateMap<User, UserReturnDto>();

        //Global Setup
        CreateMap<GlobalSetupCreateOrUpdateDto, GlobalSetup>();
        CreateMap<GlobalSetup, GlobalSetupReturnDto>();

        //Complex
        CreateMap<ComplexCreateOrUpdateDto, Complex>();
        CreateMap<Complex, ComplexReturnDto>();


        //Customer
        CreateMap<CustomerCreateOrUpdateDto, Customer>();
        CreateMap<Customer, CustomerReturnDto>();

        //Menu
        CreateMap<Menu, MenuReturnDto>()
                    .ForMember(dest => dest.Submenu, opt => opt.MapFrom(src => src.Submenu != null && src.Submenu.Count > 0 ? src.Submenu : null));

        //EelectricBill
        CreateMap<ElectricBillCreateDto, ElectricBill>();
        CreateMap<ElectricBill, EelectricBillReturnDto>();

        //Bill Collection
        CreateMap<BillCollectionCreateDto, BillCollection>();
        //CreateMap<BillCollection, BillCollectionReturnDto>();

        //RentAndUtilityBill
        CreateMap<RentAndUtilityBillCreateDto, RentAndUtilityBill>();
        CreateMap<RentAndUtilityBillDetailCreateDto, RentAndUtilityBillDetail>();
        CreateMap<RentAndUtilityBill, RentAndUtilityBillReturnDto>();

        //EelectricBill
        CreateMap<UtilityBillCreateDto, UtilityBill>();
        //CreateMap<ElectricBill, EelectricBillReturnDto>();






    }

}
