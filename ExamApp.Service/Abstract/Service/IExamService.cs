using ExamApp.Service.ViewModels.Exam;

namespace ExamApp.Service.Abstract.Service
{
    public interface IExamService
    {
        Task Create(CreateExamViewModel vm);
        Task Update(ExamViewModel vm);
        Task Delete(int id);
        Task<List<ExamViewModel>> GetAll();
        Task<ExamViewModel> GetById(int id);
    }
}
