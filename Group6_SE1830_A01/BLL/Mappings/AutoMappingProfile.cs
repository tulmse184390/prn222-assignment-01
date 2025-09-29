using AutoMapper;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Mappings
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Inventory, ViewInventory>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Version.Model.ModelName))
                .ForMember(dest => dest.VersionName, opt => opt.MapFrom(src => src.Version.VersionName))
                .ForMember(dest => dest.RangeKm, opt => opt.MapFrom(src => src.Version.RangeKm))
                .ForMember(dest => dest.Seat, opt => opt.MapFrom(src => src.Version.Seat))
                .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.Version.BasePrice))
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.ColorName));

            CreateMap<OrderDetail, ViewOrderDetail>()
                .ForMember(dest => dest.VersionName, opt => opt.MapFrom(src => src.Version.VersionName))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Version.Model.ModelName))
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.ColorName));

            CreateMap<Order, ViewOrder>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.FullName))
                .ForMember(dest => dest.ViewOrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.OrderDetails.Sum(x => x.FinalPrice)));

            CreateMap<Order, ViewConfirmOrder>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.FullName))
                .ForMember(dest => dest.ViewOrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.OrderDetails.Sum(x => x.FinalPrice)));

            CreateMap<TestDriveAppointment, ViewTestDriveAppointment>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.VersionName, opt => opt.MapFrom(src => src.CarVersion.VersionName))
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.ColorName));

            CreateMap<CreateTestDriveAppointment, TestDriveAppointment>();

            CreateMap<Customer, ViewCustomer>();

            CreateMap<ViewCustomerCreate, Customer>();

            CreateMap<ViewCustomerEdit, Customer>();
        }
    }
}
