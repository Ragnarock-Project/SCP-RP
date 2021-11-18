using System;
using Sandbox;
using System.Collections.Generic;
using System.Linq;
using SCP.Settings;

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

		[ServerCmd( "set_language" )]
		public static void SetLanguage(string language)
		{
			if ( !Language.Check( language ) )
			{
				Log.Info( "Couldn't find your language : " + language + " Operation canceled" );
				return;
			}
			long callerId = ConsoleSystem.Caller.PlayerId;
			ClientSettings.Save(callerId, language);
			Log.Info( "Language saved sucessfully" );
			

		}
		/*[ServerCmd( "setrpname" )]
		public static void SetRpName( string newName )
		{

			var caller = ConsoleSystem.Caller.Pawn as ScpPlayer;
			if ( caller == null ) return;
			caller.RpName = newName;
			ConsoleSystem.Caller.SetScore( "rpname", newName );

		}*/
		[ServerCmd( "check_language" )]
		public static void CheckLanguage()
		{

			long callerId = ConsoleSystem.Caller.PlayerId;
			string currentLanguage = ClientSettings.Load( callerId ).Language;
			string test = Language.Load( currentLanguage ).JoinMessage;
			Log.Info( "Your language : " + currentLanguage + "\n'has joined' in your language is : " + test );


		}

		[ServerCmd( "damage_self" )]
		public static void DamageTarget( int damage )
		{
			var caller = ConsoleSystem.Caller.Pawn;
			var damageAmount = DamageInfo.Generic( damage );
			caller.TakeDamage( damageAmount );
		}


	}
}
