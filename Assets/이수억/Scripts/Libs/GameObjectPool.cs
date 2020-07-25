using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool
{
	string _path;
	Transform _group;
	public Transform group { get { return _group; } }

	Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>();
	Dictionary<string, Queue<GameObject>> _pool = new Dictionary<string, Queue<GameObject>>();

	public GameObjectPool( Transform group, string resPath )
	{
		Init( group, resPath );
	}

	public GameObjectPool( string groupName, string resPath )
	{
		Init( new GameObject( groupName ).transform, resPath );
	}

	public void Init( Transform group, string resPath )
	{
		_group = group;
		_path = resPath;
		if ( !resPath.Contains( "/" ) )
			_path += "/";
	}

	public void Destroy()
	{
		foreach ( var q in _pool.Values ) {
			foreach ( var e in q ) {
				GameObject.Destroy( e );
			}
			q.Clear();
		}
		_pool.Clear();
		_prefabs.Clear();
	}

	#region Loading resource
	Queue<GameObject> GetQ( string name )
	{
		Queue<GameObject> q;
		if ( !_pool.TryGetValue( name, out q ) )
			return null;
		return q;
	}

	public void MakePool( string name, GameObject prefab, int instCount )
	{
		_prefabs.Add( name, prefab );
		_pool.Add( name, new Queue<GameObject>() );

		InstantiateToPool( name, instCount );
	}

	public void MakePool( string name, int instCount )
	{
		GameObject prefab = Load( _path + name );
		if ( prefab == null ) {
			Dbg.E( "Prefab loading failed! - {0}", _path + name );
			return;
		}
		MakePool( name, prefab, instCount );
	}
	public GameObject Load( string name )
	{
		var go = Resources.Load<GameObject>( name );
		if ( go == null ) {
			Dbg.E( "Loading failed! - " + name );
		}
		return go;
	}
	#endregion

	/// <summary>
	/// 프리펩이 _prefab에 로딩되어 있다는 가정 하에,
	/// 인스턴스를 만들어 _pool에 적재한다.
	/// </summary>
	/// <param name="name">리소스 이름.</param>
	/// <param name="count">생성하려는 인스턴스 갯수.</param>
	public void InstantiateToPool( string name, int count = 1 )
	{
		GameObject prefab = _prefabs[name];

		for ( int i = 0; i < count; i++ ) {
			GameObject inst = GameObject.Instantiate<GameObject>( prefab );
			inst.name = name;
			if ( _group != null )
				inst.transform.SetParent( _group, false );
			Put( inst );
		}
	}

	/// <summary>
	/// pool에 인스턴스를 환원 시킨다.
	/// GameObject.name 으로 풀을 관리하므로 이름 안바뀌게 주의.
	/// </summary>
	public void Put( GameObject go )
	{
		go.SetActive( false );
		go.transform.SetParent( _group, false );      // Layer안바뀌게 조심 (Don't use AddChild).
		_pool[go.name].Enqueue( go );
	}

	/// <summary>
	/// pool에서 인스턴스를 하나 꺼낸다.
	/// 만약 pool에 여유분이 없으면 Instantiate를 통해 새로 생성한다.
	/// 만약 pool도 없으면 null을 리턴한다.
	/// </summary>
	public GameObject Get( string name )
	{
		Queue<GameObject> q = GetQ( name );
		if ( q == null )
			return null;
		if ( q.Count == 0 )
			InstantiateToPool( name, 1 );

		GameObject go = q.Dequeue();        //큐에 null 이 3개 ( 풀에 널이 3개 들어있을수있다 )?
		go.SetActive( true );
		return go;
	}

	/// <summary>
	/// pool에서 인스턴스를 하나 꺼낸다.
	/// 만약 pool에 여유분이 없으면 Instantiate를 통해 새로 생성한다.
	/// MakePool도 하지 않은 상태면 prefab도 새로 로딩하므로 첫 실행은 매우 느려질 수 있다.
	/// </summary>
	public GameObject GetSafe( string name )
	{
		GameObject go = Get( name );
		if ( go == null ) {
			MakePool( name, 1 );
			go = Get( name );
		}
		return go;
	}
}
