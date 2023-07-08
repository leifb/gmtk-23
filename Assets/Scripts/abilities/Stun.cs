using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public override void SetAbilityEffect()
    {
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
                if(enemyCollider != null){
                    enemyCollider.gameObject.GetComponent<EnemyAi>().Stun(value);
                }
            }
        }
    }

    public override void RemoveAbilityEffect()
    {

    }
}
