using System.Collections.Generic;
using Battleships.Models.Contracts;
using Bytes2you.Validation;

namespace Battleships.Models
{
    public class Water : IGameObject, IWater
    {
        private IList<IGameObjectElement> elements;

        public Water(IList<IGameObjectElement> elements)
        {
            this.Elements = elements;
        }

        public IList<IGameObjectElement> Elements
        {
            get
            {
                return this.elements;
            }
            set
            {
                Guard.WhenArgument(value, "Elements").IsNull().Throw();
                this.elements = value;
            } 
        }
    }
}