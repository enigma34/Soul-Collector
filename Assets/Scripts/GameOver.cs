using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    public GameObject gameOverPanel;
    public Text gameOverPanelTitle;
    public Text scoreTitle;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            //Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverPanelTitle.text = "Game Over";
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                gameOverPanelTitle.text = "Pause";
                gameOverPanel.SetActive(true);
            }
            else if (Time.timeScale == 0 && GameObject.FindGameObjectWithTag("Player") != null)
            {
                Time.timeScale = 1;
                //gameOverPanelTitle.text = "Game Over";
                gameOverPanel.SetActive(false);
            }
        }
        scoreTitle.text = $" Souls Collected: {Ghost.totalSouls}";
    }

    public void HomeScreen()
    {
        LoadLevelByName("Home");
    }

    public void Restart()
    {
       // Time.timeScale = 1;
        LoadLevelByName(SceneManager.GetActiveScene().name);
    }

    public void LoadLevelByName(string levelToLoadName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoadName);
    }
}
