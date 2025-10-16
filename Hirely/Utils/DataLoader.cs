using Hirely.Model.Models;
using Hirely.Model.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirely.Model.Utils
{
    public class DataLoader
    {
        private readonly string _filePath;

        public DataLoader(string filePath = @"C:\Users\Kateryna\Desktop\Конструювання програмного забезпечення\Hirely\recruitmentData.json")
        {
            _filePath = filePath;
        }

        public RecruitmentModel LoadData()
        {
            return DataSerializer.DeserializeData(_filePath);
        }

        // Збереження даних
        public void SaveData(RecruitmentModel data)
        {
            DataSerializer.SerializeData(_filePath, data);
        }
    }
}
