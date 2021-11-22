using Sandbox;

namespace SCP.Settings
{
	public class ClientSettings
	{
		public string Language { get; set; }


		public static ClientSettings Load( long steamId )
		{
			string settingsPathFile = "/clientdata/" + steamId + "/settings.json";
			string settingsPathDir = "/clientdata/" + steamId;
			
			if ( FileSystem.Data.DirectoryExists( settingsPathDir ) )
			{
				if ( FileSystem.Data.FileExists( settingsPathFile ) )
				{
					return FileSystem.Data.ReadJson<ClientSettings>( settingsPathFile );

				}
				else
				{
					return LoadDefault();

				}
			}
			return LoadDefault();
		}
		public static void Save( long steamId, string settings )
		{

			string settingsPathFile = "/clientdata/" + steamId + "/settings.json";
			string settingsPathDir = "/clientdata/" + steamId;
			if ( !FileSystem.Data.DirectoryExists( settingsPathDir ) )
			{
				FileSystem.Data.CreateDirectory( settingsPathDir );
				Log.Info( "Settings folder not found, creating your new settings folder" );
			}
			FileSystem.Data.WriteJson( settingsPathFile, settings );

		}

		public static bool Check( long steamId )
		{

			string settingsPathFile = "/clientdata/" + steamId + "/settings.json";
			string settingsPathDir = "/clientdata/" + steamId;
			if ( FileSystem.Data.DirectoryExists( settingsPathDir ) && FileSystem.Data.FileExists( settingsPathFile ) )
			{
					return true;
			}
			else
			{
				return false;
			}
		}

		private static ClientSettings LoadDefault()
		{
			Log.Warning( "Couldn't find your settings file \n Loading default settings" );
			return FileSystem.Mounted.ReadJson<ClientSettings>( "/code/settings/defaultvalues/client_settings.json" );
		}

	}
}
