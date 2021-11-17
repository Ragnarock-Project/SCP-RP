using Sandbox;
using System;
using System.Linq;
using System.Collections.Generic;
using SCP.UI;
using SCP.Departments;

namespace SCP
{
	public partial class ScpGame : Game
	{
		public ScpHUD SpawnHUD;


		public ScpGame()
		{
			if ( IsClient ) SpawnHUD = new ScpHUD();

		}

		[Event.Hotload]
		public void HotloadUpdate()
		{
			if ( !IsClient ) return;
			SpawnHUD?.Delete();
			SpawnHUD = new ScpHUD();
		}

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );


			DClass player = new( client, "Jacques", "Mallard", 12345 );
			client.Pawn = player;

			player.Respawn();

		}
		
	}
}
