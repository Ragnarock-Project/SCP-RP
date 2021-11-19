using Sandbox;
using System;
using SCP.UI;
using SCP.Departments;
using SCP.Settings;

namespace SCP
{
	public partial class ScpGame : Game
	{
		public SpawnHUD SpawnHUD;


		public ScpGame()
		{
			if ( IsClient )
			{
				SpawnHUD = new SpawnHUD();
			}

		}

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );
			NotSpawnedPlayer player = new();//new( client, "Jacques", "Mallard", 12345 );
			client.Pawn = player;
			player.Respawn();
		}

	}
}
