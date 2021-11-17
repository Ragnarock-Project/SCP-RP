using Sandbox;
using System;
using System.Text.Json;
using SCP;
using SCP.Modules.Admin;

namespace SCP
{

	 abstract partial class MainPlayer : Player
	{
		[Net]
		public string RoleplayName { get; set; } = "";
		[Net]
		public string FirstName { get; set; } = "";
		[Net]
		public string LastName { get; set; } = "";
		[Net]
		public int RegNumber { get; set; } = 0;
		[Net]
		public string RoleName { get; set; } = "";

		[Net, Local]
		public float Stamina { get; set; } = 100f;
		[Net, Local]
		public float Food { get; set; }  = 100f;
		[Net]
		public string[] Clothes { get; set; }
		
		
		public string modelPath = "models/citizen/citizen.vmdl";
		private float fallSpeed;
		
		private TimeSince timeSinceJumpReleased;

		private bool FirstSpawn = true;

		public MainPlayer() {
			Inventory = new Inventory(this);
		}
		public MainPlayer( Client cl ) : this()
		{
			this.RoleplayName = cl.Name;
			cl.SetValue( "rpname", RoleplayName);
			cl.SetValue( "rank", "Player" );

		}

		public override void Respawn()
		{
			SetModel(this.modelPath);
			Dress( Clothes );
			if ( !FirstSpawn )
				FirstSpawn = false;

			Controller = new SCPWalkController();
			Animator = new StandardPlayerAnimator();
			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;


			base.Respawn();
		}

		public override void OnKilled()
		{
			base.OnKilled();

			Controller = null;
			EnableAllCollisions = false;
			EnableDrawing = false;


		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			TickPlayerUse();



			if ( LifeState != LifeState.Alive )
				return;


			var controller = GetActiveController();

			if ( controller != null )
				EnableSolidCollisions = !controller.HasTag( "noclip" );

			if ( IsServer && !controller.HasTag( "noclip" ) )
			{
				if ( Input.Down( InputButton.Run ) )
				{
					if ( Stamina > 0 )
					{
						if ( Math.Abs( base.Velocity.y ) > 200 || Math.Abs( base.Velocity.x ) > 200 )
						{
							Stamina -= 0.3f;
						}
						else
						{
							RegenStamina();
						}

					}

				}
				else
				{
					RegenStamina();
				}
			}


			if ( Input.Pressed( InputButton.View ) )
			{
				if ( Camera is ThirdPersonCamera )
				{
					Camera = new FirstPersonCamera();
				}
				else
				{
					Camera = new ThirdPersonCamera();

				}
			}


			if ( Input.Released( InputButton.Jump ) )
			{
				if ( timeSinceJumpReleased < 0.3f )
				{
					Game.Current?.DoPlayerNoclip( cl );
				}

				timeSinceJumpReleased = 0;
			}

			if ( Input.Left != 0 || Input.Forward != 0 )
			{
				timeSinceJumpReleased = 1;
			}

			FallDamages();


		}

		private void FallDamages()
		{

			if ( GroundEntity != null )
			{
				if ( fallSpeed < -500 )
				{
					float fallDamageAmount = (fallSpeed + 500) / 3;
					var fallDamageInfo = DamageInfo.Generic( (fallDamageAmount * fallDamageAmount / 50) / 4 );
					base.TakeDamage( fallDamageInfo );
					fallSpeed = 1;
				}

			}

			fallSpeed = base.Velocity.z;
		}

		private void RegenStamina()
		{
			if ( Stamina < 100f )
			{
				if ( Math.Abs( base.Velocity.y ) < 50 && Math.Abs( base.Velocity.x ) < 50 )
				{
					Stamina += 0.3f;
				}
				else
				{
					Stamina += 0.2f;
				}
					
			}else if (Stamina > 100f )
			{
				Stamina = 100f;
			}
		}

		

		public override void TakeDamage(DamageInfo damages)
		{
			base.TakeDamage( damages );
		}

		[ServerCmd("inventory_current")]
		public static void SetInventoryCurrent(string entName)
		{
			var target = ConsoleSystem.Caller.Pawn;
			if (target == null) return;

			var inventory = target.Inventory;
			if (inventory == null)
				return;

			for (int i = 0; i < inventory.Count(); ++i)
			{
				var slot = inventory.GetSlot(i);
				if (!slot.IsValid())
					continue;

				if (!slot.ClassInfo.IsNamed(entName))
					continue;

				inventory.SetActiveSlot(i, false);

				break;
			}
		}

	}

}
