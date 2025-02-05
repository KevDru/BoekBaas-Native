using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using test.models;

namespace test
{
    public sealed partial class AdminPage : Page
    {
        private readonly AppDbContext _context = new AppDbContext();
        private Book _selectedBook;  // Stores the selected book for updates/deletes

        public AdminPage()
        {
            this.InitializeComponent();
            LoadGenres();  // Load genres when the page is initialized
            LoadBooks();   // Load books into the list
        }

        // Load books into the ListView
        private void LoadBooks()
        {
            BookList.ItemsSource = _context.Books.Include(b => b.Genre).ToList();
        }

        // Load genres into the ComboBox
        private void LoadGenres()
        {
            GenreComboBox.ItemsSource = _context.Genres.ToList();
        }

        // Add Book
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text.Trim();
            string author = AuthorInput.Text.Trim();
            int year;

            // Make sure required fields are not empty
            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author) && int.TryParse(YearInput.Text, out year) && GenreComboBox.SelectedItem != null)
            {
                Genre selectedGenre = (Genre)GenreComboBox.SelectedItem;
                _context.Books.Add(new Book { Title = title, Author = author, publication_year = year, GenreId = selectedGenre.Id, ISBN = ISBNInput.Text.Trim() });
                _context.SaveChanges();
                LoadBooks();  // Refresh the book list
            }
            else
            {
                // Handle validation errors
                // For example, show a message to the user saying fields can't be empty or invalid
            }
        }

        // Select Book from ListView
        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookList.SelectedItem;
            if (_selectedBook != null)
            {
                TitleInput.Text = _selectedBook.Title;
                AuthorInput.Text = _selectedBook.Author;
                YearInput.Text = _selectedBook.publication_year.ToString();
                ISBNInput.Text = _selectedBook.ISBN;
                GenreComboBox.SelectedItem = _selectedBook.Genre;
            }
        }

        // Update Selected Book
        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null)
            {
                _selectedBook.Title = TitleInput.Text.Trim();
                _selectedBook.Author = AuthorInput.Text.Trim();
                int.TryParse(YearInput.Text, out int year);
                _selectedBook.publication_year = year;
                _selectedBook.ISBN = ISBNInput.Text.Trim();
                _selectedBook.GenreId = ((Genre)GenreComboBox.SelectedItem).Id;

                _context.Books.Update(_selectedBook);
                _context.SaveChanges();
                LoadBooks();  // Refresh the book list
            }
        }

        // Delete Selected Book
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null)
            {
                _context.Books.Remove(_selectedBook);
                _context.SaveChanges();
                LoadBooks();  // Refresh the book list
                TitleInput.Text = "";
                AuthorInput.Text = "";
                YearInput.Text = "";
                ISBNInput.Text = "";
                GenreComboBox.SelectedItem = null;
            }
        }

        // Add Genre
        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            string genreName = GenreNameInput.Text.Trim();

            // Ensure genre name is not empty
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
