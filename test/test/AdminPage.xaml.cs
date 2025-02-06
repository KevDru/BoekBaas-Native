using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using test.models;
using System;

namespace test
{
    public sealed partial class AdminPage : Page
    {
        private readonly AppDbContext _context = new AppDbContext();
        private Book _selectedBook;

        public AdminPage()
        {
            this.InitializeComponent();
            LoadGenres();
            LoadBooks();
        }

        private void LoadBooks()
        {
            BookList.ItemsSource = _context.Books.Include(b => b.Genre).ToList();
        }

        private void LoadGenres()
        {
            GenreComboBox.ItemsSource = _context.Genres.ToList();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text.Trim();
            string author = AuthorInput.Text.Trim();

            if (!string.IsNullOrWhiteSpace(title) &&
                !string.IsNullOrWhiteSpace(author) &&
                GenreComboBox.SelectedItem != null)
            {
                int year = YearInput.Date.Year;
                Genre selectedGenre = (Genre)GenreComboBox.SelectedItem;

                _context.Books.Add(new Book
                {
                    Title = title,
                    Author = author,
                    publication_year = year,
                    GenreId = selectedGenre.Id,
                    ISBN = ISBNInput.Text.Trim()
                });

                _context.SaveChanges();
                LoadBooks();
            }
        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookList.SelectedItem;
            if (_selectedBook != null)
            {
                TitleInput.Text = _selectedBook.Title;
                AuthorInput.Text = _selectedBook.Author;
                YearInput.Date = new DateTime(_selectedBook.publication_year, 1, 1);
                ISBNInput.Text = _selectedBook.ISBN;
                GenreComboBox.SelectedItem = _selectedBook.Genre;
            }
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null)
            {
                _selectedBook.Title = TitleInput.Text.Trim();
                _selectedBook.Author = AuthorInput.Text.Trim();
                int year = YearInput.Date.Year;
                _selectedBook.publication_year = year;
                _selectedBook.ISBN = ISBNInput.Text.Trim();
                _selectedBook.GenreId = ((Genre)GenreComboBox.SelectedItem).Id;
                _selectedBook.IsBorrowable = Borrowable.IsChecked ?? false;

                _context.Books.Update(_selectedBook);
                _context.SaveChanges();
                LoadBooks();
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null)
            {
                _context.Books.Remove(_selectedBook);
                _context.SaveChanges();
                LoadBooks();
                TitleInput.Text = "";
                AuthorInput.Text = "";
                YearInput.Date = new DateTimeOffset();
                ISBNInput.Text = "";
                GenreComboBox.SelectedItem = null;
            }
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            string genreName = GenreNameInput.Text.Trim();

            if (!string.IsNullOrWhiteSpace(genreName))
            {
                _context.Genres.Add(new Genre { Name = genreName });
                _context.SaveChanges();
                LoadGenres();
                GenreNameInput.Text = "";
            }
        }
    }
}
