using Sandbox.UI;

namespace SCP.UI
{
	public partial class SpawnHUD : Sandbox.HudEntity<RootPanel>
	{
		public SpawnHUD()
		{
			if ( IsClient )
			{
				RootPanel.AddChild<DepartmentChoice>();
				
			}
		}
	}
}

