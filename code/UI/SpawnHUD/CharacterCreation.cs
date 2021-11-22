using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using SCP.Settings;

namespace SCP.UI
{
	/// <summary>
	/// The character creation form, used when the player wants to create a new character
	/// </summary>
	public partial class CharacterCreation : Form
	{
		private readonly long steamId;
		public CharacterCreation()
		{

		}
		public CharacterCreation( string chosenDepartment )
		{
			steamId = Local.Client.PlayerId;
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
				ReturnToChoice();
			} );
		}
		public void CharacterCreate( string chosenDepartment, string firstname, string lastname, string number )
		{
			int regnumber = number.ToInt();
			ClientCharacter createdCharacter = new( chosenDepartment, firstname, lastname, regnumber );
			ClientCharacter.Save( steamId, createdCharacter );
			ScpRpGame.SpawnPlayer(chosenDepartment);
			
			new MainHUD();

			this.Parent.Delete();

		}
		public void ReturnToChoice()
		{
			Parent.AddChild<DepartmentChoice>();
			this.Delete();
		}
	}
}
