using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public double speed = 3.0;

    private Transform target;

    private MovementLogic movement;

    // Start is called before the first frame update
    void Start()
    {
        this.target = GameObject.Find("character").transform;
        this.movement = new DefaultMovement(this.speed);
    }

    // Update is called once per frame
    void Update()
    {
        this.movement.Move(this.transform, this.target);
    }

    
}
