using Battleships.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
	class Player : IPlayer, IParticipant
	{
		private bool isAlive;
		private int health;
		private string name;
		private IList<Element> gameObjects;
		private Battlefield field;
		public Player(string name, IList<Element> gameObjects)
		{
			this.Name = name;
			this.GameObjects = gameObjects;
			this.Health = 17;
			this.IsAlive = true;
		}


		public bool IsAlive { get { return this.isAlive; }set { this.isAlive = value; } }

		public int Health { get { return this.health; }set {this.health=value; } }

		public string Name { get { return this.name; }set { this.name = value; } }

		public IList<Element> GameObjects { get { return this.gameObjects; }set {this.gameObjects=value; } }

		public void Fire()
		{
			throw new NotImplementedException();
		}

		public void AddShip(IShip ship)
		{
			throw new NotImplementedException();
		}

		public void GetObjectHit(IGameObject hitGameObject)
		{
			throw new NotImplementedException();
		}
	}
}
