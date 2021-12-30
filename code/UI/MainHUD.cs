using Sandbox.UI;

namespace SCP.UI
{
	/// <summary>
	/// The HUD used in game
	/// </summary>
	public partial class MainHUD : RootPanel
	{
		public MainHUD()
		{
			AddChild<Vitals>();
			AddChild<NameTags>();
			AddChild<CrosshairCanvas>();
			AddChild<ChatBox>();
			AddChild<VoiceList>();
			AddChild<KillFeed>();
			AddChild<Scoreboard<ScoreboardEntry>>();
			AddChild<PlayerData>();
		}
	}
}

