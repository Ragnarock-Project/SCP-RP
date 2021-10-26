
using Sandbox;
using System;


namespace SCP
{
	[Library ("ent_flunch")]
	public partial class Flunch : Prop 
	{
		public override void Spawn()
		{
			base.Spawn();

			SetModel( "./models/citizen/citizen.vmdl_c" );
			SetupPhysicsFromModel( PhysicsMotionType.Static, false );

			GlowState = GlowStates.GlowStateOn;
			GlowDistanceStart = 0;
			GlowDistanceEnd = 1000;
			GlowColor = new Color( 1.0f, 0, 0, 1.0f );
			GlowActive = true;
		}
		public bool OnUse( Entity user )
		{
			if ( user is not Player ply ) return false;
			Variable.PlayerEating = Math.Clamp( Variable.PlayerEating + 50f, 0f, 100f );
			Delete();

			return false;
		}

		public bool IsUsable( Entity user )
		{
			return user is Player ply && Variable.PlayerEating < 100;
		}
	}
}
