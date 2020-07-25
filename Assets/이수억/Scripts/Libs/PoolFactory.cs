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
        PoolMgr.In.Create( PoolMgr.POOL_MONSTER, "Prefabs/Monsters/" );
        PoolMgr.In.Create( PoolMgr.POOL_SKILL, "Prefabs/Skill/" );
        PoolMgr.In.Create( PoolMgr.POOL_FX, "Prefabs/Fx/" );
    }

    public Bullet GenerateBullet(string prefabName, Transform parent )
    {
        var obj = PoolMgr.In.GetSafe( PoolMgr.POOL_BULLET, prefabName ).GetComponent<Bullet>();
        obj.cTrf.SetParentTm( parent );
        return obj;
    }

    public SBall GenerateBall( string prefabName, Transform parent )
    {
        var obj = PoolMgr.In.GetSafe( PoolMgr.POOL_MONSTER, prefabName ).GetComponent<SBall>();
        obj.cTrf.SetParentTm( parent );
        return obj;
    }

    public Skill GenerateSkill( string prefabName, Transform parent )
    {
        var obj = PoolMgr.In.GetSafe( PoolMgr.POOL_SKILL, prefabName ).GetComponent<Skill>();
        obj.cTrf.SetParentTm( parent );
        return obj;
    }

    public ParticleFx GenerateFx( string prefabName, Transform parent )
    {
        var obj = PoolMgr.In.GetSafe( PoolMgr.POOL_FX, prefabName ).GetComponent<ParticleFx>();
        obj.cTrf.SetParentTm( parent );
        return obj;
    }
}