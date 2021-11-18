using System;
using Sandbox;
using SCP;
using System.Text.Json;

namespace SCP.Settings
{
	public class Language
	{
		public string JoinMessage { get; set; }
		public string DClass { get; set; }
		public string Medic { get; set; }
		public string Scientist { get; set; }
		public string Mtf { get; set; }

		public static Language Load(string languageName)
		{
			string languagePath = "/Settings/Languages/" + languageName + ".json";
			if ( !FileSystem.Mounted.FileExists( languagePath ) )
			{
				languagePath = "/settings/Languages/english.json";
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
