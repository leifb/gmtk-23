using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public double speed = 3.0;
    public float spawnRadius = 5f;

    private Transform target;

    private MovementLogic movement;
    private CircleCollider2D spawnCircleCollider;

    // Start is called before the first frame update
    void Start()
    {
        this.target = GameObject.Find("character").transform;
        this.movement = new DefaultMovement(this.speed);
        this.spawnCircleCollider.radius = spawnRadius;
    }

    // Update is called once per frame
    void Update()
    {
        this.movement.Move(this.transform, this.target);
    }

    public CircleCollider2D GetSpawnCircleCollider(){
        return spawnCircleCollider;
    }

    
}
