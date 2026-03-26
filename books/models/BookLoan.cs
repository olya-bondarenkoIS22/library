using books.models;
using System;
using System.Collections.Generic;

namespace books;

public partial class BookLoan
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdBook { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    public DateOnly? PlannedReturnDate { get; set; }

    public DateOnly? ActualReturnDate { get; set; }

    public int? IdStatus { get; set; }

    public virtual Book? IdBookNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
