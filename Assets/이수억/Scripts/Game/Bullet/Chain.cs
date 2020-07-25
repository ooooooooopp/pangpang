using UnityEngine;

namespace Projectile
{
	public class Chain : Bullet
	{
		public LineRenderer line;
		public BoxCollider2D col;

		Vector3 growVec;
		public override void Activate( Vector3 pos )
		{
			base.Activate( pos );
			line.positionCount = 2;
			line.SetPosition( 0, pos );
			line.SetPosition( 1, pos );
			col.size = new Vector2( col.size.x, 0 );


			if ( data.angleZ == -45f ) {
				growVec = new Vector3( 1f, 1f, 0 );
			}
			else if( data.angleZ == 45f ) {
				growVec = new Vector3( -1f, 1f, 0 );
			} else {
				growVec = Vector3.up;
			}
		}

		public override void DeActivate()
		{
			line.SetPosition( 0, Vector3.zero );
			line.SetPosition( 1, Vector3.zero );
			col.size = new Vector2( col.size.x, 0 );
			base.DeActivate();
		}

		public override void Process()
		{
			position += growVec * Time.deltaTime * data.speed * 2f;

			line.SetPosition( 1, new Vector3( position.x, position.y, position.z ) );

			col.size = new Vector2( col.size.x, Mathf.Abs( line.GetPosition( 0 ).y - line.GetPosition( 1 ).y ) + 0.5f );
			col.offset = new Vector2( 0, (col.size.y * -0.5f) + 0.25f);
		}
	}
}


public static class ComplexEx
{
	public static Vector2 ComplexMult( this Vector2 aVec, Vector2 aOther )
	{
		return new Vector2( aVec.x * aOther.x - aVec.y * aOther.y, aVec.x * aOther.y + aVec.y * aOther.x );
	}
	public static Vector2 Rotation( float aDegree )
	{
		float a = aDegree * Mathf.Deg2Rad;
		return new Vector2( Mathf.Cos( a ), Mathf.Sin( a ) );
	}
	public static Vector2 Rotate( this Vector2 aVec, float aDegree )
	{
		return ComplexMult( aVec, Rotation( aDegree ) );
	}
}
