using System;
using System.Collections.Generic;

namespace books.models;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string? FullName { get; set; }

    public string? LibraryCard { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
