using System;
using Sandbox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP
{
	public partial class ScpGame
	{

		[ServerCmd( "killeveryone" )]
		public static void KillEveryone()
		{
			foreach ( Player player in All.OfType<Player>() )
			{
				player.TakeDamage( DamageInfo.Generic( 100f ) );
			}
		}

		[ServerCmd( "sethealth" )]
		public static void SetHealth( int health )
		{
			var caller = ConsoleSystem.Caller.Pawn;
			if ( caller == null ) return;

			caller.Health = health;
		}



		[ServerCmd( "ping" )]
		public static void Vomi()
		{

			Log.Info( "Pong" );

		}


		/*[ServerCmd( "setrpname" )]
		public static void SetRpName( string newName )
		{

			var caller = ConsoleSystem.Caller.Pawn as ScpPlayer;
			if ( caller == null ) return;
			caller.RpName = newName;
			ConsoleSystem.Caller.SetScore( "rpname", newName );

		}*/


		[ServerCmd( "damage_self" )]
		public static void DamageTarget( int damage )
		{
			var caller = ConsoleSystem.Caller.Pawn;
			var damageAmount = DamageInfo.Generic( damage );
			caller.TakeDamage( damageAmount );
		}


	}
}
