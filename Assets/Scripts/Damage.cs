using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// A singe instance of damage dealt
public class Damage : MonoBehaviour
{
    
    public readonly double total;

    public Damage(double total) {
        this.total = total;
    }

    public static Damage fromInteraction(AttackStats source, CombatStats attacker, CombatStats target) {
        double blunt = source.blunt * attacker.strength * (1 / target.constitution);
        double piercing = source.piercing * attacker.dexterity * (1 / target.agility);
        double magic = source.magic * attacker.intelligence * (1/ target.willpower);

        return new Damage(blunt + piercing + magic);
    }

}
