using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Represents the health of an entity
public class Health
{
    public double value;

    public Health(double start) {
        this.value = start;
    }

    public void takeDamage(Damage damage) {
        this.value -= damage.total;
    }
}
