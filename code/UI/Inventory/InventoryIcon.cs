﻿
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class InventoryIcon : Panel
{
	public Entity TargetEnt;
	public Label Label;
	public Label Number;

	public InventoryIcon( int i, Panel parent )
	{
		StyleSheet.Load("/ui/Inventory/InventoryIcon.scss");
		Parent = parent;
		Label = Add.Label( "empty", "item-name" );
		Number = Add.Label( $"{i}", "slot-number" );
	}

	public void Clear()
	{
		Label.Text = "";
		SetClass( "active", false );
	}
}