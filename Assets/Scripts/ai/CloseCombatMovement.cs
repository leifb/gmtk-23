using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloseCombatMovement : MonoBehaviour
{
    public double speed = 5.0;
    public double reach = 1.5;
    public float attackTime = 0.2f;

    private string currentAction = "idle";

    private MovementTarget target;

    private Dictionary<string, System.Action> movesets = new Dictionary<string, System.Action>();

    private float timeout = 0.2f;

    private Vector3 moveIdeDirection;

    public void Start() {
        this.target = this.GetComponent<MovementTarget>();
        this.movesets["idle"] = this.UpdateIdle;
        this.movesets["moveIdle"] = this.UpdateMoveIdle;
        this.movesets["searchForTarget"] = this.UpdateSearchForTarget;
        this.movesets["moveToTarget"] = this.UpdateMoveToTarget;
        this.movesets["attackTarget"] = this.UpdateAttackTarget;
        this.movesets["duringAttack"] = this.UpdateDuringAttack;
        this.QueueIdle();
    }

    public void Update()
    {
        this.movesets[this.currentAction]();
    }

    /// Returns true if the timeout is still running
    private bool TickTimeout() {
        this.timeout -= Time.deltaTime;
        return this.timeout > 0.0;
    }

    private void UpdateIdle() {
        if (this.TickTimeout())
            return;
        
        this.currentAction = "searchForTarget";
    }

    private void UpdateSearchForTarget() {
        // Check enemy
        if (this.target.isValid()) {
            this.currentAction = "moveToTarget";
            return;
        }

        this.QueueIdle();
    }

    private void UpdateMoveIdle() {
        float step = (float) (this.speed * 0.5f) * Time.deltaTime;
        this.transform.position += this.moveIdeDirection * step;

        if (this.TickTimeout())
            return;

        this.currentAction = "searchForTarget";
    }

    private void UpdateMoveToTarget() {
        if (!this.target.isValid()) {
            this.currentAction = "idle";
            this.timeout = 0.1f;
            return;
        }
                
        float distanceToTarget = Vector3.Distance(this.transform.position, this.target.get().position);
        if (distanceToTarget < this.reach) {
            this.timeout = 0.5f;
            this.currentAction = "attackTarget";
            return;
        }

        float step = (float) this.speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.get().position, step);
    }

    private void UpdateAttackTarget() {
        if (!this.target.isValid()) {
            this.currentAction = "searchForTarget";
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
        
        this.moveIdeDirection = RandomDirection();
        this.timeout = this.attackTime;
        this.currentAction = "duringAttack";
    }

    private void UpdateDuringAttack() {
        float step = (float) (this.speed * 0.1f) * Time.deltaTime;
        this.transform.position += this.moveIdeDirection * step;

        if (this.TickTimeout())
            return;

        this.currentAction = "searchForTarget";
    }

    private void QueueIdle() {
        // Either sit and wait or move around
        this.timeout = Random.Range(0.1f, 1.5f);
        if (Random.Range(0.0f, 1.0f) > 0.5f) {
            this.moveIdeDirection = RandomDirection();
            this.currentAction = "moveIdle";
        }
        else {
            this.currentAction = "idle";
        }
    }

    private static Vector2 RandomDirection() {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    

}
