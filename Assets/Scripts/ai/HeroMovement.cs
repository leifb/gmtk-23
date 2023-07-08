using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroMovement : MonoBehaviour
{
    public double speed = 5.0;
    public double reach = 3;
    public float attackTime = 0.2f;

    private string currentAction = "idle";

    private MovementTarget target;
    private Vector2 moveIdleDirection = Vector2.zero;

    private Dictionary<string, System.Action> movesets = new Dictionary<string, System.Action>();

    private List<Vector2> enemyScans = new List<Vector2> {
        new Vector2( 1.0f,  0.0f),
        new Vector2( 1.0f,  1.0f).normalized,
        new Vector2( 0.0f,  1.0f),
        new Vector2(-1.0f, -1.0f).normalized,
        new Vector2(-1.0f,  0.0f),
        new Vector2(-1.0f,  1.0f).normalized,
    };

    private float timeout = 0.2f;

    public void Start() {
        this.target = this.GetComponent<MovementTarget>();
        this.movesets["idle"] = this.UpdateIdle;
        this.movesets["attackTarget"] = this.UpdateAttackTarget;
        this.movesets["duringAttack"] = this.UpdateDuringAttack;
        this.currentAction = "idle";
    }

    public void Update()
    {
        // Always scan for enemies and move
        Vector3 direction = SelectFreeDirection();
        float step = (float) (this.speed) * Time.deltaTime;
        this.transform.position += direction * step;

        // Attack or whatever
        this.movesets[this.currentAction]();
    }

    /// Returns true if the timeout is still running
    private bool TickTimeout() {
        this.timeout -= Time.deltaTime;
        return this.timeout > 0.0;
    }

    /// Hero Idle:
    /// Always check for enemies
    private void UpdateIdle() {
        if (!this.target.isValid()) {
            return;
        }

        float distanceToTarget = Vector3.Distance(this.transform.position, this.target.get().position);
        if (distanceToTarget > this.reach) {
            return;
        }    

        this.currentAction = "attackTarget";
        return;

    }

    private void UpdateAttackTarget() {
        if (!this.target.isValid()) {
            this.currentAction = "idle";
            return;
        }

        // Deal actual damage
        Transform target = this.target.get();
        Damage damage = Damage.fromInteraction(
            this.GetComponent<AttackStats>(),
            this.GetComponent<CombatStats>(),
            this.target.GetComponent<CombatStats>()
        );
        target.GetComponent<Health>().takeDamage(damage);
        
        
        this.timeout = this.attackTime;
        this.currentAction = "duringAttack";
    }

    private void UpdateDuringAttack() {
        if (this.TickTimeout())
            return;

        this.currentAction = "idle";
    }

    private Vector2 SelectFreeDirection() {
        // Make a ray cast in every direction
        Dictionary<Vector2, (Collider2D, float)> scans = this.enemyScans.ToDictionary(
            v => v,
            v => RayCast(v)
        );

        // Set target to closest enemy
        Collider2D colliderClose = scans.Aggregate((l, r) => l.Value.Item2 < r.Value.Item2 ? l : r).Value.Item1;
        this.target.set(colliderClose?.transform);

        // No enemy in sight > go wherever
        if (colliderClose == null) {
            this.moveIdleDirection = this.moveIdleDirection + Random.insideUnitCircle * 0.05f;
            return this.moveIdleDirection;
        }
        
        // Get distance to nearest target
        float distance = Vector3.Distance(this.transform.position, this.target.get().position);

        // If is safe, move towards
        if (distance > this.reach) {
            return (colliderClose.transform.position - this.transform.position).normalized;
        }

        // If is too close, run away
        // Select the vector with the max distance to enemy
        Vector2 directionFree = scans.Aggregate((l, r) => l.Value.Item2 > r.Value.Item2 ? l : r).Key;
        return directionFree;
    }

    private (Collider2D, float) RayCast(Vector2 direction) {
        float distance = 10f;
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, -Vector2.up, distance, LayerMask.GetMask("Enemies"));
        if (hit.collider == null) {
            return (null, distance);
        }
        return (hit.collider, hit.distance);
    }

}
