using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the main scipt that is used for the "owner" of the player.
public class Character : MonoBehaviour
{
    public double health = 100.0;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Health>().SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
