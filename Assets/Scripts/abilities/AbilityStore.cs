using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AbilityStore
{

    private static List<Ability> abilitiesList = new List<Ability> {
        new Heal(),
        new Sleep(),
        new Stun(),
        new BuffConstitution(),
        new BuffAgility(),
        new BuffWillpower(),
        new BuffStrength(),
        new BuffDexterity(),
        new BuffInteligence(),
        new Test(),
    };

    private static Dictionary<string, Ability> abilities = abilitiesList.ToDictionary(
        ability => ability.name,   
        ability => ability
    );

    public static Ability get(string name) {
        return abilities[name];
    }

    public static List<string> names() {
        return abilities.Keys.ToList();
    }

}
