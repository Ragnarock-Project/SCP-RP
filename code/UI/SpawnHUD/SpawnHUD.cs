using Sandbox.UI;

namespace SCP.UI
{
	/// <summary>
	/// The HUD used before the player spawned
	/// </summary>
	public partial class SpawnHUD : Sandbox.HudEntity<RootPanel>
	{
		public SpawnHUD()
		{
			if ( !IsClient )
				return;
			RootPanel.AddChild<MOTD>();
		}
	}
}

