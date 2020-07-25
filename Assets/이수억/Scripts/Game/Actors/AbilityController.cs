using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : PlayerController
{
    public AbilityKind kinds;

    public void AddAbility(AbilityKind kind)
    {
        kinds |= kind;
    }

    public void Clear()
    {
        kinds = AbilityKind.None;
    }
}
