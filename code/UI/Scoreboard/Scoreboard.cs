
using Sandbox;
using Sandbox.Hooks;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SCP.UI
{
	public partial class Scoreboard<T> : Panel where T : ScoreboardEntry, new()
	{
		public Panel ScoreboardBack { get; protected set; }
		public Panel Canvas { get; protected set; }
		Dictionary<Client, T> Rows = new();
		private bool IsOpen = false;

		public Panel Header { get; protected set; }

		public Scoreboard()
		{
			StyleSheet.Load( "/UI/Scoreboard/Oui/Scoreboard.scss" );
			AddClass( "scoreboard" );


			AddHeader();

			Canvas = Add.Panel( "canvas" );

		}

		public override void Tick()
		{
			base.Tick();
			if ( Input.Pressed( InputButton.Score ) )
			{
				IsOpen = !IsOpen;
				SetClass( "open", IsOpen );

			}
			if ( !IsVisible )
			{
				return;
			}

			foreach ( var client in Client.All.Except( Rows.Keys ) )
			{
				var entry = AddClient( client );
				Rows[client] = entry;
			}

			foreach ( var client in Rows.Keys.Except( Client.All ) )
			{
				if ( Rows.TryGetValue( client, out var row ) )
				{
					row?.Delete();
					Rows.Remove( client );
				}
			}

		}


		protected virtual void AddHeader()
		{
			Header = Add.Panel( "header" );
			Header.Add.Label( "Name", "name" );
			Header.Add.Label( "Role", "role" );
			Header.Add.Label( "Rank", "rank" );
			Header.Add.Label( "Ping", "ping" );

		}

		protected virtual T AddClient( Client entry )
		{
			var p = Canvas.AddChild<T>();
			p.Client = entry;
			return p;
		}
	}
}
