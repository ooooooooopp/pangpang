using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityOrbit : Ability
{
	public GameObject pfOrbit;
	public List<Orbit> orbits = new List<Orbit>();

	public void Activate()
	{
		orbits.Add( GenOrbit( new Vector3( 1f, 0, 0 ) ) );
		orbits.Add( GenOrbit( new Vector3( -1f, 0, 0 ) ) );
	}

	public void DeActivate()
	{
		for ( int i = orbits.Count - 1; i >= 0; i-- ) {
			Destroy( orbits[i].gameObject );
		}
		orbits.Clear();
	}

	Orbit GenOrbit(Vector3 offset )
	{
		var orbit = Instantiate( pfOrbit, transform ).GetComponent<Orbit>();
		orbit.Activate( offset, c );
		return orbit;
	}

}
