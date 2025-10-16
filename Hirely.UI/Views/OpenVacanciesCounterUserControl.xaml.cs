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

        // --- Dependency Property: OpenVacanciesCount ---
        public static readonly DependencyProperty OpenVacanciesCountProperty =
            DependencyProperty.Register(
                "OpenVacanciesCount",
                typeof(int),
                typeof(OpenVacanciesCounterUserControl),
                new PropertyMetadata(0)); // Значення за замовчуванням

        public int OpenVacanciesCount
        {
            get => (int)GetValue(OpenVacanciesCountProperty);
            set => SetValue(OpenVacanciesCountProperty, value);
        }
    }
}