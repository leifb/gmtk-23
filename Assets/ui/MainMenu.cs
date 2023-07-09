using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{

    private static MainUi instance = null;

    public GameObject CanvasMainMenu;
    public GameObject CanvasePaused;
    public GameObject CanvaseDeath;
    
    
    private GameState gameState = GameState.MAIN_MENU;

    private void Awake()
    {
        if (instance == null)
        { 
            // Actual start of the game here
            instance = this;
            DontDestroyOnLoad(gameObject);

            string startScene = SceneManager.GetActiveScene().name;
            if (startScene == "MainMenu") {
                this.gameState = GameState.MAIN_MENU;
            }
            else {
                this.gameState = GameState.RUNNING;
            }
            return;
        }
        if (instance == this)
            return;
        Destroy(gameObject);
    }
    
    void Start()
    {
        if (this.gameState == GameState.MAIN_MENU) {
            this.CanvasMainMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger start / stop
        if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Jump")) {
            if (this.gameState == GameState.MAIN_MENU) {
                this.StartGame();
            }
            else if (this.gameState == GameState.RUNNING) {
                this.PuaseGame();
            }
            else if (this.gameState == GameState.PAUSED) {
                this.ResumeGame();
            }
            else {

            }
        }
        
    }

    public void Quit() {
        Debug.Log("Quit requested from main menu");
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Level0");
        this.gameState = GameState.RUNNING;
        Time.timeScale = 1f;
        this.HideAll();
    }

    public void PuaseGame() {
        this.CanvasePaused.SetActive(true);
        this.gameState = GameState.PAUSED;
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        this.HideAll();
        this.gameState = GameState.RUNNING;
        Time.timeScale = 1f;
    }

    private void HideAll() {
        this.CanvasMainMenu.SetActive(false);
        this.CanvasePaused.SetActive(false);
        this.CanvaseDeath.SetActive(false);
    }


    
}
