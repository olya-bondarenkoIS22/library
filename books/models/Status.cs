using System;
using System.Collections.Generic;

namespace books.models;

public partial class Status
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
