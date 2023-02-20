using ExamApp.Data.Data;
using ExamApp.Service.Abstract.Repository;

namespace ExamApp.Service.Concrete.Repository
{
    public class StudentRepository : Repository<Student, ExamDbContext>, IStudentRepository
    {
        public StudentRepository(IDbFactory<ExamDbContext> dbFactory) : base(dbFactory)
        {

        }
    }
}
