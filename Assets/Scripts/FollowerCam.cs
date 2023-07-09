using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCam : MonoBehaviour
{

    public Transform target;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.target == null)
            return;
        
        float newX = Mathf.Lerp(this.transform.position.x, this.target.position.x, this.speed * Time.deltaTime);
        float newY = Mathf.Lerp(this.transform.position.y, this.target.position.y, this.speed * Time.deltaTime);
        this.transform.position = new Vector3(newX, newY, -10.0f);
    }
}
