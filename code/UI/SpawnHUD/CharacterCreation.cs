﻿using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using SCP.Departments;
using SCP.Settings;

namespace SCP.UI
{
	public partial class CharacterCreation : Form
	{
		long steamId;
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
			} );


		}
		public void CharacterCreate( string chosenDepartment, string firstname, string lastname, string number )
		{

			int regnumber = number.ToInt();
			ClientCharacter createdCharacter = new( chosenDepartment, firstname, lastname, regnumber );
			ClientCharacter.Save( steamId, createdCharacter );
			ScpGame.SpawnPlayer(chosenDepartment);
			
			new MainHUD();

			this.Parent.Delete();

		}
		

		
	}
}