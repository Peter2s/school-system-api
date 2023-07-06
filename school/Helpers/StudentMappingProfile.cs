using AutoMapper;
using school.Core.Models;
using school.Dtos.StudentDtos;

namespace school.Helpers
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<AddStudentDto, Student>()
                .ForMember(dest => dest.StudentPhoto, opt => opt.Ignore());
        }

    }
}
