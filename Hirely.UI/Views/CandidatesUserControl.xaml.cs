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
    /// Interaction logic for CandidatesUserControl.xaml
    /// </summary>
    public partial class CandidatesUserControl : UserControl
    {
        public CandidatesUserControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CandidatesProperty =
            DependencyProperty.Register(nameof(Candidates), typeof(ObservableCollection<CandidateViewModel>), typeof(CandidatesUserControl), new PropertyMetadata(null));

        public ObservableCollection<CandidateViewModel> Candidates
        {
            get => (ObservableCollection<CandidateViewModel>)GetValue(CandidatesProperty);
            set => SetValue(CandidatesProperty, value);
        }
    }
}