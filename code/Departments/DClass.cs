using Sandbox;

namespace SCP.Departments
{
	class DClass : MainPlayer
	{
		

		public DClass() {}


		public DClass( Client cl, string firstname, string lastname, int regnumber ) : base( cl ) 
		{
			FirstName = firstname;
			LastName = lastname;
			RegNumber = regnumber;
			Clothes = System.Array.Empty<string>();
			RoleName = "D Class";
			RoleplayName = "D-" + RegNumber;
			cl.SetValue( "rpname", RoleplayName );

			cl.SetValue( "role", RoleName );

		}
	}
}
