using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AbilityInput : MonoBehaviour
{

    private Dictionary<string, Ability> hotkeys;

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
                pair.Value.trigger();
            }
        }
    }
}
