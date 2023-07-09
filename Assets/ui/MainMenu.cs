using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{

    private static MainUi instance = null;

    private Canvas mainCanvas;
    
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this)
            return; 
        Destroy(gameObject);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        this.mainCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.mainCanvas.enabled && Input.GetButtonDown("Cancel")) {
            this.Show();
        }
    }

    public void Quit() {
        Debug.Log("Quit requested from main menu");
        Application.Quit(0);
    }

    public void StartGame() {
        SceneManager.LoadScene("Level0");
        this.Hide();
    }

    public void Show() {
        this.mainCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    public void Hide() {
        this.mainCanvas.enabled = false;
        Time.timeScale = 1f;
    }
}
