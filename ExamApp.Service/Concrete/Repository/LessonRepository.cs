using ExamApp.Data.Data;
using ExamApp.Service.Abstract.Repository;

namespace ExamApp.Service.Concrete.Repository
{
    public class LessonRepository : Repository<Lesson,ExamDbContext>, ILessonRepository
    {
        public LessonRepository(IDbFactory<ExamDbContext> dbFactory) : base(dbFactory)
        {

        }
    }
}
