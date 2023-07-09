using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Represents the health of an entity
public class Health : MonoBehaviour
{
    public float value = 100.0f;
    public float maxHealth = 100.0f;
    public HealthBar healthBar;

    public void takeDamage(Damage damage) {
        this.value = Mathf.Clamp(this.value - damage.total, 0.0f, this.maxHealth);
        healthBar.setHealth(value);

        // Check if died
        if (this.value <= 0.0f) {
            Destroy(this.gameObject);
        }
    }

    public void heal(float amount) {
        this.value += amount;
        healthBar.setHealth(value);
    }

    void Start()
    {
        this.value = this.maxHealth;
        this.healthBar.SetMaxHealth(this.maxHealth);
    }


}
