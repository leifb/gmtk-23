using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer sprite;
    private Vector2 lastDirection = Vector2.down;
    private Vector3 lastPosition = Vector3.zero;

    public Dictionary<Vector2, string> animationTriggers = new Dictionary<Vector2, string> {
        { Vector2.up, "walking_down" },
        { Vector2.down, "walking_up" },
        { Vector2.left, "walking_sideways" },
        { Vector2.right, "walking_sideways" }
    };

    public Dictionary<Vector2, bool> flip = new Dictionary<Vector2, bool> {
        { Vector2.up, false },
        { Vector2.down, false },
        { Vector2.left, true },
        { Vector2.right, false }
    };

    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();    
        this.sprite = this.GetComponent<SpriteRenderer>();    
        this.lastPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = getTestDirection();

        // Don't do anything if the direction has not changed
        if (lastDirection == direction) {
            return;
        }
        lastDirection = direction;
        
        this.UpdateAnimation(direction);
        this.UpdateFlip(direction);
    }

    void UpdateAnimation(Vector2 direction) {
        string trigger = this.animationTriggers[direction];
        this.animator.Play(trigger, 0);
    }

    void UpdateFlip(Vector2 direction) {
        bool shouldFlip = this.flip[direction];
        this.sprite.flipX = shouldFlip;
    }

    Vector2 getTestDirection() {

        if (Time.time * 0.5 % 4.0 < 1.0)
            return Vector2.up;
        
        if (Time.time  * 0.5 % 4.0 < 2.0)
            return Vector2.left;
        
        if (Time.time  * 0.5 % 4.0 < 3.0)
            return Vector2.down;
                
        return Vector2.right;
        
    }

}
