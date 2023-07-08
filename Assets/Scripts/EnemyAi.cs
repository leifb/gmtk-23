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
        float step = (float) speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    
}
