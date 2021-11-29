using Sandbox;
using System.Collections.Generic;

namespace SCP
{
	public class ClothingEntity : ModelEntity
	{

	}
	abstract partial class MainPlayer
	{

		Stack<ModelEntity> Mdl = new();
		bool dressed = false;

		public void Dress( string[] clothes )
		{

			if ( dressed ) return;
			dressed = true;
			for ( int i = 0; i < clothes.Length; i++ )
			{

				var tempMdl = new ClothingEntity();
				tempMdl.SetModel( clothes[i] );
				tempMdl.SetParent( this, true );
				tempMdl.EnableShadowInFirstPerson = true;
				tempMdl.EnableHideInFirstPerson = true;
				Mdl.Push( tempMdl );
			}


		}

		public void Dress()
		{
			if ( !dressed ) return;
			dressed = false;
			int MdlCounter = Mdl.Count;
			for ( int i = 0; i < MdlCounter; i++ )
			{
				Mdl.Peek().Delete();
				Mdl.Pop();
			}

		}

	}
}
