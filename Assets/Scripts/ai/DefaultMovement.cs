using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : MovementLogic
{
    private double speed = 5.0;

    public DefaultMovement(double speed) {
        this.speed = speed;
    }


    /// Movement of the AI
    public void Move(Transform actor, Transform target, float deltaTime)
    {
        float distanceToTarget = Vector3.Distance(actor.position, target.position);
        if (distanceToTarget < 1.5) {
            return;
        }

        float step = (float) speed * Time.deltaTime;
        actor.position = Vector3.MoveTowards(actor.position, target.position, step);
    }
}
