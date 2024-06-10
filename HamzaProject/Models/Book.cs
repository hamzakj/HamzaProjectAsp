using System;
using System.Collections.Generic;

namespace HamzaProject.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StudentBorrow> StudentBorrows { get; set; } = new List<StudentBorrow>();
}
