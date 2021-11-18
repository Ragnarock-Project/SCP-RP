using System;
using Sandbox;
using SCP;
using System.Text.Json;

namespace SCP.Settings
{
	public class Language
	{
		public string joinMessage { get; set; }
		public string dClass { get; set; }
		public string medic { get; set; }
		public string scientist { get; set; }
		public string mtf { get; set; }

		public static Language Load(string languageName)
		{
			string languagePath = "/Settings/Languages/" + languageName + ".json";
			if ( !FileSystem.Mounted.FileExists( languagePath ) )
			{
				languagePath = "/code/settings/Languages/english.json";
				Log.Info( "Couldn't find your language : " + languageName + "\n Loading default language (English)" );
				
			}
			return FileSystem.Mounted.ReadJson<Language>( languagePath );
		}

		public static bool Check( string languageName )
		{

			string languagePath = "/Settings/Languages/" + languageName + ".json";
			if ( FileSystem.Mounted.FileExists( languagePath ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
