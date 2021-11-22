using Sandbox;

namespace SCP
{
	/// <summary>
	/// A pawn representing a player who has not yet chosen his department
	/// </summary>
	partial class NotSpawnedPlayer  : Player
	{
		[Net]
		public string RoleplayName { get; set; } = "";
		[Net]
		public string RoleName { get; set; } = "Default";

		public NotSpawnedPlayer() {
		}
		public NotSpawnedPlayer( Client cl ) : this()
		{
			this.RoleplayName = cl.Name;
			cl.SetValue( "rpname", RoleplayName );
			cl.SetValue( "rank", "Player" );
		}

		public override void Respawn()
		{
			
			Camera = new FirstPersonCamera();

			EnableAllCollisions = false;
			EnableDrawing = false;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			TickPlayerUse();

			if ( LifeState != LifeState.Alive )
				return;

		}
	}
}

	

