namespace GameDataParser.UserInteraction
{
    public interface IUserInteractionHandler
    {
        public string ReadValidPath();
        public void PrintMessage(string message);
        public void PrintError(string message);
    }
}
