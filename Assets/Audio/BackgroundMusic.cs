using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource audioSource;
    
    public AudioClip clipA;
    public AudioClip clipB;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        this.audioSource = this.GetComponent<AudioSource>();
        this.UpdateVolume(0.5f);

        this.audioSource.clip = GetRandonmClip();
        this.audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.audioSource.isPlaying)
            return;

        this.PlayNextClip();
    }

    private void PlayNextClip() {
        if (this.audioSource.clip == this.clipA) {
            this.audioSource.clip = this.clipB;
        }
        else {
            this.audioSource.clip = this.clipA;
        }
        this.audioSource.Play();
    }


    private AudioClip GetRandonmClip() {
        if (Random.value < 0.5f)
            return this.clipA;
        return this.clipB;
    }

    public void UpdateVolume(float value) {
        this.audioSource.volume = Mathf.Exp(value * 5f -5f) -0.01f;
    }
}
