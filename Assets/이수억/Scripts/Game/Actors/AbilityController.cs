using DevelopeCommon;
using UnityEngine;

public class AbilityController : PlayerController
{
    public AbilityHealing heal;
    public AbilityOrbit orbit;
    public AbilityDivine divine;
    public AbilityFlame flame;

    public AbilityKind kinds;

    public override void Init( Character c )
    {
        base.Init( c );
        heal.Init( c );
        orbit.Init( c );
        divine.Init( c );
    }

    public void AddAbility(AbilityKind kind)
    {
        kinds |= kind;
        c.stat.AddAbility( kind );

        Log.to.I( $"[Ability] Get - {kind}" );

        if ( kind == AbilityKind.Healing_1 || kind == AbilityKind.Healing_2 || kind == AbilityKind.Healing_3 )
            heal.Activate();

        if( kind == AbilityKind.AroundBall ) {
            orbit.Activate();
        }

        if( kind == AbilityKind.Divine ) {
            divine.Activate();
        }

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
    }

    void Cheat()
    {
        if ( Input.GetKey( KeyCode.LeftShift ) ) {
            if ( Input.GetKeyDown( KeyCode.Alpha1 ) ) {
                AddAbility( AbilityKind.Triple );
            }

            if ( Input.GetKeyDown( KeyCode.Alpha2 ) ) {
                AddAbility( AbilityKind.Double );
            }
        }
    }
}
