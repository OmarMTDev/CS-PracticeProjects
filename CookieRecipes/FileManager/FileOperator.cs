namespace CookieRecipes.FileManager {
public abstract class FileOperator
    {
        private const string Path = "./recipes";
        public static string BuildPath(FileFormats format) => $"{Path}.{format}";
    }
}