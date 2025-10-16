using Hirely.UI.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Hirely.UI.Views
{
    public partial class CandidatesUserControl : UserControl, INotifyPropertyChanged
    {
        public CandidatesUserControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // Колекція кандидатів
        public static readonly DependencyProperty CandidatesProperty =
            DependencyProperty.Register(nameof(Candidates),
                typeof(ObservableCollection<CandidateViewModel>),
                typeof(CandidatesUserControl),
                new PropertyMetadata(null));

        public ObservableCollection<CandidateViewModel> Candidates
        {
            get => (ObservableCollection<CandidateViewModel>)GetValue(CandidatesProperty);
            set
            {
                SetValue(CandidatesProperty, value);
                OnPropertyChanged(nameof(Candidates));
            }
        }

        // Вибраний кандидат
        public static readonly DependencyProperty SelectedCandidateProperty =
            DependencyProperty.Register(nameof(SelectedCandidate),
                typeof(CandidateViewModel),
                typeof(CandidatesUserControl),
                new PropertyMetadata(null));

        public CandidateViewModel SelectedCandidate
        {
            get => (CandidateViewModel)GetValue(SelectedCandidateProperty);
            set
            {
                SetValue(SelectedCandidateProperty, value);
                OnPropertyChanged(nameof(SelectedCandidate));
            }
        }
    }
}
