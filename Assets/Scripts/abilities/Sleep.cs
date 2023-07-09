using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : HoldToCastAbility
{
    override public string name
    {
        get { return "sleep"; }
    }

    public override int value
    {
        get { return 5; }
    }

    private bool isOnCooldown = false;

    public override void SetAbilityEffect()
    {
        if (!isOnCooldown)
        {
            isOnCooldown = true;
            GameObject character = GameObject.Find("character");
            CharacterAi characterAi = character.GetComponent<CharacterAi>();
            characterAi.Sleep(value);
            Health health = character.GetComponent<Health>();
            health.heal(value);

            Transform heal = GameObject.Find("sleep").transform;

            Image cooldownOverlay = heal.Find("cooldown").GetComponent<Image>();

            cooldownOverlay.enabled = true;
            Transform cooldownTimer = heal.Find("timer");
            Text cooldownTimerText = cooldownTimer.GetComponent<Text>();
            cooldownTimerText.enabled = true;

            cooldownTimer.GetComponent<CooldownTimer>().TriggerCooldown(20, RemoveCooldown);
        }
    }

    public override void RemoveAbilityEffect()
    {

    }

    private void RemoveCooldown()
    {
        isOnCooldown = false;
        Transform heal = GameObject.Find("sleep").transform;

        Image cooldownOverlay = heal.Find("cooldown").GetComponent<Image>();

        cooldownOverlay.enabled = false;
        Transform cooldownTimer = heal.Find("timer");
        Text cooldownTimerText = cooldownTimer.GetComponent<Text>();
        cooldownTimerText.enabled = false;
    }
}
