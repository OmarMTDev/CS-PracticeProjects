using GameDataParser.DataAccess;

namespace GameDataParser.UserInteraction
{
    public class ConsoleUserInteractor : IUserInteractionHandler
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintError(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }

        public string ReadValidPath()
        {
            string path = "";
            bool inputIsValid;
            do
            {
                Console.WriteLine("Enter the name of the file you want to read: ");

                var userInput = Console.ReadLine();

                if (userInput == "")
                {
                    PrintMessage("File name cannot be empty.");
                    break;
                }

                if (userInput is null)
                {
                    PrintMessage("File name cannot be null.");
                    break;
                }

                path = FileReader.BuildFilePath(userInput);

                bool fileExists = File.Exists(path);

                inputIsValid = fileExists;
            } while (inputIsValid == false);

            return path;
        }
    }
}