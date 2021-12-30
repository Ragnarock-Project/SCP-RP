using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;
using SCP.Settings;
using SCP.Departments;

namespace SCP.UI
{
	/// <summary>
	/// The interface allowing the player to choose his department
	/// </summary>
	public partial class DepartmentChoice : Panel
	{
		private readonly List<(Panel, Panel)> Entries = new();
		private readonly List<(Panel, Panel)> Categories = new();
		private readonly Panel MainPanel;
		private readonly Panel CategoryTab;
		private readonly long SteamId;

		public DepartmentChoice()
		{
			StyleSheet.Load( "/ui/SpawnHUD/DepartmentChoice.scss" );
			SteamId = Local.Client.PlayerId;
			Panel BackgroundPanel = Add.Panel( "background" );

			CategoryTab = BackgroundPanel.Add.Panel( "categorytab" );
			

			MainPanel = BackgroundPanel.Add.Panel( "menu" );
			ClientProgress clientProgress = ClientProgress.Load(SteamId);
			// Pages
			Panel DClassPage = MainPanel.Add.Panel( "dclass" );
			string DClassDesc = "Class D is awarded to renewable personnel used to handle dangerous anomalies. Class D personnel are generally recruited from the ranks of prisoners convicted of serious or violent crimes worldwide.";
			AddEntry( DClassPage, DClassDesc, "/UI/Images/dclass.jpg", "D Class",  true );

			Panel ScientistPage = MainPanel.Add.Panel( "scientist" );
			string ScientistDesc = "Researchers make up the scientific part of the Foundation, chosen from among the most intelligent and qualified scientists in the world. With specialists in every conceivable field of expertise, from chemistry and botany to more esoteric subjects such as theoretical physics and xenobiology, the goal of the Foundation's research projects is to gain a better understanding of unexplained anomalies and how they work.";
			bool ScientistEnabled = clientProgress.ScientistUnlocked;
			AddEntry( ScientistPage, ScientistDesc, "/UI/Images/scientist.jpg", "Scientist",  ScientistEnabled );

			Panel AITPage = MainPanel.Add.Panel( "soldier" );
			string AITDesc = "Response teams - or tactical teams - are highly trained and heavily armed combat teams whose purpose is to escort containment teams when dangerous abnormal entities or hostile Interest Groups are involved and to defend Foundation facilities against hostile actions. The response teams are mostly military units stationed at the Foundation's most important facilities, ready to deploy at any time.";
			bool AITEnabled = clientProgress.SoldierUnlocked;
			AddEntry( AITPage, AITDesc, "/UI/Images/soldier.jpg", "Soldier",  AITEnabled );

			Panel MedicPage = MainPanel.Add.Panel( "medic" );
			string MedicDesc = "The Foundation's Medical Department is responsible for keeping employees in good health. Due to the nature of Foundation work, medics often encounter difficult to treat and highly unusual instances of wounds, trauma, infections, and disorders. Because of this, the medical department adheres to exceptionally high personnel standards.";
			bool MedicEnabled = clientProgress.MedicalUnlocked;
			AddEntry( MedicPage, MedicDesc, "/UI/Images/medic.jpg", "Medical", MedicEnabled );
			
			// Tabs 
			AddCategory( "Main", "/UI/Images/scp.png" );
			AddCategory( "Secondary", "/UI/Images/scp.png" );
			AddCategory( "Safe SCP", "/UI/Images/scp.png" );
			AddCategory( "Euclid SCP", "/UI/Images/scp.png" );
			AddCategory( "Keter SCP", "/UI/Images/scp.png" );
		}

		private void AddCategory( string name, string logo )
		{
			Panel panel = CategoryTab.Add.Panel( "categorypage" );
			Panel button = CategoryTab.Add.Panel( "categorybutton" );
			button.Add.Label( name, "title" );
			button.Add.Image( logo, "logo" );
			button.AddEventListener( "onclick", () =>
			{
				Log.Error( "Categories aren't available for now, please wait for the next update" );
			} );
			Categories.Add( (panel, button) );
		}

		private void AddEntry( Panel panel, string desc, string image, string name,  bool unlocked )
		{

			Panel button = MainPanel.Add.Panel( "selectbutton" );
			Panel header = button.Add.Panel( "header" );
			header.Add.Label( name, "name" );
			Panel body = button.Add.Panel( "body" );
			body.Style.SetBackgroundImage( image );
			header.Add.Label( desc, "description" );
			if ( unlocked )
			{
				button.AddEventListener( "onclick", () =>
				{
					SelectEntry( name );
				} );
			}

			Entries.Add( (panel, button) );
		}

		private void SelectEntry( string departmentId )
		{
			string finalId = departmentId.Replace( " ", "" ).ToLower();
			if ( ClientCharacter.Check( SteamId, finalId ) )
			{
				ScpRpGame.SpawnPlayer( finalId );
				new MainHUD();

				this.Parent.Delete();

			}
			else
			{
				CharacterCreation FinishCreation = new( finalId );
				Parent.AddChild( FinishCreation );
				this.Delete();
			}
		}
	}
}


