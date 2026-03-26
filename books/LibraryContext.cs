using System;
using System.Collections.Generic;
using books.models;
using Microsoft.EntityFrameworkCore;

namespace books;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookLoan> BookLoans { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=library;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("author_pkey");

            entity.ToTable("authors");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('author_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.AuthorName).HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Annotation).HasColumnName("annotation");
            entity.Property(e => e.Avaiable).HasColumnName("avaiable");
            entity.Property(e => e.BookName).HasColumnName("book_name");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdGenre).HasColumnName("id_genre");
            entity.Property(e => e.IdPublisher).HasColumnName("id_publisher");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_books_authors");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_books_genres");

            entity.HasOne(d => d.IdPublisherNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublisher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_books_publishers");
        });

        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_loans2_pkey");

            entity.ToTable("book_loans");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('book_loans2_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.ActualReturnDate).HasColumnName("actual_return_date");
            entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.PlannedReturnDate).HasColumnName("planned_return_date");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("fk_book_loans_book");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("fk_book_loans_status");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_book_loans_users");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreName).HasColumnName("genre_name");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publishers_pkey");

            entity.ToTable("publishers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PublisherName).HasColumnName("publisher_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.LibraryCard).HasColumnName("library_card");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
