using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float currentTime = 0;
    float endTime = 15;
    public Text countdownText; 

    // Start is called before the first frame update
    void Start()
    {
        endTime = endTime*60;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
