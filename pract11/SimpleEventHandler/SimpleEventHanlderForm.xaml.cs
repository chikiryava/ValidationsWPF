using pract11.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace pract11.SimpleEventHandler
{
    /// <summary>
    /// Логика взаимодействия для SimpleEventHanlderForm.xaml
    /// </summary>
    public partial class SimpleEventHanlderForm : UserControl
    {
        private ObservableCollection<string> errors = new();

        public SimpleEventHanlderForm()
        {
            InitializeComponent();
            ValidationErrorsList.ItemsSource = errors;
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            errors.Clear();
            Book book = (Book)DataContext;

            if (book.Title.Length == 0 || book.Title.Length > 100)
            {
                errors.Add("Укажите длину книги от 1 до 100 символов");
            }

            if (book.Author.Length == 0 || book.Author.Length > 100)
            {
                errors.Add("Укажите авторов книги (от 1 до 100 символов)");
            }

            if (book.PagesCount < 0)
            {
                errors.Add("Количество страниц не может быть отрицательным");
            }
            if (!book.Isbn10.IsIsbn10())
            {
                errors.Add("Укажите действительный isbn-10");
            }       

            if (errors.Count > 0)
            {
                MessageBox.Show("Не удалось добавить запись. Проверьте корректность введенных данных");
                }
            else
            {
                MessageBox.Show("Добавлено");
            }
        }
    }
}
