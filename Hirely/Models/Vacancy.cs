using System.Collections.Generic;

namespace Hirely.Model.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Status { get; set; } = VacancyStatus.New.ToString();

        public IEnumerable<Candidate> Candidates { get; set; } = new List<Candidate>();
    }

    public enum VacancyStatus
    {
        Urgent,
        Closed,
        InProgress,
        New
    }
}
