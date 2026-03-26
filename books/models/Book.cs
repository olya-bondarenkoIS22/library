using books.models;
using System;
using System.Collections.Generic;

namespace books;

public partial class Book
{
    public int Id { get; set; }

    public string Isbn { get; set; } = null!;

    public string? BookName { get; set; }

    public int IdAuthor { get; set; }

    public int IdGenre { get; set; }

    public int IdPublisher { get; set; }

    public int? Year { get; set; }

    public int? Pages { get; set; }

    public int? Total { get; set; }

    public int? Avaiable { get; set; }

    public string? Annotation { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;

    public virtual Publisher IdPublisherNavigation { get; set; } = null!;
}
