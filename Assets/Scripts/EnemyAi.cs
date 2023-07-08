using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MovementTarget>().set(GameObject.Find("character").transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
