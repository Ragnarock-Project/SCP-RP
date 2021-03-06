using Sandbox;
using System;

namespace SCP
{
	/// <summary>
	/// The parent class of all human departments
	/// </summary>
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
		public float Food { get; set; } = 100f;
		[Net]
		public string[] Clothes { get; set; }

		public string modelPath = "models/citizen/citizen.vmdl";
		private float fallSpeed;

		private TimeSince timeSinceJumpReleased;

		private bool FirstSpawn = true;

		public MainPlayer()
		{
		}
		public MainPlayer( Client cl ) : this()
		{
			this.RoleplayName = cl.Name;
			cl.SetValue( "rpname", RoleplayName );
			cl.SetValue( "rank", "Player" );
		}

		public override void Respawn()
		{
			SetModel( this.modelPath );
			Dress( Clothes );
			if ( !FirstSpawn )
				FirstSpawn = false;

			Controller = new MainWalkController();
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
			
			var ragdoll = new ModelEntity();
				ragdoll.SetModel( "models/citizen/citizen.vmdl" );
				ragdoll.Position = EyePos + EyeRot.Forward * 40;
				ragdoll.Rotation = Rotation.LookAt( Vector3.Random.Normal );
				ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
				ragdoll.PhysicsGroup.Velocity = EyeRot.Forward * 1000;

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
							RegenStamina( 0.2f );
						}
					}

				}
				else
				{
					RegenStamina( 0.2f );
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

			if (Input.Pressed( InputButton.Voice ) )
			{
				if (Controller is MainWalkController)
				{
					Controller = new NoclipController();
				}
				else
				{
					Controller = new MainWalkController();
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
		/// <summary>
		/// Manages the damages dealt by a fall
		/// </summary>
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

		/// <summary>
		/// Restore the player's stamina when called
		/// </summary>
		/// <param name="regenRate">Stamina regeneration rate applied, multiplied by 1.5 if the player does not move</param>
		private void RegenStamina( float regenRate )
		{
			if ( Stamina < 100f )
			{
				if ( Math.Abs( base.Velocity.y ) < 50 && Math.Abs( base.Velocity.x ) < 50 )
				{
					Stamina += (regenRate * 1.5f);
				}
				else
				{
					Stamina += regenRate;
				}

			}
			else if ( Stamina > 100f )
			{
				Stamina = 100f;
			}
		}
	}

}
