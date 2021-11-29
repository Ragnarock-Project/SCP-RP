using Sandbox;

namespace SCP.Departments
{
	class DClass : MainPlayer
	{
		public static Color RoleColor { get; } = new Color( 255f, 0f, 0f );
		public DClass()
		{
		}

		public DClass( Client cl, string firstname, string lastname, int regnumber ) : base( cl )
		{
			FirstName = firstname;
			LastName = lastname;
			RegNumber = regnumber;
			Clothes = System.Array.Empty<string>();
			RoleplayName = "D-" + RegNumber;
			cl.SetValue( "rpname", RoleplayName );
			RoleName = "D Class";
			cl.SetValue( "role", RoleName );
		}
	}
}
