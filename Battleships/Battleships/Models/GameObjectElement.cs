using System;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
    public class GameObjectElement : IGameObjectElement
    {
        public bool IsHit { get; set; }
        public IPosition Position { get; set; }
        public GameObjectElementType Type { get; }
        public event EventHandler WasHitEvent;

        public GameObjectElement()
        {
        }

        public GameObjectElement(IPosition position, GameObjectElementType type)
        {
            this.Position = position;
            this.Type = type;
        }

        public void GetHit()
        {
            if (IsHit)
            {
                throw new AlreadyFiredThereException();
            }

            this.IsHit = true;
            OnWasHit(EventArgs.Empty);
        }

        private void OnWasHit(EventArgs e)
        {
            var handler = WasHitEvent;
            handler?.Invoke(this, e);
        }
    }
}