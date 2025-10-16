using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirely.Model.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
    }

    public enum CandidateStatus
    {
        Applied,
        Interview,
        Technical,
        Onboarding
    }
}