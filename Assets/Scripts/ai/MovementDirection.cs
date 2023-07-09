using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Used to store the current direction an entity is moving to
public class MovementDirection : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;

    public Vector2 get() {
        return this.direction;
    }

    public void set(Vector2 direction) {
        this.direction = direction;
    }

    public Vector2 Lerp(Vector2 towards, float t) {
        this.direction = Vector2.Lerp(this.direction, towards, t); 
        return this.direction;
    }
}
