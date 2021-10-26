using Sandbox;
using System;
using System.Linq;
using System.Collections.Generic;
using SCP.UI;

namespace SCP
{
	public partial class ScpGame : Game
	{
		public SpawnHUD SpawnHUD;


		public ScpGame()
		{
			if ( IsClient ) SpawnHUD = new SpawnHUD();

		}

		[Event.Hotload]
		public void HotloadUpdate()
		{
			if ( !IsClient ) return;
			SpawnHUD?.Delete();
			SpawnHUD = new SpawnHUD();
		}

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );


			NotSpawnedPlayer player = new( client );
			client.Pawn = player;

			player.Respawn();

		}
		
	}
}
