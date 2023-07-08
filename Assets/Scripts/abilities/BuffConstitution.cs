using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffConstitution : HoldToCastAbility
{
    override public string name {
        get { return "buff_constitution"; }
    }

    public override int value {
        get { return 5; }
    }

    public override void SetAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.constitution = value;
    }

    public override void RemoveAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.constitution = 1;
    }
}
