using AutoMapper;
using ExamApp.Data.Data;
using ExamApp.Service.ViewModels.Exam;
using ExamApp.Service.ViewModels.Lesson;
using ExamApp.Service.ViewModels.Student;

namespace ExamApp.Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LessonViewModel, Lesson>().ReverseMap();
            CreateMap<StudentViewModel, Student>().ReverseMap();
            CreateMap<ExamViewModel, Exam>();
            CreateMap<Exam, ExamViewModel>()
                .ForMember(vm => vm.LessonName, x => x.MapFrom(entity => entity.LessonCodeNavigation.Name))
                .ForMember(vm => vm.StudentFullname, x => x.MapFrom(entity => entity.StudentNoNavigation.Name + " " + entity.StudentNoNavigation.Surname));
            CreateMap<CreateExamViewModel, Exam>();
        }
    }
}
