using System;
using Battleships.Enums;
using Battleships.Models.Contracts;
using Battleships.Utilities.Contracts;

namespace Battleships.Models
{
	public class GameObjectElement : IGameObjectElement
	{
		public bool IsHit { get; set; }
		public IPosition ElementPosition { get; set; }
		public GameObjectElementType Type { get; }
		public void GetHit()
		{
			throw new NotImplementedException();
		}
	}
}
