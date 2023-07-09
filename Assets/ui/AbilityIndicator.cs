using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AbilityIndicator : MonoBehaviour
{

    private Ability ability;
    public Sprite activeAbility;
    public Sprite nonActiveAbility;


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
        Transform border = this.gameObject.transform.Find("border");
        Image image = border.gameObject.GetComponent<Image>();
        
        if (this.ability.isActive) {
            if(image.sprite != activeAbility){
                image.sprite = activeAbility;
            }

            Debug.Log("Hot ability " + this.name);
        } else {
            if(image.sprite != nonActiveAbility){
                image.sprite = nonActiveAbility;
            }

        }
    }


}
