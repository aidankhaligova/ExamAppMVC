using ExamApp.Service.ViewModels.Lesson;

namespace ExamApp.Service.Abstract.Service
{
    public interface ILessonService
    {
        Task Create(LessonViewModel vm);
        Task Update(LessonViewModel vm);
        Task Delete(string code);
        Task<List<LessonViewModel>> GetAll();
        Task<LessonViewModel> GetByCode(string code);
    }
}
