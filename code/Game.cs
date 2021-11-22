using Sandbox;
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
			NotSpawnedPlayer player = new();
			client.Pawn = player;
			player.Respawn();
		}

		/// <summary>
		/// Load the user's data following a choice of faction using it's steamID and faction's ID, then spawn the player
		/// </summary>
		/// <param name="chosenDepartment"> The chosen department</param>
		[ServerCmd]
		public static void SpawnPlayer( string chosenDepartment )
		{
			Client client = ConsoleSystem.Caller;
			ClientCharacter clientCharacter = ClientCharacter.Load( client.PlayerId, chosenDepartment );
			string FirstName = clientCharacter.FirstName;
			string LastName = clientCharacter.LastName;
			int Number = clientCharacter.Number;
			client.Pawn.Delete();

			switch ( chosenDepartment )
			{
				case "dclass":
					DClass dclass = new( client, FirstName, LastName, Number );
					client.Pawn = dclass;
					dclass.Respawn();
					break;
				case "scientist":
					Scientist scientist = new( client, FirstName, LastName, Number );
					client.Pawn = scientist;
					scientist.Respawn();
					break;
				case "ait":
					AIT ait = new( client, FirstName, LastName, Number );
					client.Pawn = ait;
					ait.Respawn();
					break;
				case "medical":
					Medical medic = new( client, FirstName, LastName, Number );
					client.Pawn = medic;
					medic.Respawn();
					break;
				default:
					DClass defaultclass = new( client, FirstName, LastName, Number );
					client.Pawn = defaultclass;
					defaultclass.Respawn();
					break;
			}
		}

	}
}
