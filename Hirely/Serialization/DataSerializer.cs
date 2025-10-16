using Hirely.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hirely.Model.Serialization
{
    public class DataSerializer
    {
        public static void SerializeData(string fileName, RecruitmentModel data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var options = new JsonSerializerOptions
            {
                WriteIndented = true // гарне форматування
            };

            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(fileName, json);
        }

        public static RecruitmentModel DeserializeData(string fileName)
        {
            if (!File.Exists(fileName))
                return new RecruitmentModel();

            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<RecruitmentModel>(json) ?? new RecruitmentModel();
        }
    }
}
