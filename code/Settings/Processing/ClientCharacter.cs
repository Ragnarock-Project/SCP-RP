using System;
using Sandbox;
using SCP.Departments;

namespace SCP.Settings
{
	public class ClientCharacter
	{
		public string Department { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Number { get; set; }

		public ClientCharacter( string department, string firstName, string lastName, int number )
		{
			Department = department;
			FirstName = firstName;
			LastName = lastName;
			Number = number;
		}

		public static ClientCharacter Load( long steamId, string department )
		{
			string characterPathFile = "/clientdata/" + steamId + "/characters/" + department + ".json";

			if ( FileSystem.Data.FileExists( characterPathFile ) )
			{
				return FileSystem.Data.ReadJson<ClientCharacter>( characterPathFile );

			}
			else
			{
				return LoadDefault( steamId );

			}
		}
		public static void Save( long steamId, ClientCharacter character )
		{
			string characterPathFile = "/clientdata/" + steamId + "/characters/" + character.Department + ".json";
			string characterPathDir = "/clientdata/" + steamId + "/characters/";
			if ( !FileSystem.Data.DirectoryExists( characterPathDir ) )
			{
				FileSystem.Data.CreateDirectory( characterPathDir );
				Log.Info( "Settings folder not found, creating your new settings folder" );
			}
			FileSystem.Data.WriteJson( characterPathFile, character );

		}

		public static bool Check( long steamId, string department )
		{

			string characterPathFile = "/clientdata/" + steamId + "/characters/" + department + ".json";
			if ( FileSystem.Data.FileExists( characterPathFile ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static ClientCharacter LoadDefault( long steamId )
		{
			Log.Error( "This character doesn't exists, loading your D-Class character" );
			{
				string characterPathFile = "/clientdata/" + steamId + "/characters/dclass.json";

				if ( FileSystem.Data.FileExists( characterPathFile ) )
				{
					return FileSystem.Data.ReadJson<ClientCharacter>( characterPathFile );

				}
				else
				{
					ClientCharacter characterError = new( "dclass", "John", "Doe", 404 );
					Log.Error( "Your don't have a D-Class character, please create one" );
					return characterError;

				}

			}

		}

		


	}
}
