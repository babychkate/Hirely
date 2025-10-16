using System.Collections.Generic;

namespace Hirely.Model.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        // Назва вакансії
        public string Title { get; set; } = string.Empty;

        // Технології, які потрібні для цієї вакансії
        public string Technologies { get; set; } = string.Empty;

        // Департамент
        public string Department { get; set; } = string.Empty;

        // Статус вакансії
        public string Status { get; set; } = VacancyStatus.New.ToString();

        // Список кандидатів для цієї вакансії
        public List<Candidate> Candidates { get; set; } = new List<Candidate>();
    }

    public enum VacancyStatus
    {
        Urgent,
        Closed,
        InProgress,
        New
    }
}
