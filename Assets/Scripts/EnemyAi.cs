using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float spawnRadius = 5f;

    private Transform target;
    private CircleCollider2D spawnCircleCollider;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MovementTarget>().set(GameObject.Find("character").transform);
        this.spawnCircleCollider.radius = spawnRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CircleCollider2D GetSpawnCircleCollider(){
        return spawnCircleCollider;
    }
    
}
