using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the main scipt that is used for the "owner" of the player.
public class Character : MonoBehaviour
{

    public CombatStats combatStats = new CombatStats();
    public AttackStats attackStats = new AttackStats();
    public double health = 100.0;


    // Start is called before the first frame update
    void Start()
    {
        // init test attack stats
        this.attackStats.blunt = 10.0;
        this.GetComponent<Health>().SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
    }

    
}
