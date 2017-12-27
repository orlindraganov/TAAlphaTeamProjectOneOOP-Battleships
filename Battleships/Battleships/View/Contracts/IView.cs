using System.Collections;
using Battleships.BattleshipsEngine.Providers.ContractsOfProviders;
using Battleships.Models.Contracts;

namespace Battleships.View.Contracts
{
    public interface IView : IReader, IWriter
    {
        void Start(IParticipant player);

        void Update();
    }
}