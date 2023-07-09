using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class represents the combat stats (damage scaling) of an enemy.
public class CombatStats : MonoBehaviour
{

    /// Increases blunt damage
    public float strength = 1.0f;
    /// Increases piercing damage
    public float dexterity = 1.0f;
    /// Increases intelligence damage
    public float intelligence = 1.0f;

    /// Decreases blunt damage
    public float constitution = 1.0f;
    /// Decreases piercing damage
    public float agility = 1.0f;
    /// Decreases intelligence damage
    public float willpower = 1.0f;

}
