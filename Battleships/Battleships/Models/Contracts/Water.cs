using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Enums;
using Battleships.Utilities;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
    class Water : IGameObject, IGameObjectElement
    {
        private bool isHit;
        private IPosition elementPosition;
        private IList<IGameObjectElement> elements;
        private GameObjectElementType type;
        public Water(IPosition elementPosition,IList<IGameObjectElement>elements)
        {
            this.IsHit = false;
            this.ElementPosition = elementPosition;
            this.Elements = elements;
            this.type = GameObjectElementType.Water;
        }

        public IList<IGameObjectElement> Elements { get { return this.elements; }set { this.elements = value; } }
        public bool IsHit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IPosition ElementPosition { get { return this.elementPosition; } set { this.elementPosition = value; } }

        public void GetHit()
        {
            throw new NotImplementedException();
        }
    }
}
