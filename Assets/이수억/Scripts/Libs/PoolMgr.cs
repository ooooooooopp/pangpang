using UnityEngine;
using System.Collections.Generic;

public class PoolMgr : SingletonMono<PoolMgr>
{
	public const string POOL_BULLET = "Pool_Bullet_Group";
	public const string POOL_MONSTER = "Pool_Monster_Group";

	Dictionary<string, GameObjectPool> _pools = new Dictionary<string, GameObjectPool>();

	public GameObjectPool Create( GameObject groupHolder, string resPath )
	{
		GameObjectPool pool = GetPool( groupHolder.name );
		if ( pool == null ) {
			pool = new GameObjectPool( groupHolder.transform, resPath );
			_pools.Add( groupHolder.name, pool );
		}
		return pool;
	}

	public GameObjectPool Create( string groupName, string resPath )
	{
		GameObjectPool pool = GetPool( groupName );
		if ( pool == null ) {
			pool = new GameObjectPool( groupName, resPath );
			_pools.Add( groupName, pool );
		}
		return pool;
	}

	public GameObjectPool GetPool( string groupName )
	{
		if ( !_pools.TryGetValue( groupName, out GameObjectPool pool ) )
			return null;
		return pool;
	}

	public GameObjectPool GetPoolSafe( string groupName )
	{
		GameObjectPool pool = GetPool( groupName );
		if ( pool == null )
			pool = Create( groupName, groupName );
		return pool;
	}

	public GameObjectPool this[string groupName] {
		get { return GetPool( groupName ); }
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="groupName"> 풀 그룹 이름 </param>
	/// <param name="name">  프리팹 이름 </param>
	/// <returns></returns>
	public GameObject GetSafe( string groupName, string name )
	{
		return GetPoolSafe( groupName ).GetSafe( name );
	}

	public void Put( string groupName, GameObject go )
	{
		GetPool( groupName ).Put( go );
	}

	/// <summary>
	/// 임시로 전환시 풀비우기 기능.
	/// </summary>
	public void Destory()
	{
		var pools = new List<GameObjectPool>( _pools.Values );
		foreach ( var item in pools ) {
			item.Destroy();
		}
		_pools.Clear();
	}
}
