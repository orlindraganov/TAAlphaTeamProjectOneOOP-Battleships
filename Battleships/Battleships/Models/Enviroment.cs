using System.Collections.Generic;
using Battleships.Models.Contracts;

namespace Battleships.Models
{
    public class Enviroment : IParticipant, IEnviroment
    {
        public Enviroment(IList<IGameObject> gameObjects)
        {
            this.GameObjects = gameObjects;
        }

        public IList<IGameObject> GameObjects { get; }

        public void GetObjectHit(IGameObject hitGameObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
