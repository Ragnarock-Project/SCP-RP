using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace SCP.UI
{
	/// <summary>
	/// The box where player's data are displayed
	/// </summary>
	public partial class PlayerData : Panel
	{

		private readonly Label RpName;

		public PlayerData()
		{

			StyleSheet.Load( "/ui/PlayerData.scss" );

			Panel vitalsBack = Add.Panel( "playerDataBack" );

			RpName = vitalsBack.Add.Label( "0", "rpNameText" );

		}
		/// <summary>
		/// Called every tick, by default 60 times per second
		/// </summary>
		public override void Tick()
		{
			base.Tick();

			var player = Local.Pawn as MainPlayer;
			if ( player == null ) return;

			RpName.Text = player.RoleplayName;

		}
	}
}
