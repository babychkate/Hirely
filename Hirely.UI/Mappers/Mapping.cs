using Hirely.Model.Models;
using Hirely.UI.ViewModels;
using Mapster;
using System.Collections.ObjectModel;

namespace Hirely.UI.Mappers
{
    class Mapping
    {
        public static void Configure()
        {
            TypeAdapterConfig<Candidate, CandidateViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.PhotoPath, src => src.PhotoPath)
                .Map(dest => dest.Level, src => src.Level)
                .Map(dest => dest.ResumeLink, src => src.ResumeLink)
                .ConstructUsing(src => new CandidateViewModel());

            TypeAdapterConfig<CandidateViewModel, Candidate>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.PhotoPath, src => src.PhotoPath)
                .Map(dest => dest.Level, src => src.Level)
                .Map(dest => dest.ResumeLink, src => src.ResumeLink)
                .ConstructUsing(src => new Candidate());

            TypeAdapterConfig<Vacancy, VacancyViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Technologies, src => src.Technologies)
                .Map(dest => dest.Department, src => src.Department)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.Candidates,
                     src => src.Candidates == null
                        ? new ObservableCollection<CandidateViewModel>()
                        : src.Candidates.Adapt<ObservableCollection<CandidateViewModel>>())
                .ConstructUsing(src => new VacancyViewModel());

            TypeAdapterConfig<VacancyViewModel, Vacancy>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Technologies, src => src.Technologies)
                .Map(dest => dest.Department, src => src.Department)
                .Map(dest => dest.Status, src => src.Status)
                // Зворотне мапінгування списку кандидатів
                .Map(dest => dest.Candidates,
                     src => src.Candidates == null
                        ? new List<Candidate>()
                        : src.Candidates.Adapt<List<Candidate>>())
                .ConstructUsing(src => new Vacancy());
        }
    }
}
