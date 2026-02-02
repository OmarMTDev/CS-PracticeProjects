namespace CookieRecipes.FileManager
{
    using System.Text.Json.Nodes;

    public abstract class FileWriter : FileOperator
    {
        public static void UpsertFile(FileFormats format, string content)
        {
            string completePath = BuildPath(format);
            if (!File.Exists(completePath))
            {
                using StreamWriter newFile = File.CreateText(completePath);
                newFile.WriteLine(content);
                return;
            }

            using StreamWriter filestream = File.AppendText(completePath);
            filestream.WriteLine(format == FileFormats.txt ? content : $", {new JsonArray(content)}");
        }
    }
}