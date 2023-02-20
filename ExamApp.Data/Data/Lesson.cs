using System;
using System.Collections.Generic;

namespace ExamApp.Data.Data;

public partial class Lesson
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public byte? Class { get; set; }

    public string? TeacherName { get; set; }

    public string? TeacherSurname { get; set; }

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();
}
