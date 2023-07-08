using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDexterity : HoldToCastAbility
{
    override public string name {
        get { return "buff_dexterity"; }
    }

    public override int value {
        get { return 5; }
    }

    public override void SetAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.dexterity = value;
    }

    public override void RemoveAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CombatStats combatStats = character.GetComponent<CombatStats>();
        combatStats.dexterity = 1;
    }
}
