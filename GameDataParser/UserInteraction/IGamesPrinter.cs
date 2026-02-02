using GameDataParser.Model;

namespace GameDataParser.UserInteraction
{
    public interface IGamesPrinter
    {
        public void PrintData(List<Game> list);
    }
}