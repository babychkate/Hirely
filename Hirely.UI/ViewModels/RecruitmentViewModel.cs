using Hirely.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirely.UI.ViewModels
{
    public class RecruitmentViewModel : ViewModelBase
    {
        private ObservableCollection<CandidateViewModel> _candidates = new ObservableCollection<CandidateViewModel>();
        public ObservableCollection<CandidateViewModel> Candidates
        {
            get => _candidates;
            set
            {
                _candidates = value;
                OnPropertyChanged(nameof(Candidates));
            }
        }

        private ObservableCollection<VacancyViewModel> _vacancies = new ObservableCollection<VacancyViewModel>();
        public ObservableCollection<VacancyViewModel> Vacancies
        {
            get => _vacancies;
            set
            {
                _vacancies = value;
                OnPropertyChanged(nameof(Vacancies));
            }
        }

        private object _selectedItem;
        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                // Якщо щось вибрано — показати деталі
                IsDetailVisible = _selectedItem != null;

                // Повідомляємо команду закриття вакансії
                CloseVacancyCommand.RaiseCanExecuteChanged();
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


        private Command _closeVacancyCommand;
        public Command CloseVacancyCommand => _closeVacancyCommand ??= new Command(
            () =>
            {
                if (SelectedItem is VacancyViewModel vacancy)
                {
                    vacancy.Status = VacancyStatus.Closed.ToString();
                }
            },
            () => SelectedItem is VacancyViewModel v && v.Status != VacancyStatus.Closed.ToString()
        );



        public enum TabType
        {
            Vacancies,
            Candidates
        }

        private IEnumerable<object> _currentItems;
        public IEnumerable<object> CurrentItems
        {
            get => _currentItems;
            set
            {
                _currentItems = value;
                OnPropertyChanged(nameof(CurrentItems));

                // При перемиканні табів очистити деталі
                SelectedItem = null;
            }
        }

        private Command _showVacanciesCommand;
        public Command ShowVacanciesCommand => _showVacanciesCommand ??= new Command(
            () => CurrentItems = Vacancies.Cast<object>()
        );

        private Command _showCandidatesCommand;
        public Command ShowCandidatesCommand => _showCandidatesCommand ??= new Command(
            () => CurrentItems = Candidates.Cast<object>()
        );

    }
}
