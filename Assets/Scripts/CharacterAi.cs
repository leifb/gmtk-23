using UnityEngine;

public class CharacterAi : MonoBehaviour
{

    public Transform enemiesParent;
    public Transform character;
    private GameObject currentTarget;

    private MovementLogic movement;
    public double speed = 5.0;

    // Start is called before the first frame update
    void Start()
    {
        this.movement = new DefaultMovement(this.speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.UpdateTarget()) {
            return;
        }
        
        this.movement.Move(this.character.transform, this.currentTarget.transform);
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
        return this.enemiesParent.GetChild(selectedEnemy).gameObject;
    }
}
