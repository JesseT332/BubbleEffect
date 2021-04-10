using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PauseButton() //Pause the game
    {
        if (GamePaused) //if the button is pressed the game will stop and enable game pause window
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }
    }

    public void ResumeButton() //Resume the game
    {
        if (GamePaused) //if the button is pressed the game will stop and enable game pause window
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }
    }

    public void Restart() //Reloads the scene restarting the game.
    {

        SceneManager.LoadScene("MainScene"); //willl reload the scene making it restart
        Time.timeScale = 1f;

    }

}
