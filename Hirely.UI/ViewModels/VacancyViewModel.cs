using System.Collections.ObjectModel;

namespace Hirely.UI.ViewModels
{
    public class VacancyViewModel : ViewModelBase
    {
        public VacancyViewModel()
        {
            Candidates = new ObservableCollection<CandidateViewModel>();
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string _technologies = string.Empty;
        public string Technologies
        {
            get => _technologies;
            set
            {
                if (_technologies != value)
                {
                    _technologies = value;
                    OnPropertyChanged(nameof(Technologies));
                }
            }
        }

        private string _department = string.Empty;
        public string Department
        {
            get => _department;
            set
            {
                if (_department != value)
                {
                    _department = value;
                    OnPropertyChanged(nameof(Department));
                }
            }
        }

        private string _status = string.Empty;
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public ObservableCollection<CandidateViewModel> Candidates { get; set; }

        public int CandidateCount => Candidates?.Count ?? 0;

        public void RefreshCandidates()
        {
            OnPropertyChanged(nameof(Candidates));
            OnPropertyChanged(nameof(CandidateCount));
        }
    }

}
