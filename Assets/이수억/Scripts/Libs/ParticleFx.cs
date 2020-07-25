using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent( typeof( SortingGroup ) )]
[RequireComponent( typeof( ParticleSystem ) )]
public class ParticleFx : Actor, IPoolObject
{
    [SerializeField]
    ParticleSystem[] particleSystems = null;
    SortingGroup sortingGroup;

    [SerializeField]
    float _duration = 0f;

    Coroutine _coroutine = null;


    private void Reset()
    {
        if ( sortingGroup == null )
            sortingGroup = GetComponent<SortingGroup>();

        //sortingGroup.sortingLayerName = SortingLayerName.VisibleParticles;
    }

    private void Awake()
    {
        if ( sortingGroup == null )
            sortingGroup = GetComponent<SortingGroup>();

        //sortingGroup.sortingLayerName = SortingLayerName.VisibleParticles;

        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    public void Activate( Vector3 pos, float lifeTime = 0f )
    {
        position = pos;
        Play( lifeTime );
    }

    public void SetScale( float ratio )
    {
        cTrf.localScale *= ratio;
    }

    public void Deactivate()
    {
        cTrf.localScale = Vector3.one;
    }

    public void Recycle()
    {
        Deactivate();
        PoolMgr.In.Put( PoolMgr.POOL_FX, cGameObj );
    }

    private void OnDestroy()
    {
        if ( _coroutine != null ) {
            StopCoroutine( _coroutine );
        }
    }

    public void Play( float lifeTime = 0f )
    {
        bool isLoop = false;

        for ( int i = 0; i < particleSystems.Length; ++i ) {
            _duration = Mathf.Max( _duration, particleSystems[i].main.duration );
            particleSystems[i].Play();

            if ( isLoop == false && particleSystems[i].main.loop ) {
                isLoop = true;
            }
        }

        if ( isLoop == false ) {
            _coroutine = StartCoroutine( OnDurationEnd( _duration ) );
        } else if ( lifeTime > 0f ) {
            _coroutine = StartCoroutine( OnDurationEnd( lifeTime ) );
        } else {
            // do nothing
        }
    }

    public IEnumerator OnDurationEnd( float duration )
    {
        yield return new WaitForSeconds( duration );
        Recycle();
    }

}
