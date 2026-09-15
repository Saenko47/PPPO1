using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task2.Models;
using PaterniLab1.Task2.Models.Almanacs;
using PaterniLab1.Task2.Models.Amanacs;
using PaterniLab1.Task2.Models.Books;
using PaterniLab1.Task2.Models.Newspapers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Data
{
    internal class AppDBContextTask2:DbContext
    {
        public AppDBContextTask2(DbContextOptions<AppDBContextTask2> options) : base(options) { }


        public DbSet<BaseLibraryItem> LibraryItems { get; set; }

        //Book segment
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BooksOfAuthors { get; set; }

        //Newspapers segment
        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<Journalist> Journalists { get; set; }
        public DbSet<NewspaperColumn> NewsPaperColumns { get; set; }
        public DbSet<ColumnJournalist> ColumsJournalist { get; set; }

        //Almanac segemnt
        public DbSet<Almanac> Almanacs { get; set; }
        public DbSet<BookAlmanac> BooksAlmanacs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

       
            modelBuilder.Entity<BaseLibraryItem>().ToTable("LibraryItems");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Newspaper>().ToTable("Newspapers");
            modelBuilder.Entity<Almanac>().ToTable("Almanacs");

          
            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasOne(ba => ba.Author)
                      .WithMany(a => a.BooksOfAuthor)
                      .HasForeignKey(ba => ba.AuthorId);

                entity.HasOne(ba => ba.Book)
                      .WithMany()
                      .HasForeignKey(ba => ba.BookId);
            });

         
            modelBuilder.Entity<ColumnJournalist>(entity =>
            {
                entity.HasOne(jc => jc.Journalist)
                      .WithMany(j => j.ColumsOfThisJournalist)
                      .HasForeignKey(jc => jc.JournalistId);

                entity.HasOne(jc => jc.NewspaperColumn)
                      .WithMany()
                      .HasForeignKey(jc => jc.NewspaperColumnId);
            });

           
            modelBuilder.Entity<BookAlmanac>(entity =>
            {
                entity.HasOne(ba => ba.Almanac)
                      .WithMany(a => a.BooksInAlmanac)
                      .HasForeignKey(ba => ba.AlmanacId);

                entity.HasOne(ba => ba.Book)
                      .WithMany()
                      .HasForeignKey(ba => ba.BookId);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=appTask2.db");
            }
        }
    }
}
