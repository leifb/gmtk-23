using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Represents the health of an entity
public class Health : MonoBehaviour
{
    public double value;

    public Health(double start) {
        this.value = start;
    }

    public void takeDamage(Damage damage) {
        this.value -= damage.total;
    }
}
