using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace SCP.UI
{
	/// <summary>
	/// Represents player's stamina and health
	/// </summary>
	public partial class Vitals : Panel
	{
		private readonly Label Health;
		private readonly Panel HealthBar;

		private readonly Label Stam;
		private readonly Panel StamBar;

		public Vitals()
		{

			StyleSheet.Load( "/ui/Vitals.scss" );
			Panel vitalsBack = Add.Panel( "vitalsBack" );

			// Health
			Panel healthBarBack = vitalsBack.Add.Panel( "healthBarBack" );
			HealthBar = healthBarBack.Add.Panel( "healthBar" );

			healthBarBack.Add.Label( "favorite", "healthIcon" );

			Health = healthBarBack.Add.Label( "0", "healthText" );


			// Stamina
			Panel stamBarBack = vitalsBack.Add.Panel( "stamBarBack" );
			StamBar = stamBarBack.Add.Panel( "stamBar" );

			stamBarBack.Add.Label( "directions_run", "stamIcon" );

			Stam = stamBarBack.Add.Label( "0", "stamText" );

		}
		/// <summary>
		/// Called every tick, by default 60 times per second
		/// </summary>
		public override void Tick()
		{
			base.Tick();

			var player = Local.Pawn as MainPlayer;
			if ( player == null ) return;

			Health.Text = $"{player.Health.CeilToInt()}";
			HealthBar.Style.Width = Length.Percent( player.Health );

			Stam.Text = $"{player.Stamina.CeilToInt()}";
			StamBar.Style.Width = Length.Percent( player.Stamina );

		}
	}
}

