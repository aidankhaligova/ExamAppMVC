using ExamApp.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace ExamApp.Data
{
    public interface IExamDbContext
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task<int> SaveChangesAsync();
        int Save();
        EntityEntry<T> Entry<T>([NotNull] T t) where T : class;
        DbSet<T> GetDbSet<T>() where T : class;
        DbSet<Exam> Exams { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Student> Students { get; set; }
    }
}
