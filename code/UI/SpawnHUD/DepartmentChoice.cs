using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using SCP.Settings;
using SCP.Departments;

namespace SCP.UI
{
	public partial class DepartmentChoice : Panel
	{


		private List<(Panel, Panel)> Entries = new();
		private Panel MainPanel;
		long SteamId;

		public DepartmentChoice()
		{
			StyleSheet.Load( "/ui/SpawnHUD/DepartmentChoice.scss" );
			SteamId = Local.Client.PlayerId;

			//Log.Error( Local.Client.Name + "AAAAAAAAAAA" );
			Panel BackgroundPanel = Add.Panel( "background" );

			MainPanel = BackgroundPanel.Add.Panel( "menu" );

			// Pages
			Panel DClassPage = MainPanel.Add.Panel( "page" );
			string DClassID = "dclass";
			string DClassDesc = "You are a D Class, which means you are a test subject";
			AddEntry( DClassPage, DClassDesc, DClassID, "/UI/Images/dclass.jpg", "D Class", new Color( 255f, 0f, 0f ), true ); ;

			Panel ScientistPage = MainPanel.Add.Panel( "page" );
			string ScientistID = "scientist";
			string ScientistDesc = "You are a Scientist, which means you lead experiences";
			bool ScientistEnabled = ClientProgress.Load( SteamId ).ScientistUnlocked;
			AddEntry( ScientistPage, ScientistDesc, ScientistID, "/UI/Images/scientist.jpg", "Scientist", new Color( 0f, 255f, 255f ), ScientistEnabled );

			Panel AITPage = MainPanel.Add.Panel( "page" );
			string AITID = "ait";
			string AITDesc = "You are an AIT, which means you assure the site's security";
			bool AITEnabled = ClientProgress.Load( SteamId ).SoldierUnlocked;
			AddEntry( AITPage, AITDesc, AITID, "/UI/Images/soldier.jpg", "AIT", new Color( 15f, 133f, 0f ), AITEnabled );

			Panel MedicPage = MainPanel.Add.Panel( "page" );
			string MedicID = "medical";
			string MedicDesc = "You are a medic, which means you heal people";
			bool MedicEnabled = ClientProgress.Load( SteamId ).MedicalUnlocked;
			AddEntry( MedicPage, MedicDesc, MedicID, "/UI/Images/medic.jpg", "Medical", new Color( 15f, 133f, 0f ), MedicEnabled );
		}



		private void AddEntry( Panel panel, string desc, string departmentId, string image, string name, Color buttonColor, bool unlocked )
		{

			Panel button = MainPanel.Add.Panel( "selectbutton" );
			Panel header = button.Add.Panel( "header" );
			header.Add.Label( name, "name" );
			Panel body = button.Add.Panel( "body" );
			body.Style.SetBackgroundImage( image );
			body.Add.Label( desc, "description" );
			button.Style.BorderColor = buttonColor;
			if ( unlocked )
			{
				button.AddEventListener( "onclick", () =>
				{
					SelectEntry( departmentId );
				} );
			}
			

			Entries.Add( (panel, button) );
		}

		private void SelectEntry( string departmentId )
		{
			if(ClientCharacter.Check(SteamId, departmentId ) )
			{
				ScpGame.SpawnPlayer( departmentId );
				new MainHUD();

				this.Parent.Delete();

			}
			else
			{
				CharacterCreation FinishCreation = new( departmentId );
				Parent.AddChild( FinishCreation );
				this.Delete();
			}

			

		}

	}
}


