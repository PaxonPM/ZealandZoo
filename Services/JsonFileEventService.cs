using System.Text.Json;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class JsonFileEventService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileEventService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "MockEvent", "Events.json"); }
        }

        public void SaveJsonEvents(List<Event> events)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Event[]>(jsonWriter, events.ToArray());
            }
        }

        public IEnumerable<Event> GetJsonEvents()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Event[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}

