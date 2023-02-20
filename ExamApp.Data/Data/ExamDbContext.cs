using Microsoft.EntityFrameworkCore;

namespace ExamApp.Data.Data;

public partial class ExamDbContext : DbContext
{
    public ExamDbContext()
    {
    }

    public ExamDbContext(DbContextOptions<ExamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("Data Source=---:1521/xe;Persist Security Info=True;User ID=AY;Password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("AY")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EXAMS_PK");

            entity.ToTable("EXAMS");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");
            entity.Property(e => e.ExamDate)
                .HasColumnType("DATE")
                .HasColumnName("EXAM_DATE");
            entity.Property(e => e.Grade)
                .HasPrecision(1)
                .HasColumnName("GRADE");
            entity.Property(e => e.LessonCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LESSON_CODE");
            entity.Property(e => e.StudentNo)
                .HasPrecision(5)
                .HasColumnName("STUDENT_NO");

            entity.HasOne(d => d.LessonCodeNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.LessonCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EXAMS_FK1");

            entity.HasOne(d => d.StudentNoNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.StudentNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EXAMS_FK2");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("LESSONS_PK");

            entity.ToTable("LESSONS");

            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CODE");
            entity.Property(e => e.Class)
                .HasPrecision(2)
                .HasColumnName("CLASS");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.TeacherName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEACHER_NAME");
            entity.Property(e => e.TeacherSurname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEACHER_SURNAME");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.No).HasName("STUDENTS_PK");

            entity.ToTable("STUDENTS");

            entity.Property(e => e.No)
                .HasPrecision(5)
                .ValueGeneratedNever()
                .HasColumnName("NO");
            entity.Property(e => e.Class)
                .HasPrecision(2)
                .HasColumnName("CLASS");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SURNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
