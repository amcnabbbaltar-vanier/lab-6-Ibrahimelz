using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuPanel;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseMenuPanel);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the "Escape" key (or any key you choose).
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {
        // Show Pause Menu UI
        pauseMenuPanel.SetActive(true);
        // Freeze game time
        Time.timeScale = 0f;
        // (Optional) Freeze audio
        // AudioListener.pause = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Hide Pause Menu UI
        pauseMenuPanel.SetActive(false);
        // Unfreeze game time
        Time.timeScale = 1f;
        // (Optional) Unfreeze audio
        // AudioListener.pause = false;
        isPaused = false;
    }
    
    // Optional: a method for quitting the game or returning to the main menu.
    public void QuitGame()
    {
        // If you're in the editor, this won't fully work,
        // but in a built application, this will quit the game.
        Application.Quit();
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        // If you have a Main Menu scene, you might do:
        SceneManager.LoadScene("MainMenu");
    }



}
