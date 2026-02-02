namespace GameDataParser.DataAccess
{
    public interface IJsonFileDeserializer
    {
        public List<T> DeserializeJsonFile<T>(string fileName, string fileContent);
    }
}