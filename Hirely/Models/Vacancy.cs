using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirely.Model.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
    }

    public enum VacancyStatus
    {
        Urgent,
        Closed,
        InProgress,
        New
    }
}
