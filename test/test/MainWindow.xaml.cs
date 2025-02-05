using System;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using test.models;

namespace test
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context = new AppDbContext();

        public MainWindow()
        {
            InitializeComponent();
            _context.Database.EnsureCreated();
        }

        // Login Button Click Event
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsername.Text.Trim();
            string password = LoginPassword.Password;

            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                

                if (username == "admin")
                {
                    MainFrame.Navigate(typeof(AdminPage));
                }
                else
                {
                    LoginStatus.Text = "Login successful!";
                    LoginStatus.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Green);
                    LoginStatus.Visibility = Visibility.Visible;
                    MainFrame.Navigate(typeof(UserPage));
                }
            }
            else
            {
                LoginStatus.Text = "Invalid username or password!";
                LoginStatus.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
                LoginStatus.Visibility = Visibility.Visible;
            }
        }



        // Register Button Click Event
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = RegisterUsername.Text.Trim();
            string password = RegisterPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                RegisterStatus.Text = "Username and password cannot be empty.";
                RegisterStatus.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
                RegisterStatus.Visibility = Visibility.Visible;
                return;
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                RegisterStatus.Text = "Username already exists!";
                RegisterStatus.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
                RegisterStatus.Visibility = Visibility.Visible;
                return;
            }

            _context.Users.Add(new User { Username = username, Password = password });
            _context.SaveChanges();

            RegisterStatus.Text = "Registration successful! You can now log in.";
            RegisterStatus.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Green);
            RegisterStatus.Visibility = Visibility.Visible;

            SwitchToLogin();
        }

        // Switch to Register Page
        private void SwitchToRegister_Click(object sender, RoutedEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Collapsed;
            RegisterPanel.Visibility = Visibility.Visible;
            LoginStatus.Visibility = Visibility.Collapsed;
        }

        // Switch to Login Page
        private void SwitchToLogin_Click(object sender, RoutedEventArgs e)
        {
            SwitchToLogin();
        }

        private void SwitchToLogin()
        {
            RegisterPanel.Visibility = Visibility.Collapsed;
            LoginPanel.Visibility = Visibility.Visible;
            RegisterStatus.Visibility = Visibility.Collapsed;
        }
    }
}
