using System;
using System.Collections.Generic;

namespace ExamApp.Data.Data;

public partial class Student
{
    public short No { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public byte? Class { get; set; }

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();
}
