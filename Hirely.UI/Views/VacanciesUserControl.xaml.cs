using Hirely.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hirely.UI.Views
{
    public partial class VacanciesUserControl : UserControl
    {
        public VacanciesUserControl()
        {
            InitializeComponent();
        }
        public ObservableCollection<VacancyViewModel> Vacancies
        {
            get => (ObservableCollection<VacancyViewModel>)GetValue(VacanciesProperty);
            set => SetValue(VacanciesProperty, value);
        }

        public static readonly DependencyProperty VacanciesProperty =
            DependencyProperty.Register(nameof(Vacancies),
                typeof(ObservableCollection<VacancyViewModel>),
                typeof(VacanciesUserControl),
                new PropertyMetadata(null));
        public VacancyViewModel SelectedVacancy
        {
            get => (VacancyViewModel)GetValue(SelectedVacancyProperty);
            set => SetValue(SelectedVacancyProperty, value);
        }

        public static readonly DependencyProperty SelectedVacancyProperty =
            DependencyProperty.Register(nameof(SelectedVacancy),
                typeof(VacancyViewModel),
                typeof(VacanciesUserControl),
                new PropertyMetadata(null));

    }
}