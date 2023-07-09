using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit() {
        Debug.Log("Quit requested from main menu");
        Application.Quit(0);
    }

    public void StartGame() {
        SceneManager.LoadScene("Level0");
    }
}
