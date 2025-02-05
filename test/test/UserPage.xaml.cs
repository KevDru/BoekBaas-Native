    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using System;
    using System.Linq;
    using test.models;

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

            private void LoadBooks()
            {
                BookList.ItemsSource = _context.Books.Where(b => b.UserId == null).ToList();
            }

            private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                _selectedBook = (Book)BookList.SelectedItem;
            }

        private User GetLoggedInUser(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }


        private async void Borrow_click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null && currentUser != null)
            {
                
                _selectedBook.UserId = currentUser.Id;  
                _selectedBook.User = currentUser;       
                _selectedBook.IsBorrowed = true;        

                _context.Books.Update(_selectedBook);
                await _context.SaveChangesAsync(); 

                
                LoadBooks();  

                
            }
        }


    }
}
