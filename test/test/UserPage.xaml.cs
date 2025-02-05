using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;
using test.models;
using Microsoft.EntityFrameworkCore;

namespace test
{
    public sealed partial class UserPage : Page
    {
        private AppDbContext _context = new AppDbContext();
        private User currentUser;
        private Book _selectedBook;

        public UserPage()
        {
            this.InitializeComponent();
            LoadBooks();
        }

        private void LoadBorrowedBooks()
        {
            var user = currentUser;
            var borrowedBooks = _context.BorrowedBooks
                .Where(bb => bb.UserId == user.Id && bb.ReturnDate == null)
                .Include(bb => bb.Book)
                .Select(bb => bb.Book)
                .ToList();

            BorrowedBookList.ItemsSource = borrowedBooks;
        }

        protected override void OnNavigatedTo(Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (e.Parameter is User user)
            {
                currentUser = user;
                LoadBorrowedBooks();
            }
        }
        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookList.SelectedItem;
        }
        private void ReturnBook_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var borrowedBook = button.DataContext as Book;
            if (borrowedBook == null) return;

            var user = currentUser;

            var borrowedBookEntry = _context.BorrowedBooks
                .FirstOrDefault(bb => bb.UserId == user.Id && bb.BookId == borrowedBook.Id && bb.ReturnDate == null);

            if (borrowedBookEntry != null)
            {
                borrowedBookEntry.ReturnDate = DateTime.Now;
                _context.BorrowedBooks.Update(borrowedBookEntry);

                var book = _context.Books.FirstOrDefault(b => b.Id == borrowedBook.Id);
                if (book != null)
                {
                    book.IsBorrowable = true;
                    _context.Books.Update(book);
                }

                _context.SaveChanges();

                LoadBooks();
                LoadBorrowedBooks();
            }
        }


        private void LoadBooks()
        {
            BookList.ItemsSource = _context.Books.Where(b => b.UserId == null && b.IsBorrowable == true).ToList();
        }


        private User GetLoggedInUser(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        private async void Borrow_click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null && currentUser != null)
            {
                var borrowedBook = new BorrowedBook
                {
                    BookId = _selectedBook.Id,
                    UserId = currentUser.Id,
                    ReturnDate = null
                };

                _context.BorrowedBooks.Add(borrowedBook);

                _selectedBook.IsBorrowable = false;
                _context.Books.Update(_selectedBook);

                await _context.SaveChangesAsync();

                LoadBooks();
                LoadBorrowedBooks();
            }
        }
    }
}
