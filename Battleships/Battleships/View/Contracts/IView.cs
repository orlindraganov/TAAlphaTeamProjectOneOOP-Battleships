using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.View.Contracts
{
    public interface IView : IInput, IOutput
    {
        IPlayer FirstPlayer { get; set; }

        IPlayer SecondPlayer { get; set; }

        void DrawBorders();

        void Update();

        void Update(IPosition position);
    }
}