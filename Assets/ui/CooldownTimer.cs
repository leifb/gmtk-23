using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    float currentTime = 0;
    public Text countdownText;
    private System.Action callback;

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime.ToString("00").Equals("00"))
            {
                this.callback();
            }
            countdownText.text = currentTime.ToString("00");
        }
    }

    public void TriggerCooldown(int seconds, System.Action callback)
    {
        this.callback = callback;
        currentTime = seconds;
    }
}
