using Sandbox;
using SCP.Settings;

namespace SCP
{
	public partial class ScpRpGame
	{

		[ServerCmd( "sethealth" )]
		public static void SetHealth( int health )
		{
			var caller = ConsoleSystem.Caller.Pawn;
			if ( caller == null ) return;

			caller.Health = health;
		}

		[ServerCmd( "ping" )]
		public static void Ping()
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

		[ServerCmd( "test" )]
		public static void Test()
		{
			var caller = ConsoleSystem.Caller.Pawn as MainPlayer;
			Log.Info(caller.RoleName);
		}

	}
}
