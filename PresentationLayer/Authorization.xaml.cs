using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : MetroWindow
    {
        bool logHasErr;
        bool passHasErr;
         public string Log { get; set; }
        public string Pass { get; set; }
        public Authorization()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                DialogResult = true;
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Somthing wrong! Make sure that your login and pass is correct!\n" +
                    "REMEMBER you must enable imap protocol in your mailbox!\n" +
                    "If u use gmail - forward that lik and enable checkbox. - https://myaccount.google.com/lesssecureapps?utm_source=google-account&utm_medium=web");
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                LoginError.Text = "Empty login";
                logHasErr = true;
            }
            else if (((sender as TextBox).Text).IndexOf('@') <= 0)
            {
                LoginError.Text = @"The email must contain '@' symbol";
                logHasErr = true;
            }
            else
            {
                logHasErr = false;
                Log = (sender as TextBox).Text;
            }

            LoginError.Visibility = (logHasErr) ? Visibility.Visible : Visibility.Collapsed;
            ButtonTrigger();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as PasswordBox).Password.Length == 0)
            {
                PassError.Text = "Empty password";
                passHasErr = true;
            }
            else if (((sender as PasswordBox).Password).IndexOf(' ') >= 0)
            {
                PassError.Text = @"Delete spaces from password field";
                passHasErr = true;
            }
            else
            {
                passHasErr = false;
                Pass = (sender as PasswordBox).Password;
            }

            PassError.Visibility = (passHasErr) ? Visibility.Visible : Visibility.Collapsed;
            ButtonTrigger();
        }

        void ButtonTrigger()
        {
            Confirm.IsEnabled = (logHasErr || passHasErr) ? false : true;
        }

    }
}
