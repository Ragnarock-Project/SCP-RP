﻿using System;
using Sandbox;
using SCP;

namespace SCP.Settings
{
	public class ClientProgress
	{
		public string ScientistUnlocked { get; set; }
		public string SoldierUnlocked { get; set; }
		public string MedicalUnlocked { get; set; }


		public static ClientProgress Load( long steamId )
		{
			string settingsPathFile = "/clientdata/" + steamId + "/progress.json";
			string settingsPathDir = "/clientdata/" + steamId;

			if ( FileSystem.Data.DirectoryExists( settingsPathDir ) )
			{
				if ( FileSystem.Data.FileExists( settingsPathFile ) )
				{
					return FileSystem.Data.ReadJson<ClientProgress>( settingsPathFile );

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

			string settingsPathFile = "/clientdata/" + steamId + "/progress.json";
			string settingsPathDir = "/clientdata/" + steamId;
			if ( !FileSystem.Data.DirectoryExists( settingsPathDir ) )
			{
				FileSystem.Data.CreateDirectory( settingsPathDir );
				Log.Info( "Progress folder not found, creating your new progress folder" );
			}
			FileSystem.Data.WriteJson( settingsPathFile, settings );

		}

		public static bool Check( long steamId )
		{
			string settingsPathFile = "/clientdata/" + steamId + "/progress.json";
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

		private static ClientProgress LoadDefault()
		{
			Log.Error( "Couldn't find your progress file \n Loading default progress file" );
			return FileSystem.Mounted.ReadJson<ClientProgress>( "/code/settings/defaultvalues/client_progress.json" );
		}

	}
}
