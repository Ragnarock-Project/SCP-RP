using Sandbox.UI;

namespace SCP.UI
{
	public partial class SpawnHUD : Sandbox.HudEntity<RootPanel>
	{
		public SpawnHUD()
		{
			if ( !IsClient )
				return;
			RootPanel.AddChild<MOTD>();
		}
		public void ChangeMenu(bool firstCall )
		{
			if( firstCall )
			{
				RootPanel.AddChild<DepartmentChoice>();
			}
			else
			{
				RootPanel.AddChild<CharacterCreation>();
			}
		}
	}
}

