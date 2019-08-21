using AutoMapper;
using OutXApp.Core.Dto;
using OutXApp.Core.Models;
using OutXApp.Core.Repositories;

namespace OutXApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Course, CourseDto>();
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<Specialization, SpecializationDto>();
            //Mapper.CreateMap<DoctorFormViewModel, Doctor>();
        }
    }
}