using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{

    private static MainUi instance = null;

    private Canvas mainCanvas;
    public GameObject buttonStart;
    public GameObject buttonResume;
    
    private bool gameRunning = false;

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
        // Trigger start / stop
        if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Jump")) {
            if (!this.gameRunning) {
                this.StartGame();
            }
            else {
                this.Toggle();
            }
        }
        
    }

    public void Quit() {
        Debug.Log("Quit requested from main menu");
        Application.Quit(0);
    }

    public void StartGame() {
        SceneManager.LoadScene("Level0");
        this.gameRunning = true;
        this.Hide();
        this.buttonStart.SetActive(false);
        this.buttonResume.SetActive(true);
    }

    public void ResumeGame() {
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

    public void Toggle() {
        if (this.mainCanvas.enabled) {
            this.Hide();
        }
        else {
            this.Show();
        }
    }
}
