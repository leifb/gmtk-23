using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Data class that defines how much damage an attack deals.
/// These will usually be scaled by some combad stats.
public class AttackStats : MonoBehaviour
{
    /// Blunt damage
    public float blunt = 0.0f;
    /// Piercing damage
    public float piercing = 0.0f;
    /// Magic damage
    public float magic = 0.0f;
}
