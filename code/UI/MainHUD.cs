using Sandbox;
using Sandbox.UI;
using SCP;

namespace SCP.UI
{
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

