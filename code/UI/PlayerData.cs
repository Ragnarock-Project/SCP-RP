using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace SCP.UI
{
	public partial class PlayerData : Panel
	{

		private readonly Label RpName;

		public PlayerData()
		{

			StyleSheet.Load( "/ui/PlayerData.scss" );

			Panel vitalsBack = Add.Panel( "playerDataBack" );

			RpName = vitalsBack.Add.Label( "0", "rpNameText" );

		}

		public override void Tick()
		{
			base.Tick();

			var player = Local.Pawn as MainPlayer;
			if ( player == null ) return;

			RpName.Text = player.RoleplayName;

		}
	}
}

