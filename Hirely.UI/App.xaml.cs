using Hirely.Model.Models;
using Hirely.Model.Utils;
using Hirely.UI.Mappers;
using Hirely.UI.ViewModels;
using Hirely.UI.Views;
using Mapster;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Hirely.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private RecruitmentViewModel _viewModel;

    public App()
    {
        Mapping.Configure();

        var loader = new DataLoader();
        var recruitmentModel = loader.LoadData();

        _viewModel = new RecruitmentViewModel
        {
            Candidates = recruitmentModel.Candidates.Adapt<ObservableCollection<CandidateViewModel>>(),
            Vacancies = recruitmentModel.Vacancies.Adapt<ObservableCollection<VacancyViewModel>>(),
        };

        var window = new MainWindow
        {
            DataContext = _viewModel
        };
        window.Show();

        this.Exit += (s, e) =>
        {

            recruitmentModel.Candidates = _viewModel.Candidates.Adapt<ObservableCollection<Candidate>>();
            recruitmentModel.Vacancies = _viewModel.Vacancies.Adapt<ObservableCollection<Vacancy>>();

            loader.SaveData(recruitmentModel);
        };
    }
}

