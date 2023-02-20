using System;
using System.Collections.Generic;

namespace ExamApp.Data.Data;

public partial class Exam
{
    public string LessonCode { get; set; } = null!;

    public short StudentNo { get; set; }

    public DateTime? ExamDate { get; set; }

    public bool? Grade { get; set; }

    public int Id { get; set; }

    public virtual Lesson LessonCodeNavigation { get; set; } = null!;

    public virtual Student StudentNoNavigation { get; set; } = null!;
}
