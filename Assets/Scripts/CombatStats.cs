using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class represents the combat stats (damage scaling) of an enemy.
public class CombatStats
{

    /// Increases blunt damage
    public float strength = 1.0;
    /// Increases piercing damage
    public float dexterity = 1.0;
    /// Increases intelligence damage
    public float intelligence = 1.0;

    // Decreases blunt damage
    public float constitution = 1.0;
    /// Increases piercing damage
    public float agility = 1.0;
    /// Increases intelligence damage
    public float willpower = 1.0;


    /// Is always created with default values
    public CombatStats() {

    }
}
