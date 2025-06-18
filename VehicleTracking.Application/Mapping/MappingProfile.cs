
using AutoMapper;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Domain.Entities;

namespace VehicleTracking.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceCommand, DeviceCommandDto>();
            CreateMap<Driver, DriverDto>();
            CreateMap<Vehicle, VehicleDto>();
        }
    }
}
