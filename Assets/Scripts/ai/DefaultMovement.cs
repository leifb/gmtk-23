using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovement : MonoBehaviour
{
    public double speed = 5.0;

    private MovementTarget target;

    public void Start() {
        this.target = this.GetComponent<MovementTarget>();
    }

    public void Update()
    {
        if (!this.target.isValid())
            return;
        
        float distanceToTarget = Vector3.Distance(this.transform.position, this.target.get().position);
        if (distanceToTarget < 1.5) {
            return;
        }

        float step = (float) this.speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.get().position, step);
    }
}
