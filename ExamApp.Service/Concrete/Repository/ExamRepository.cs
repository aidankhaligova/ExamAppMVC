using ExamApp.Data.Data;
using ExamApp.Service.Abstract.Repository;

namespace ExamApp.Service.Concrete.Repository
{
    public class ExamRepository : Repository<Exam, ExamDbContext>, IExamRepository
    {
        public ExamRepository(IDbFactory<ExamDbContext> dbFactory) : base(dbFactory)
        {

        }
    }
}
