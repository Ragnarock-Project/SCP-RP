using Sandbox;

namespace SCP
{
	/// <summary>
	/// An override of the basic WalkController allowing to block stamina when it's below 0
	/// </summary>
	class MainWalkController : WalkController
	{
		public override float GetWishSpeed()
		{
			var ws = Duck.GetWishSpeed();
			var ply = Pawn as MainPlayer;
			if ( ws >= 0 ) return ws;

			if ( Input.Down( InputButton.Run ) && ply.Stamina > 0 ) return SprintSpeed;
			if ( Input.Down( InputButton.Walk  ) ) return WalkSpeed;

			return DefaultSpeed;
		}
	}
}
