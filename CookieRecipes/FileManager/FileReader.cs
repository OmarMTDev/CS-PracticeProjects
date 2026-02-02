using CookieRecipes.Ingredients;

namespace CookieRecipes.FileManager
{
    public abstract class FileReader : FileOperator
    {
        public static void DisplayExistingRecipes(FileFormats format)
        {
            string path = BuildPath(format);
            if (!File.Exists(path))
            {
                Console.WriteLine($"No recipes file.=> {path}");
                return;
            }

            string numericList;
            Console.WriteLine(@"Existing recipes!!
                ");

            int recipeNumber = 1;

            var iterableIngredientList = ReadListFromFile(path);

            foreach (string line in iterableIngredientList)
            {
                Console.WriteLine($"***** Recipe #{recipeNumber} *****");
                numericList = line.Replace(",", "").Trim();
                foreach (var item in numericList)
                {
                    int id = (int)char.GetNumericValue(item);
                    var preparations = RecipeDataOutput.GetPreparationById(id);
                    Console.WriteLine(preparations);
                }
                Console.WriteLine(@"
                
                ");
                recipeNumber++;
            }
        }

        public static List<string> ReadListFromFile(string path)
        {
            IEnumerable<string> textLines = File.ReadLines(path);
            return path.Contains(FileFormats.txt.ToString())
            ? [.. textLines]
            : ConvertJsonToTextList(File.ReadLines(path));
        }

        public static List<string> ConvertJsonToTextList(IEnumerable<string> json)
        {
            List<string> jsonLines = [];
            foreach (string line in json)
            {
                if (line.Contains('[') || line.Contains(']')) continue;
                jsonLines.Add(line);
            }
            return [.. jsonLines];
        }
    }
}