using System.IO;
using System.Windows;

namespace Hirely.UI.Views
{
    public partial class ResumeWindow : Window
    {
        public ResumeWindow(string resumePath)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(resumePath) && File.Exists(resumePath))
            {
                // Перетворюємо шлях у формат URI, щоб WebBrowser міг відкрити локальний файл
                var uri = new System.Uri(resumePath, System.UriKind.Absolute);
                PdfBrowser.Navigate(uri);
            }
            else
            {
                MessageBox.Show("Файл резюме не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
