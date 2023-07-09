using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteMovement : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer sprite;
    private Vector2 lastDirection = Vector2.down;
    private MovementDirection movementDirection;

    public Dictionary<Vector2, string> animationTriggers = new Dictionary<Vector2, string> {
        { Vector2.left, "warrior_walking" },
        { Vector2.right, "warrior_walking" },
        { Vector2.zero, "warrior_idle" },
    };

    public Dictionary<Vector2, bool> flip = new Dictionary<Vector2, bool> {
        { Vector2.left, true },
        { Vector2.right, false },
        { Vector2.zero, false },
    };

    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();    
        this.sprite = this.GetComponent<SpriteRenderer>();    
        this.movementDirection = this.GetComponent<MovementDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = GetDirection();

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


    Vector2 GetDirection() {
        var direction = this.movementDirection.get();
        if (direction.sqrMagnitude < 0.0001)
            return Vector2.zero;
        
        if (direction.x > 0)
            return Vector2.right;

        return Vector2.left;
    }

}
