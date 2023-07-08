using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : HoldToCastAbility
{
    override public string name {
        get { return "test"; }
    }

    public override int value {
        get { return 0; }
    }

     public override void SetAbilityEffect()
    {
        Debug.Log("Nothing to do here");
    }

    public override void RemoveAbilityEffect()
    {
        
    }
}
