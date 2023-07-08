using UnityEngine;

public class CharacterAi : MonoBehaviour
{

    public Transform enemiesParent;
    private MovementTarget target;


    // Start is called before the first frame update
    void Start()
    {
        this.target = this.GetComponent<MovementTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateTarget();
    }


    /// Checks if a new target is needed and selects one if necessary
    /// returns whether a valid target is set.
    private void UpdateTarget() {
        if (this.target.isValid()) {
            return;
        }

        // Select new target
        this.target.set(this.SelectTarget());
    }

    private Transform SelectTarget() {
        int amountEnemies = this.enemiesParent.childCount;

        if (amountEnemies < 1) {
            return null;
        }

        int selectedEnemy = Random.Range(0, amountEnemies);
        return this.enemiesParent.GetChild(selectedEnemy).transform;
    }

    public void Sleep(double duration)
    {
        //TODO freeze character movement
    }
}
