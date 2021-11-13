using Sandbox;
using Sandbox.UI;
using SCP;

namespace SCP.UI
{
	public partial class SpawnHUD : RootPanel
	{
		public SpawnHUD()
		{
			AddChild<DepartmentChoice>();
			
		}
	}
}

