using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stun : HoldToCastAbility
{
    override public string name
    {
        get { return "stun"; }
    }

    public override int value
    {
        get { return 2; }
    }

    private bool isOnCooldown = false;

    public override void SetAbilityEffect()
    {
        if (!isOnCooldown)
        {
            isOnCooldown = true;

            GameObject character = GameObject.Find("character");
            CircleCollider2D collider = character.GetComponent<CircleCollider2D>();
            GameObject enemies = GameObject.Find("enemies");

            Collider2D[] overlappedColliders = new Collider2D[enemies.transform.GetComponentsInChildren<Collider2D>().GetLength(0)];

            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.layerMask = LayerMask.GetMask("Enemies");

            int numCollider = collider.OverlapCollider(contactFilter, overlappedColliders);

            if (overlappedColliders.GetLength(0) > 0)
            {
                foreach (Collider2D enemyCollider in overlappedColliders)
                {
                    if (enemyCollider != null)
                    {
                        enemyCollider.gameObject.GetComponent<EnemyAi>().Stun(value);
                    }
                }
            }

            Transform heal = GameObject.Find("stun").transform;

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
        Transform heal = GameObject.Find("stun").transform;

        Image cooldownOverlay = heal.Find("cooldown").GetComponent<Image>();

        cooldownOverlay.enabled = false;
        Transform cooldownTimer = heal.Find("timer");
        Text cooldownTimerText = cooldownTimer.GetComponent<Text>();
        cooldownTimerText.enabled = false;
    }
}
