using System;
using System.Collections.Generic;

namespace HamzaProject.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Number { get; set; }

    public virtual ICollection<StudentBorrow> StudentBorrows { get; set; } = new List<StudentBorrow>();
}
