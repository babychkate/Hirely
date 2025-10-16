using Hirely.UI.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Hirely.UI.Views
{
    public partial class VacanciesUserControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public VacanciesUserControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty VacanciesProperty =
            DependencyProperty.Register(nameof(Vacancies),
                typeof(ObservableCollection<VacancyViewModel>),
                typeof(VacanciesUserControl),
                new PropertyMetadata(null));

        public ObservableCollection<VacancyViewModel> Vacancies
        {
            get => (ObservableCollection<VacancyViewModel>)GetValue(VacanciesProperty);
            set => SetValue(VacanciesProperty, value);
        }

        public static readonly DependencyProperty SelectedVacancyProperty =
            DependencyProperty.Register(nameof(SelectedVacancy),
                typeof(VacancyViewModel),
                typeof(VacanciesUserControl),
                new PropertyMetadata(null));

        public VacancyViewModel SelectedVacancy
        {
            get => (VacancyViewModel)GetValue(SelectedVacancyProperty);
            set
            {
                SetValue(SelectedVacancyProperty, value);
                OnPropertyChanged(nameof(SelectedVacancy));
                // Можна викликати додаткову логіку, наприклад:
                SelectedVacancyChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<VacancyViewModel> SelectedVacancyChanged;
    }
}
