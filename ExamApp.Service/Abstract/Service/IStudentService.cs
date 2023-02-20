using ExamApp.Service.ViewModels.Student;

namespace ExamApp.Service.Abstract.Service
{
    public interface IStudentService
    {
        Task Create(StudentViewModel vm);
        Task Update(StudentViewModel vm);
        Task Delete(short no);
        Task<List<StudentViewModel>> GetAll();
        Task<StudentViewModel> GetByNo(short no);
    }
}
