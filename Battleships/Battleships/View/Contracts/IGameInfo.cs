namespace Battleships.View.Contracts
{
    public interface IGameInfo
    {
        string FirstPlayerName { get; }

        int FistPlayerScore { get; }

        string SecondPlayerName { get; }

        int SecondPlayerScore { get; }
    }
}