using System;
using Sandbox;
using SCP;

namespace SCP.Settings
{
	public class ClientSettings
	{
		public string language { get; set; }

		public static ClientSettings Load( long steamId )
		{
			string settingsPathFile = "/clientdata/" + steamId + "/client_settings.json";
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

			string settingsPathFile = "/clientdata/" + steamId + "/client_settings.json";
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

			string settingsPathFile = "/clientdata/" + steamId + "/client_settings.json";
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
			Log.Info( "Couldn't find your settings file \n Loading default settings" );
			return FileSystem.Mounted.ReadJson<ClientSettings>( "/code/settings/Client/default.json" );
		}

	}
}
