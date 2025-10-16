using Hirely.Model.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hirely.UI.ViewModels
{
    public class RecruitmentViewModel : ViewModelBase
    {
        // Колекції
        public ObservableCollection<CandidateViewModel> Candidates { get; set; } = new ObservableCollection<CandidateViewModel>();
        public ObservableCollection<VacancyViewModel> Vacancies { get; set; } = new ObservableCollection<VacancyViewModel>();

        // Вибраний елемент (Vacancy або Candidate)
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

        // Видимість панелі деталей
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

        // Нова властивість для підрахунку незакритих вакансій
        public int OpenVacanciesCount =>
            Vacancies.Count(v => v.Status != VacancyStatus.Closed.ToString());

        // Чи вибрана вакансія (для кнопки)
        public bool IsVacancyToClose => SelectedItem is VacancyViewModel v && v.Status != VacancyStatus.Closed.ToString();

        // Закрити вакансію
        private Command _closeVacancyCommand;
        public Command CloseVacancyCommand => _closeVacancyCommand ??= new Command(
            () =>
            {
                if (SelectedItem is VacancyViewModel vacancy)
                    vacancy.Status = VacancyStatus.Closed.ToString();
                OnPropertyChanged(nameof(OpenVacanciesCount));
            },
            () => IsVacancyToClose
        );

        public bool IsVacancyToOpen => SelectedItem is VacancyViewModel v && v.Status == VacancyStatus.Closed.ToString();

        // Закрити вакансію
        private Command _openVacancyCommand;
        public Command OpenVacancyCommand => _openVacancyCommand ??= new Command(
            () =>
            {
                if (SelectedItem is VacancyViewModel vacancy)
                    vacancy.Status = "Open";
                OnPropertyChanged(nameof(OpenVacanciesCount));
            },
            () => IsVacancyToOpen
        );

        // Табс
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
                SelectedItem = null; // Очистити вибір при перемиканні табів
            }
        }

        // Текущі елементи для DataGrid (Vacancies або Candidates)
        public IEnumerable<object> CurrentItems =>
            CurrentTab == TabType.Vacancies ? Vacancies : Candidates;

        // Команди перемикання табів
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
