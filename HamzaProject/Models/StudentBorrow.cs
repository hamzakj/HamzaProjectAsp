using System;
using System.Collections.Generic;

namespace HamzaProject.Models;

public partial class StudentBorrow
{
    public int Id { get; set; }

    public int? BookId { get; set; }

    public int? StudentId { get; set; }

    public byte? BookStatus { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Student? Student { get; set; }
}
