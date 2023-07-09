using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroMovement : MonoBehaviour
{
    public double speed = 5.0;
    public double reach = 3;
    public float attackTime = 0.2f;
    public float scanDistance = 6f;

    private string currentAction = "idle";

    private MovementTarget target;
    private Vector2 lastDirection = Vector2.zero;

    private Dictionary<string, System.Action> movesets = new Dictionary<string, System.Action>();

    private List<Vector2> enemyScans = new List<Vector2> {
        new Vector2( 1.0f,  0.0f).normalized,
        new Vector2( 1.0f,  0.4f).normalized,
        new Vector2( 1.0f,  1.0f).normalized,
        new Vector2( 0.4f,  1.0f).normalized,
        new Vector2( 0.0f,  1.0f).normalized,
        new Vector2(-0.4f,  1.0f).normalized,
        new Vector2(-1.0f,  1.0f).normalized,
        new Vector2(-1.0f,  0.4f).normalized,
        new Vector2(-1.0f,  0.0f).normalized,
        new Vector2(-1.0f, -0.4f).normalized,
        new Vector2(-1.0f, -1.0f).normalized,
        new Vector2(-0.4f, -1.0f).normalized,
        new Vector2( 0.0f, -1.0f).normalized,
        new Vector2( 0.4f, -1.0f).normalized,
        new Vector2( 1.0f, -1.0f).normalized,
        new Vector2( 1.0f, -0.4f).normalized,
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
        Vector2 newDirection = SelectFreeDirection();
        this.lastDirection = Vector2.Lerp(this.lastDirection, newDirection, Time.deltaTime * 3f);
        float step = (float) (this.speed) * Time.deltaTime;
        this.transform.position += (Vector3) this.lastDirection * step;

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

    /// Calculate the direction in which the player wants to walk
    private Vector2 SelectFreeDirection() {
        // Make a ray cast for enemies in every direction
        Dictionary<Vector2, HeroScan> scans = this.enemyScans.ToDictionary(
            v => v,
            v => HeroScan.From(this.transform, v, this.scanDistance, this.reach * 0.8)
        );

        // Group into close, distan and free
        var close = scans.Where(s => s.Value.close).ToList();
        var visible = scans.Where(s => s.Value.visible).ToList();
        var free = scans.Where(s => s.Value.free).ToList();

        // Dubug show line
        foreach (var scan in scans) {
            Color color = DebugScanlineColor(scan.Value);
            Debug.DrawLine(this.transform.position, this.transform.position + ((Vector3) (scan.Key * this.scanDistance)), color);
        }

        // Set target to closest enemy
        Collider2D colliderClose = scans.Aggregate((l, r) => l.Value.distance < r.Value.distance ? l : r).Value.collider;
        this.target.set(colliderClose?.transform);

        // No enemy in sight > go wherever
        if (colliderClose == null) {
            this.lastDirection = this.lastDirection + Random.insideUnitCircle * 0.05f;
            return this.lastDirection;
        }

        // If no enemies too close, move to closest
        if (!close.Any()) {
            return (colliderClose.transform.position - this.transform.position).normalized;
        }

        // Otherwise we want to escape
        // If there are free direction, go there
        if (free.Any()) {
            // If 5 or more free directions, go to average free
            if (free.Count > 4) {
                // Get average of free directions
                var averageOfFree = free.Aggregate(Vector2.zero, (l ,r) => l + r.Key);
                // Add timny amount of last direction, because the average is sometimes zero
                var averageWithBias = averageOfFree + (this.lastDirection * 0.2f);
                // Return this normalized
                return averageWithBias.normalized;
            }

            // Otherwise choose the free drection closes to current direction
            var distances = free.Select(f => (Vector2.Distance(f.Key, this.lastDirection), f.Key));
            var best = distances.Aggregate((l, r) => l.Item1 < r.Item1 ? l : r).Item2;
            return best;
        }
        
        // If there is no free direction, just continue walking
        return this.lastDirection;
    }

    private Color DebugScanlineColor(HeroScan scan) {
        if (scan.close)
            return Color.red;
        if (scan.visible)
            return Color.yellow;
        return Color.white;
    }

}
