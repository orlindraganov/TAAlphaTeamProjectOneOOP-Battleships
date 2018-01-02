using System;
using Battleships.Models.Contracts;
using Battleships.View.Common;
using Battleships.View.Contracts;
using Battleships.View.Enums;

namespace Battleships.View
{
    public class EnemyBattlefieldSegment : BattlefieldSegment, IViewSegment, IBattlefieldSegment
    {
        public EnemyBattlefieldSegment(int startingRow, int height, int startingCol, int width) : base(startingRow, height, startingCol, width)
        {
        }

        protected override void DrawShip(IShip ship)
        {

            char hit = Constants.HitSymbol;
            char notHit = Constants.WaterNotHitSymbol;
            char symbol;

            foreach (var element in ship.Elements)
            {
                var elementPosition = CalculateDrawingPosition(element.Position);

                Console.SetCursorPosition(elementPosition.Col, elementPosition.Row);

                if (element.IsHit)
                {
                    SetConsole(ConsoleSettings.ShipHit);
                    symbol = hit;
                }
                else
                {
                    SetConsole(ConsoleSettings.WaterNotHit);
                    symbol = notHit;
                }

                Console.Write(symbol);
            }
        }
    }
}