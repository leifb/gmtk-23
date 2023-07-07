using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class represents the combat stats (damage scaling) of an enemy.
public class CombatStats
{

    /// Increases blunt damage
    public double strength = 1.0;
    /// Increases piercing damage
    public double dexterity = 1.0;
    /// Increases intelligence damage
    public double intelligence = 1.0;

    /// Decreases blunt damage
    public double constitution = 1.0;
    /// Decreases piercing damage
    public double agility = 1.0;
    /// Decreases intelligence damage
    public double willpower = 1.0;

}
