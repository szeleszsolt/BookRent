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
            if(mainPage.LB_Books.SelectedIndex != null)
            {
                var result = MessageBox.Show("Biztos, hogy törölni kívánja a kiválasztott elemet?", "Törlés...", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    mainPage.LB_Books.Items.Remove(mainPage.LB_Books.SelectedItem);
                }
            }
        }

        private void BTN_Edit_Click(object sender, RoutedEventArgs e)
        {
            if(mainPage.LB_Books.SelectedItem != null)
            {
                var book = (Book)mainPage.LB_Books.SelectedItem;
                var page = new EditBookPage();
                page.TB_Author.Text = book.Author;
                page.TB_Title.Text = book.Title;
                page.TB_Type.Text = book.Type;
                page.DP_Publish.SelectedDate = book.Published;
                page.BTN_Cancel.Click += EditBookPage_BTN_Cancel_Click;
                page.BTN_Save.Click += EditBookPageBTN_Save_Existing_Click;
                MainFrame.Content = page;

            }
            

        }

        private void EditBookPageBTN_Save_Existing_Click(object sender, RoutedEventArgs e)
        {
            var page = (EditBookPage)MainFrame.Content;
            var book = (Book)mainPage.LB_Books.SelectedItem;
            book.Author = page.TB_Author.Text;
            book.Title = page.TB_Title.Text;
            book.Type = page.TB_Type.Text;
            book.Published = page.DP_Publish.SelectedDate;
            mainPage.LB_Books.Items.Refresh();
            MainFrame.Content = mainPage;
        }

        private void BTN_New_Click(object sender, RoutedEventArgs e)
        {
            var page = new EditBookPage();
            MainFrame.Content = page;
            page.BTN_Cancel.Click += EditBookPage_BTN_Cancel_Click;
            page.BTN_Save.Click += EditBookPageBTN_Save_New_Click;
        }

        private void EditBookPageBTN_Save_New_Click(object sender, RoutedEventArgs e)
        {
            var page = (EditBookPage)MainFrame.Content;
            var book = new Book()
            {
                Author = page.TB_Author.Text,
                Title = page.TB_Title.Text,
                Type = page.TB_Type.Text,
                Published = page.DP_Publish.SelectedDate,
            };
            mainPage.LB_Books.Items.Add(book);
            MainFrame.Content = mainPage;
        }

        private void EditBookPage_BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = mainPage;
        }
    }
}
