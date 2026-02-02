using System.Text.Json;
using GameDataParser.UserInteraction;

namespace GameDataParser.DataAccess
{
    public class JsonFileDeserializer : IJsonFileDeserializer
    {
        private readonly IUserInteractionHandler _userInteractor;
        

        public JsonFileDeserializer(IUserInteractionHandler userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public List<T> DeserializeJsonFile<T>(string fileName, string fileContent)
        {
            List<T>? deserializedContent;
            try
            {
                deserializedContent = JsonSerializer.Deserialize<List<T>>(fileContent) ?? [];

                if (deserializedContent.Count == 0)
                {
                    Console.WriteLine("JSON file is empty.");
                }

                return deserializedContent;
            }
            catch (JsonException ex)
            {
                _userInteractor.PrintError($"JSON in the {fileName}  was not in a valid format. JSON body: {fileContent}");

                throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
            }
        }
    }
}