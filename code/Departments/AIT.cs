using Sandbox;
using SCP.UI;
namespace SCP.Departments
{
	class AIT : MainPlayer
	{


		public AIT()
		{
		}


		public AIT( Client cl, string firstname, string lastname, int regnumber ) : base( cl )
		{
			FirstName = firstname;
			LastName = lastname;
			RegNumber = regnumber;
			RoleplayName = "S17 AIT " + LastName + " " + RegNumber;
			cl.SetValue( "rpname", RoleplayName );
			Clothes = new string[]
			{
				"models/citizen_clothes/shoes/shoes.police.vmdl",
				"models/citizen_clothes/trousers/trousers.police.vmdl",
				"models/citizen_clothes/shirt/shirt_longsleeve.police.vmdl",
				"models/citizen_clothes/hat/hat_uniform.police.vmdl"
			};
			RoleName = "AIT";
			cl.SetValue( "role", RoleName );


		}
	}
}

