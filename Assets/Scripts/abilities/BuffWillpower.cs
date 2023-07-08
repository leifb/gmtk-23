using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffWillpower : HoldToCastAbility
{
    override public string name {
        get { return "buff_willpower"; }
    }

    public override int value {
        get { return 5; }
    }

    public override void SetAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.willpower = value;
    }

    public override void RemoveAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.willpower = 1;
    }
}
