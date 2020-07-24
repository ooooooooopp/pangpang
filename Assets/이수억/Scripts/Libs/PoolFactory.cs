using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile;

public class PoolFactory : MonoSingleton<PoolFactory>
{
    /// <summary>
    /// 매씬마다 호출해서 그룹을 만들어줘야한다.
    /// </summary>
    public void Init()
    {
        PoolMgr.In.Create( PoolMgr.POOL_BULLET, "Prefabs/Bullet/" );
    }

    public Bullet GenerateBullet(string prefabName, Transform parent )
    {
        var obj = PoolMgr.In.GetSafe( PoolMgr.POOL_BULLET, prefabName ).GetComponent<Bullet>();
        obj.cTrf.SetParentTm( parent );
        return obj;
    }

    //public Card GenerateCard( string prefabName, Transform parent )
    //{
    //    var obj = PoolMgr.In.GetSafe( PoolMgr.POOL_CARD, prefabName ).GetComponent<Card>();
    //    obj.transform.SetParentTm( parent );
    //    return obj;
    //}
}