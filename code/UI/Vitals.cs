using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace SCP.UI
{
	public partial class Vitals : Panel
	{
		private readonly Label Health;
		private readonly Panel HealthBar;

		private readonly Label Armor;
		private readonly Panel ArmorBar;

		private readonly Label Stam;
		private readonly Panel StamBar;

		private readonly Label Job;
		private readonly Label RpName;

		public Vitals()
		{


			StyleSheet.Load( "/ui/Vitals.scss" );
			Panel vitalsBack = Add.Panel( "vitalsBack" );

			// Health
			Panel healthBarBack = vitalsBack.Add.Panel( "healthBarBack" );
			HealthBar = healthBarBack.Add.Panel( "healthBar" );

			healthBarBack.Add.Label( "favorite", "healthIcon" );

			Health = healthBarBack.Add.Label( "0", "healthText" );

			// Armor
			Panel armorBarBack = vitalsBack.Add.Panel( "armorBarBack" );
			ArmorBar = armorBarBack.Add.Panel( "armorBar" );

			armorBarBack.Add.Label( "shield", "armorIcon" );

			Armor = armorBarBack.Add.Label( "0", "armorText" );
			// Stamina
			Panel stamBarBack = vitalsBack.Add.Panel( "stamBarBack" );
			StamBar = stamBarBack.Add.Panel( "stamBar" );


			stamBarBack.Add.Label( "directions_run", "stamIcon" );


			Stam = stamBarBack.Add.Label( "0", "stamText" );

			Job = vitalsBack.Add.Label( "0", "jobText" );
			RpName = vitalsBack.Add.Label( "0", "rpNameText" );


		}

		public override void Tick()
		{
			base.Tick();

			var player = Local.Pawn as MainPlayer;
			if ( player == null ) return;

			Job.Text = player.RoleName;
			RpName.Text = player.RoleplayName;

			Health.Text = $"{player.Health.CeilToInt()}";

			HealthBar.Style.Dirty();
			HealthBar.Style.Width = Length.Percent( player.Health );

			Armor.Text = $"{player.Armor.CeilToInt()}";

			ArmorBar.Style.Dirty();
			ArmorBar.Style.Width = Length.Percent( player.Armor );

			Stam.Text = $"{player.Stamina.CeilToInt()}";

			StamBar.Style.Dirty();
			StamBar.Style.Width = Length.Percent( player.Stamina );

		}
	}
}

