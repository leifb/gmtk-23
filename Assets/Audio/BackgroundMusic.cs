using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.UpdateVolume(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume(float value) {
        this.audioSource.volume = Mathf.Exp(value * 5f -5f) -0.01f;
    }
}
