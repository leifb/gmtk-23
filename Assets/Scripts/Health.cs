using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Represents the health of an entity
public class Health : MonoBehaviour
{
    public double value;
    public double maxHealth;
    public HealthBar healthBar;

    public void SetMaxHealth(double health)
    {
        maxHealth = health;
        if(healthBar!= null)
        {
            healthBar.SetMaxHealth((float)maxHealth);
        }
    }

    public void takeDamage(Damage damage) {
        this.value -= damage.total;
        healthBar.setHealth((float)value);
    }

    void Start()
    {
        value = maxHealth;
        healthBar.SetMaxHealth((float)maxHealth);
    }


}
