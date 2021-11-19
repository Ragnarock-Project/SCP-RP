using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using SCP.Departments;
using SCP;

namespace SCP.UI
{
	public partial class CharacterCreation : Form
	{
		public CharacterCreation()
		{

		}
		public CharacterCreation( string chosenDepartment )
		{

			TextEntry firstnameText = Add.TextEntry( "" );
			firstnameText.SetClass( "firstnametext", true );
			TextEntry lastnameText = Add.TextEntry( "" );
			lastnameText.SetClass( "lastnametext", true );
			TextEntry regnumberText = Add.TextEntry( "" );
			regnumberText.SetClass( "number", true );
			StyleSheet.Load( "/ui/SpawnHUD/CharacterCreation.scss" );
			SetClass( "charform", true );
			AddHeader( "Title", null );
			AddRow( "Firstname", firstnameText );
			
			AddRow( "Lastname", lastnameText );
			AddRow( "Number", regnumberText );
			Panel buttonContainer = Add.Panel( "buttoncontainer" );
			Panel cancel = buttonContainer.Add.Panel( "cancel" );
			cancel.Add.Label( "Cancel" );
			Panel validate = buttonContainer.Add.Panel("validate");
			validate.Add.Label("Validate");


			validate.AddEventListener( "onclick", () =>
			{
				CharacterCreate( chosenDepartment, firstnameText.Text, lastnameText.Text, regnumberText.Text );
			} );

			cancel.AddEventListener( "onclick", () =>
			{
			} );


		}
		public void CharacterCreate( string chosenDepartment, string firstname, string lastname, string number )
		{

			int regnumber = number.ToInt();
			CmdCreateChar( chosenDepartment, firstname, lastname, regnumber );

			this.Style.Opacity = 0;// Quand le RPC sera dispo, utiliser this.Parent.Delete(); à la place

			new MainHUD();

		}
		[ServerCmd]
		public static void CmdCreateChar( string pageKey, string firstname, string lastname, int regnumber )
		{
			var client = ConsoleSystem.Caller;
			client.Pawn.Delete();

			switch ( pageKey )
			{
				case "dclass":
					DClass dclass = new( client, firstname, lastname, regnumber );
					client.Pawn = dclass;
					dclass.Respawn();
					break;
				case "scientist":
					Scientist scientist = new( client, firstname, lastname, regnumber );
					client.Pawn = scientist;
					scientist.Respawn();
					break;
				case "ait":
					AIT ait = new( client, firstname, lastname, regnumber );
					client.Pawn = ait;
					ait.Respawn();
					break;
				case "medical":
					Medical medic = new( client, firstname, lastname, regnumber );
					client.Pawn = medic;
					medic.Respawn();
					break;
				default:
					DClass defaultclass = new( client, firstname, lastname, regnumber );
					client.Pawn = defaultclass;
					defaultclass.Respawn();
					break;
			}
		}

		
	}
}
