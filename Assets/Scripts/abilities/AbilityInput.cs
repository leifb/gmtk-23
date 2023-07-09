using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AbilityInput : MonoBehaviour
{

    private Dictionary<string, Ability> hotkeys;
    private int activeAbilites = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.hotkeys = AbilityStore.names().ToDictionary(
            name => "trigger_" + name,
            name => AbilityStore.get(name)
        );
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var pair in this.hotkeys) {
            if (Input.GetButtonDown(pair.Key)) {
                activeAbilites++;
                if (activeAbilites <= 4) {
                    pair.Value.triggerStart();
                }
            }
            if (Input.GetButtonUp(pair.Key)) {
                activeAbilites--;
                if (activeAbilites <= 4){
                    pair.Value.triggerEnd();
                }
            }
        }
    }
}
