namespace Battleships.Models.Contracts
{
    /// <summary>
    /// Player will hold the ships
    /// </summary>
    public interface IPlayer : IParticipant
    {
        bool IsAlive { get; set; }

        int Health { get; }

        string Name { get; }
    }
}
