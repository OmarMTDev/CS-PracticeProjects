using GameDataParser.Model;
namespace GameDataParser.UserInteraction
{

    class GamesPrinter : IGamesPrinter
    {
        private readonly IUserInteractionHandler _userInteractor;

        public GamesPrinter(IUserInteractionHandler userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void PrintData(List<Game> list)
        {
            if (list.Count <= 0)
            {
                _userInteractor.PrintMessage("JSON file is empty.");
            }

            _userInteractor.PrintMessage("____________ GAMES INFO ____________");
            foreach (var game in list)
            {
                _userInteractor.PrintMessage(game.ToString());
            }
            _userInteractor.PrintMessage("___________________________________");
        }
    }
}
