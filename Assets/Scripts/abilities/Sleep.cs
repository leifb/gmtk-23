using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : HoldToCastAbility
{
    override public string name {
        get { return "sleep"; }
    }

    public override int value {
        get { return 5; }
    }

    public override void SetAbilityEffect()
    {
        GameObject character = GameObject.Find("character");
        CharacterAi characterAi = character.GetComponent<CharacterAi>();
        characterAi.Sleep(value);
    }

    public override void RemoveAbilityEffect()
    {
        
    }
}
