using Hirely.Model.Models;
using Hirely.UI.ViewModels;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirely.UI.Mappers
{
    class Mapping
    {
        public static void Configure()
        {
            TypeAdapterConfig<Candidate, CandidateViewModel>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.Status, src => src.Status);

            TypeAdapterConfig<CandidateViewModel, Candidate>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.Status, src => src.Status);

            TypeAdapterConfig<Vacancy, VacancyViewModel>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title);

            TypeAdapterConfig<VacancyViewModel, Vacancy>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title);
        }
    }
}
