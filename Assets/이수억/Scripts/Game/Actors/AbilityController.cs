using DevelopeCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : PlayerController
{
    public AbilityKind kinds;

    public void AddAbility(AbilityKind kind)
    {
        kinds |= kind;
        c.stat.AddAbility( kind );

        Log.to.I( $"[Ability] Get - {kind}" );

        Broadcaster.SendEvent( Constant.Event.RefreshUI, TypeOfMessage.dontRequireReceiver );
    }

    public bool HasAbility(AbilityKind kind )
    {
        if ( (kinds & kind) > 0 )
            return true;
        return false;
    }

    public void Clear()
    {
        kinds = AbilityKind.None;
    }


    public override void Process()
    {
        base.Process();

        if( Input.GetKey( KeyCode.LeftShift ) ) {
            if( Input.GetKeyDown( KeyCode.Alpha1 ) ) {
                AddAbility( AbilityKind.Triple );
            }

            if ( Input.GetKeyDown( KeyCode.Alpha2 ) ) {
                AddAbility( AbilityKind.Double );
            }
        }
    }

}
