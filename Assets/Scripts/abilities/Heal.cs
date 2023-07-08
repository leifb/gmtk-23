using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : HoldToCastAbility
{
    override public string name {
        get { return "heal"; }
    }

    public override int value {
        get { return 20; }
    }

    public override void SetAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        Health health = character.GetComponent<Health>();
        health.heal(value);
    }

    public override void RemoveAbilityEffect()
    {
        
    }
}
