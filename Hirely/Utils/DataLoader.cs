using Hirely.Model.Models;
using Hirely.Model.Serialization;

namespace Hirely.Model.Utils
{
    public class DataLoader
    {
        private readonly string _filePath;

        public DataLoader(string filePath = null)
        {
            _filePath = filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "recruitmentData.json");
        }

        public RecruitmentModel LoadData()
        {
            var data = DataSerializer.DeserializeData(_filePath);
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            foreach (var c in data.Candidates ?? [])
            {
                c.PhotoPath = Path.Combine(basePath, c.PhotoPath);
                c.ResumeLink = Path.Combine(basePath, c.ResumeLink);
            }

            foreach (var v in data.Vacancies ?? [])
                foreach (var c in v.Candidates ?? [])
                {
                    c.PhotoPath = Path.Combine(basePath, c.PhotoPath);
                    c.ResumeLink = Path.Combine(basePath, c.ResumeLink);
                }

            return data;
        }

        public void SaveData(RecruitmentModel data)
        {
            DataSerializer.SerializeData(_filePath, data);
        }
    }
}
