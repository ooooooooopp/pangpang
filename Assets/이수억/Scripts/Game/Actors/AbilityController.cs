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
        flame.Init( c );
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

        if( kind == AbilityKind.Flame ) {
            flame.Activate();
        }

        AudioController.Play( "AbilitySelect" );
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
        
        Cheat();
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
            if ( Input.GetKeyDown( KeyCode.Alpha3 ) ) {
                AddAbility( AbilityKind.BulletBonus_3 );
            }
            if ( Input.GetKeyDown( KeyCode.Alpha4 ) ) {
                AddAbility( AbilityKind.AroundBall );
            }
            if ( Input.GetKeyDown( KeyCode.Alpha5 ) ) {
                AddAbility( AbilityKind.Flame );
            }

            if ( Input.GetKeyDown( KeyCode.L ) ) {
                AddAllAbility();
            }
        }
    }

    void AddAllAbility()
    {
        var abilites = System.Enum.GetValues( typeof( AbilityKind ) );
        foreach ( var item in abilites ) {
            AbilityKind abil = (AbilityKind)item;
            if ( abil == AbilityKind.None )
                continue;
            AddAbility( abil );
        }
    }
}
