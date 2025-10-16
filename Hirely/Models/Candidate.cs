using System;

namespace Hirely.Model.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        // Статус кандидата
        public string Status { get; set; }

        // Нові поля
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty; // шлях до фото
        public string Level { get; set; } = "Junior"; // рівень: Junior, Middle, Senior
        public string ResumeLink { get; set; } = string.Empty; // посилання на резюме
    }

    public enum CandidateStatus
    {
        Applied,
        Interview,
        Technical,
        Onboarding
    }
}
