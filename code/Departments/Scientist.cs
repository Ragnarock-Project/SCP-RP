using Sandbox;

namespace SCP.Departments
{
	class Scientist : MainPlayer
	{


		public Scientist() { }


		public Scientist( Client cl, string firstname, string lastname, int regnumber ) : base( cl )
		{
			FirstName = firstname;
			LastName = lastname;
			RegNumber = regnumber;
			//modelPath = "";
			Clothes = new string[]
			{
				"models/citizen_clothes/shoes/shoes.workboots.vmdl",
				"models/citizen_clothes/trousers/trousers.lab.vmdl",
				"models/citizen_clothes/shirt/shirt_longsleeve.scientist.vmdl",
				"models/citizen_clothes/jacket/labcoat.vmdl"
			};
			RoleName = "Scientist";
			RoleplayName = "Researcher " + LastName;
			cl.SetValue( "rpname", RoleplayName );

			cl.SetValue( "role", RoleName );

		}
	}
}
