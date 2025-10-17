using Hirely.Model.Models;
using System.Collections.ObjectModel;

namespace Hirely.UI.ViewModels
{
    public class RecruitmentViewModel : ViewModelBase
    {
        public ObservableCollection<CandidateViewModel> Candidates { get; set; } = new ObservableCollection<CandidateViewModel>();
        public ObservableCollection<VacancyViewModel> Vacancies { get; set; } = new ObservableCollection<VacancyViewModel>();

        private object _selectedItem;
        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));
                OnPropertyChanged(nameof(IsVacancyToClose));
                OnPropertyChanged(nameof(IsVacancyToOpen));

                IsDetailVisible = _selectedItem != null;

                OpenVacancyCommand.RaiseCanExecuteChanged();
                CloseVacancyCommand.RaiseCanExecuteChanged();
            }
        }

        private VacancyViewModel _selectedVacancy;
        public VacancyViewModel SelectedVacancy
        {
            get => _selectedVacancy;
            set
            {
                _selectedVacancy = value;
                OnPropertyChanged(nameof(SelectedVacancy));
                OnPropertyChanged(nameof(IsVacancyToClose));
                OnPropertyChanged(nameof(IsVacancyToOpen));
            }
        }

        private bool _isDetailVisible;
        public bool IsDetailVisible
        {
            get => _isDetailVisible;
            set
            {
                _isDetailVisible = value;
                OnPropertyChanged(nameof(IsDetailVisible));
            }
        }

        public int OpenVacanciesCount => Vacancies.Count(v => v.Status != VacancyStatus.Closed.ToString());
        public bool IsVacancyToClose => SelectedItem is VacancyViewModel v && v.Status != VacancyStatus.Closed.ToString();
        public bool IsVacancyToOpen => SelectedItem is VacancyViewModel v && v.Status == VacancyStatus.Closed.ToString();

        private Command _closeVacancyCommand;
        public Command CloseVacancyCommand => _closeVacancyCommand ??= new Command(
            () =>
            {
                if (SelectedItem is VacancyViewModel vacancy)
                    vacancy.Status = VacancyStatus.Closed.ToString();

                OpenVacancyCommand.RaiseCanExecuteChanged();
                CloseVacancyCommand.RaiseCanExecuteChanged();

                OnPropertyChanged(nameof(OpenVacanciesCount));
            },
            () => IsVacancyToClose
        );

        private Command _openVacancyCommand;
        public Command OpenVacancyCommand => _openVacancyCommand ??= new Command(
            () =>
            {
                if (SelectedItem is VacancyViewModel vacancy)
                    vacancy.Status = VacancyStatus.Open.ToString();

                OpenVacancyCommand.RaiseCanExecuteChanged();
                CloseVacancyCommand.RaiseCanExecuteChanged();

                OnPropertyChanged(nameof(OpenVacanciesCount));
            },
            () => IsVacancyToOpen
        );

        public enum TabType { Vacancies, Candidates }

        private TabType _currentTab = TabType.Vacancies;
        public TabType CurrentTab
        {
            get => _currentTab;
            set
            {
                _currentTab = value;
                OnPropertyChanged(nameof(CurrentTab));
                OnPropertyChanged(nameof(CurrentItems));
                SelectedItem = null;
            }
        }

        public IEnumerable<object> CurrentItems =>
            CurrentTab == TabType.Vacancies ? Vacancies : Candidates;

        private Command _showVacanciesCommand;
        public Command ShowVacanciesCommand => _showVacanciesCommand ??= new Command(
            () => CurrentTab = TabType.Vacancies
        );

        private Command _showCandidatesCommand;
        public Command ShowCandidatesCommand => _showCandidatesCommand ??= new Command(
            () => CurrentTab = TabType.Candidates
        );
    }
}
