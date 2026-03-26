using System;
using System.Collections.Generic;

namespace books.models;

public partial class Publisher
{
    public int Id { get; set; }

    public string? PublisherName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
