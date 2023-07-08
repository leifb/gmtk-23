using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityIndicator : MonoBehaviour
{

    private Ability ability;

    // Start is called before the first frame update
    void Start()
    {
        this.ability = AbilityStore.get(this.gameObject.name);
        if (this.ability == null) {
            Debug.LogError("AbilityIndicator could not find ability with same name!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
