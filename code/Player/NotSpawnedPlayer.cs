using Sandbox;

namespace SCP
{
	partial class NotSpawnedPlayer  : Player
	{
		[Net]
		public string RoleplayName { get; set; } = "";
		[Net]
		public string RoleName { get; set; } = "Default";


		public NotSpawnedPlayer() { }
		public NotSpawnedPlayer( Client cl )
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

	

