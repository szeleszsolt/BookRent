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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookRentProg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainPage = new MainPage();
        }
        private MainPage mainPage;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
            mainPage.BTN_New.Click += BTN_New_Click;
            mainPage.BTN_Edit.Click += BTN_Edit_Click;
            mainPage.BTN_Delete.Click += BTN_Delete_Click;
            
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            var page = new EditBookPage();
            MainFrame.Content = page;
            page.BTN_Cancel.Click += EditBookPage_BTN_Cancel_Click;
        }

        private void BTN_Edit_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BTN_New_Click(object sender, RoutedEventArgs e)
        {
            var page = new EditBookPage();
            MainFrame.Content = page;
            page.BTN_Cancel.Click += EditBookPage_BTN_Cancel_Click;
        }

        private void EditBookPage_BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
        }
    }
}
