using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// A singe instance of damage dealt
public class Damage
{
    
    public readonly float total;

    public Damage(float total) {
        this.total = total;
    }

    public static Damage fromInteraction(AttackStats source, CombatStats attacker, CombatStats target) {
        float blunt = source.blunt * attacker.strength * (1 / target.constitution);
        float piercing = source.piercing * attacker.dexterity * (1 / target.agility);
        float magic = source.magic * attacker.intelligence * (1/ target.willpower);

        return new Damage(blunt + piercing + magic);
    }

}
