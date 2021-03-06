using AutoMapper;
using DataAccess.Data;
using DatabaseAccess.Data;
using Models;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KidDTO, Kid>();
            CreateMap<Kid, KidDTO>();

            CreateMap<KidImage, KidImageDTO>().ReverseMap();

            CreateMap<KgFacility, KgFacilityDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<KidComment, KidCommentDTO>().ReverseMap();
        }
    }
}
