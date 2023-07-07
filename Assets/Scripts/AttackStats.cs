using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Data class that defines how much damage an attack deals.
/// These will usually be scaled by some combad stats.
public class AttackStats : MonoBehaviour
{
    /// Blunt damage
    public double blunt = 0.0;
    /// Piercing damage
    public double piercing = 0.0;
    /// Magic damage
    public double magic = 0.0;



    /// Is always created with default values
    public AttackStats() {

    }
}
