using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Used to store the current direction an entity is moving to
public class AutoMovementDirection : MonoBehaviour
{

    private MovementDirection direction;
    private Vector2 lastPosition = Vector2.zero;



    public void Start() {
        this.direction = this.GetComponent<MovementDirection>();
        this.lastPosition = this.transform.position;
    }

    public void Update() {
        Vector2 newPosition = this.transform.position;
        var diff = newPosition - this.lastPosition;
        this.direction.set(diff);
        this.lastPosition = newPosition;
    }
}
