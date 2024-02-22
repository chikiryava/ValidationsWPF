using pract11.Extensions;
using pract11.Models;
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

namespace pract11.FluentValidationExample
{
    /// <summary>
    /// Логика взаимодействия для FluentValidationForm.xaml
    /// </summary>
    public partial class FluentValidationForm : UserControl
    {
        private ObservableCollection<string> errors = new();

        public FluentValidationForm()
        {
            InitializeComponent();
            ValidationErrorsList.ItemsSource = errors;
        }

        private void AddParticipant(object sender, RoutedEventArgs e)
        {
            errors.Clear();
            var participant = (Participant)DataContext;

            var validator = new ParticipantValidator();
            var result = validator.Validate(participant);

            if (result.IsValid)
            {
                MessageBox.Show("Запись добавлена!");
            }
            else
            {
                result.Errors.ForEach(err => errors.Add(err.ErrorMessage));
            }
        }
    }
}
