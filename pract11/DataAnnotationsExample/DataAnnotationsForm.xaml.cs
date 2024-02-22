using pract11.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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

namespace pract11.DataAnnotationsExample
{
    /// <summary>
    /// Логика взаимодействия для DataAnnotationsForm.xaml
    /// </summary>
    public partial class DataAnnotationsForm : UserControl
    {
        private ObservableCollection<string> errors = new();

        public DataAnnotationsForm()
        {
            InitializeComponent();
            ValidationErrorsList.ItemsSource = errors;
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            errors.Clear();
            var user = (UserInfo)DataContext;
            ValidationContext context = new(user);
            List<System.ComponentModel.DataAnnotations.ValidationResult> results = new();
            bool isValid = Validator.TryValidateObject(user, context, results, true);

            if (isValid)
            {
                MessageBox.Show("Добавлено!");
            }
            else
            {
                foreach (string error in results.Select(r => r.ErrorMessage ?? string.Empty))
                {
                    errors.Add(error);
                }
            }
        }
    }
}
