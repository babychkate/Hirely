using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirely.Model.Models
{
    public class RecruitmentModel
    {
        public IEnumerable<Candidate> Candidates { get; set; }
        public IEnumerable<Vacancy> Vacancies { get; set; }
    }
}
