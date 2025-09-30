using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraTrack.Helper
{
    public static class JsonSeeder
    {
        public static List<T> LoadDataFromJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException($"The File at Path {filePath} Was Not Found!...");

            string Data = File.ReadAllText(filePath);
            var Options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<List<T>>(Data, Options) ?? new List<T>();
        }
    }
}
