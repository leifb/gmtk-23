using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffInteligence : HoldToCastAbility
{
    override public string name {
        get { return "buff_inteligence"; }
    }

    public override int value {
        get { return 5; }
    }

    public override void SetAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.intelligence = value;
    }

    public override void RemoveAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.intelligence = 1;
    }
}
