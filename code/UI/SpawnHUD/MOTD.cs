using Sandbox.UI;
using Sandbox.UI.Construct;

namespace SCP.UI
{
	/// <summary>
	/// The message of the day, it's the first UI the player sees when he connects
	/// </summary>
	public partial class MOTD : Panel
	{

		public MOTD()
		{
			StyleSheet.Load( "/ui/SpawnHUD/MOTD.scss" );
			Panel BackgroundPanel = Add.Panel( "background" );

			string HeaderText = "Message of the day";
			string BodyText = "Welcome to our game mode, it's not finished yet but we hope you like it.\nJoin us on discord https://discord.gg/RTq9tCYg9b";
			BackgroundPanel.Add.Label( HeaderText, "header" );
			BackgroundPanel.Add.Label( BodyText, "bodyText" );
			SetClass( "motd", true );

			Panel buttonContainer = Add.Panel( "buttoncontainer" );
			Panel okay = buttonContainer.Add.Panel( "okay" );
			okay.Add.Label( "Okay" );

			okay.AddEventListener( "onclick", () =>
			{
				UserClicked();
			} );

		}
		private void UserClicked()
		{
			Parent.AddChild<DepartmentChoice>();
			this.Delete();

		}

	}
}


