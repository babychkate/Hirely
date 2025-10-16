using Hirely.UI.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hirely.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private RecruitmentViewModel ViewModel => (RecruitmentViewModel)DataContext;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnAddVacancy_Click(object sender, RoutedEventArgs e)
    {
        // Поки просто повідомлення для перевірки
        MessageBox.Show("Тут буде форма для додавання вакансії");
    }

}