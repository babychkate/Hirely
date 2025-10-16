using System;

namespace Hirely.Model.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string GitHub { get; set; }
        public string LinkedIn { get; set; }
        public string Status { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public string Level { get; set; } = "Junior";
        public string ResumeLink { get; set; } = string.Empty; 
    }

    public enum CandidateStatus
    {
        Applied,
        Interview,
        Technical,
        Onboarding
    }
}
