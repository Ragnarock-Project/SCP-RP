using Sandbox;
using System;

namespace SCP.Entities
{


	[Library( "ent_healthusable" )]
	public partial class HealthUsable : Prop, IUse
	{
		public override void Spawn()
		{
			base.Spawn();

			SetModel( "./models/coffeemug01gib01_lod01.vmdl_c" );
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
			ply.Health = Math.Clamp( ply.Health + 50f, 0f, 100f );
			Delete();

			return false;
		}

		public bool IsUsable( Entity user )
		{
			return user is Player ply && ply.Health < 100;
		}
	}

}
