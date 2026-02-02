using GameDataParser.DataAccess;
using GameDataParser.UserInteraction;
using GameDataParser.Logging;
using GameDataParser.Model;


var userInteractor = new ConsoleUserInteractor();

var app = new GameDataParserApp(
    userInteractor,
    new FileReader(userInteractor),
    new JsonFileDeserializer(userInteractor),
    new GamesPrinter(userInteractor)
);

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
    Logger<Exception>.Log(ex);
}

public class GameDataParserApp
{
    private readonly IUserInteractionHandler _userInteractor;
    private readonly IFileReader _fileReader;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IJsonFileDeserializer _jsonDeserializer;

    public GameDataParserApp(IUserInteractionHandler userInteractor, IFileReader fileReader, IJsonFileDeserializer jsonDeserializer, IGamesPrinter gamesPrinter)
    {
        _userInteractor = userInteractor;
        _fileReader = fileReader;
        _jsonDeserializer = jsonDeserializer;
        _gamesPrinter = gamesPrinter;
    }

    public void Run()
    {
        string path = _userInteractor.ReadValidPath();

        string fileContent = _fileReader.Read(path);

        List<Game> games = _jsonDeserializer.DeserializeJsonFile<Game>(path, fileContent);

        _gamesPrinter.PrintData(games);
    }
}