using System.Windows;
using System.Windows.Controls;

namespace Hirely.UI.Views
{
    public partial class OpenVacanciesCounterUserControl : UserControl
    {
        public OpenVacanciesCounterUserControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty OpenVacanciesCountProperty =
            DependencyProperty.Register(
                "OpenVacanciesCount",
                typeof(int),
                typeof(OpenVacanciesCounterUserControl),
                new PropertyMetadata(0));

        public int OpenVacanciesCount
        {
            get => (int)GetValue(OpenVacanciesCountProperty);
            set => SetValue(OpenVacanciesCountProperty, value);
        }
    }
}