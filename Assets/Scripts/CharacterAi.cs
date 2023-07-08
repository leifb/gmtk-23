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
        if (this.currentTarget == null) {
            this.currentTarget = this.SelectTarget();

            if (this.currentTarget == null) {
                return;
            }

            Debug.Log("new target" + this.currentTarget.ToString());
        }

        this.MoveToTarget(this.currentTarget);

    }

    void MoveToTarget(GameObject target)
    {
        float step = (float) speed * Time.deltaTime;
        this.character.position = Vector3.MoveTowards(this.character.position, target.transform.position, step);
    }

    GameObject SelectTarget() {
        int amountEnemies = this.enemiesParent.childCount;

        if (amountEnemies < 1) {
            return null;
        }

        int selectedEnemy = Random.Range(0, amountEnemies);
        Debug.Log("Selected enemy" + selectedEnemy.ToString());
        return this.enemiesParent.GetChild(selectedEnemy).gameObject;
    }
}
