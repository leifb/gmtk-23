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
    
    
    private GameState _gameState = GameState.MAIN_MENU;

    public GameState gameState {
        get { return this._gameState; }
    }

    private void Awake()
    {
        if (instance == null)
        { 
            // Actual start of the game here
            instance = this;
            DontDestroyOnLoad(gameObject);

            string startScene = SceneManager.GetActiveScene().name;
            if (startScene == "MainMenu") {
                this._gameState = GameState.MAIN_MENU;
            }
            else {
                this._gameState = GameState.RUNNING;
            }
            return;
        }
        if (instance == this)
            return;
        Destroy(gameObject);
    }
    
    void Start()
    {
        if (this._gameState == GameState.MAIN_MENU) {
            this.CanvasMainMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger start / stop
        if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Jump")) {
            if (this._gameState == GameState.MAIN_MENU) {
                this.StartGame();
            }
            else if (this._gameState == GameState.RUNNING) {
                this.PuaseGame();
            }
            else if (this._gameState == GameState.PAUSED) {
                this.ResumeGame();
            }
            else if (this._gameState == GameState.DEATH)  {
                this.StartGame();
            }
        }
    }

    public void Quit() {
        Debug.Log("Quit requested from main menu");
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Level0");
        this._gameState = GameState.RUNNING;
        Time.timeScale = 1f;
        this.HideAll();
    }

    public void PuaseGame() {
        this.CanvasePaused.SetActive(true);
        this._gameState = GameState.PAUSED;
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        this.HideAll();
        this._gameState = GameState.RUNNING;
        Time.timeScale = 1f;
    }

    public void OnDeath() {
        this._gameState = GameState.DEATH;
        this.CanvaseDeath.SetActive(true);
        Time.timeScale = 0.3f;
    }

    private void HideAll() {
        this.CanvasMainMenu.SetActive(false);
        this.CanvasePaused.SetActive(false);
        this.CanvaseDeath.SetActive(false);
    }


    
}
