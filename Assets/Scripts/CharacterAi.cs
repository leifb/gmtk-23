using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAi : MonoBehaviour
{

    public Transform enemiesParent;
    public Transform character;
    private GameObject currentTarget;

    public double speed = 5.0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.UpdateTarget()) {
            return;
        }
        
        this.Move(this.currentTarget);
    }

    /// Movement of the AI
    void Move(GameObject target)
    {
        float distanceToTarget = Vector3.Distance(this.character.position, target.transform.position);
        if (distanceToTarget < 1.5) {
            return;
        }

        float step = (float) speed * Time.deltaTime;
        this.character.position = Vector3.MoveTowards(this.character.position, target.transform.position, step);
    }

    /// Checks if a new target is needed and selects one if necessary
    /// returns whether a valid target is set.
    private bool UpdateTarget() {
        // Check if target "died"
        if (this.currentTarget != null && !this.currentTarget.activeSelf) {
            this.currentTarget = null;
        }

        // Return true, if there is a valid target
        if (this.currentTarget != null) {
            return true;
        }

        // Select new target
        this.currentTarget = this.SelectTarget();

        return this.currentTarget != null;
    }

    private GameObject SelectTarget() {
        int amountEnemies = this.enemiesParent.childCount;

        if (amountEnemies < 1) {
            return null;
        }

        int selectedEnemy = Random.Range(0, amountEnemies);
        Debug.Log("Selected enemy" + selectedEnemy.ToString());
        return this.enemiesParent.GetChild(selectedEnemy).gameObject;
    }
}
