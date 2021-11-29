using Sandbox;

namespace SCP.Departments
{
	class Medical : MainPlayer
	{
		public static Color RoleColor { get; } = new Color( 15f, 133f, 0f );
		public Medical() { }

		public Medical( Client cl, string firstname, string lastname, int regnumber ) : base( cl )
		{
			FirstName = firstname;
			LastName = lastname;
			RegNumber = regnumber;
			Clothes = new string[]
			{
				"models/citizen_clothes/shoes/shoes.workboots.vmdl",
				"models/citizen_clothes/trousers/trousers.lab.vmdl",
				"models/citizen_clothes/shirt/shirt_longsleeve.scientist.vmdl"
			};
			RoleName = "Medical";

			RoleplayName = "Doctor " + LastName;
			cl.SetValue( "rpname", RoleplayName );
			cl.SetValue( "role", RoleName );

		}
	}
}
