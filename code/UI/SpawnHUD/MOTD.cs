using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using SCP.Settings;
using SCP.Departments;

namespace SCP.UI
{
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


