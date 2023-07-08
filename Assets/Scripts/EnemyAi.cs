using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public double speed = 3.0;

    private Transform target;

    

    // Start is called before the first frame update
    void Start()
    {
        this.target = GameObject.Find("character").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(this.transform.position, this.target.transform.position);
        if (distanceToTarget < 1.5) {
            return;
        }

        float step = (float) speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.position, step);
    }

    
}
