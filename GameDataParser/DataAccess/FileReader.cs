using GameDataParser.UserInteraction;

namespace GameDataParser.DataAccess
{
    public class FileReader : IFileReader
    {
        private readonly IUserInteractionHandler _userInteractor;

        public FileReader(IUserInteractionHandler userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public static string BuildFilePath(string fileName)
        {
            return $"./jsonFiles/{fileName}.json";
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}