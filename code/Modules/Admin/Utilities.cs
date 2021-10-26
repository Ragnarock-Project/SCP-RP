using Sandbox;
using SCP;

namespace SCP.Modules.Admin
{
	class Utilities : MainPlayer
	{
		public bool cloack { get; set; } = false;
		
		public Utilities() { }


		public void setCloack(bool value)
		{
			base.RoleName = "test";
			this.cloack = value;
		}
	}
}
