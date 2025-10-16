using Hirely.UI.ViewModels;
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

namespace Hirely.UI.Views
{
    /// <summary>
    /// Interaction logic for VacanciesUserControl.xaml
    /// </summary>
    public partial class VacanciesUserControl : UserControl
    {
        public VacanciesUserControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty VacanciesProperty =
            DependencyProperty.Register(nameof(Vacancies), typeof(ObservableCollection<VacancyViewModel>), typeof(VacanciesUserControl), new PropertyMetadata(null));

        public ObservableCollection<VacancyViewModel> Vacancies
        {
            get => (ObservableCollection<VacancyViewModel>)GetValue(VacanciesProperty);
            set => SetValue(VacanciesProperty, value);
        }

        public static readonly DependencyProperty SelectedVacancyProperty =
            DependencyProperty.Register(nameof(SelectedVacancy), typeof(VacancyViewModel), typeof(VacanciesUserControl), new PropertyMetadata(null));

        public VacancyViewModel SelectedVacancy
        {
            get => (VacancyViewModel)GetValue(SelectedVacancyProperty);
            set => SetValue(SelectedVacancyProperty, value);
        }
    }
}
