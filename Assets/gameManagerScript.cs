using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    public Text scoreText;
    public int scoreMultiplier;
    private float score;

    void Start()
    {
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = true;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        score += scoreMultiplier * Time.deltaTime;
        scoreText.text = score.ToString("1") + " m";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseActive();
        }
    }

    public void PauseActive()
    {
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = false;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void GameOverActive()
    {
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = false;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CancelButton()
    {
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = true;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }


}
