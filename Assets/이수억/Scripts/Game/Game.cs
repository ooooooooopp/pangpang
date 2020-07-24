using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	public StageConstructor con;

	Coroutine playCo = null;

	public void Start()
	{
		Play();
	}

	public void Play()
	{
		Log.Seq.I( $"Game Play()" );

		if ( playCo != null ) StopCoroutine( playCo );
		playCo = StartCoroutine( PlayCo() );
	}

	IEnumerator PlayCo()
	{
		yield return null;

		PoolFactory.In.Init();
		StageMan.In.Init( con );
	}


}
