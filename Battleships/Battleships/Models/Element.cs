using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class Element:IGameObjectElement
    {
        private bool isHit;
        private Position elementPosition;
        private GameObjectElementType type;
        public Element(bool isHit,GameObjectElementType type,Position position)
        {
            this.isHit = isHit;
            this.type = type;
            this.elementPosition = position;
        }
        public bool IsHit { get {return this.isHit; } set { this.isHit = value; } }
        public Position ElementPosition { get {return this.elementPosition; }set {this.elementPosition=value; } }
        public GameObjectElementType Type { get { return this.type; } set { this.type = value; } }
        public void GetHit()
        {
            this.IsHit = true;
           
        }

    }
}
