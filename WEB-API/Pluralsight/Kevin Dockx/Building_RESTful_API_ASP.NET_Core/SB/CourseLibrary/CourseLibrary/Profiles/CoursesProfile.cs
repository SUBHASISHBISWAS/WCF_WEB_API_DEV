using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.Models;

namespace CourseLibrary.Profiles
{
    public class CoursesProfile :Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
