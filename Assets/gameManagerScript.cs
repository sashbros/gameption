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
        FindObjectOfType<AudioManager>().Play("Walk");
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = true;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        score += scoreMultiplier * Time.deltaTime;
        scoreText.text = score.ToString("0") + " m";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseActive();
        }
    }

    public void PauseActive()
    {
        FindObjectOfType<AudioManager>().Play("Pause");
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = false;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void GameOverActive()
    {
        FindObjectOfType<AudioManager>().Play("Death");
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (int.Parse(score.ToString("0")) > PlayerPrefs.GetInt("highScore"))
                PlayerPrefs.SetInt("highScore", int.Parse(score.ToString("0")));

        }
        else
        {
            PlayerPrefs.SetInt("highScore", int.Parse(score.ToString("0")));
        }
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = false;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        SceneManager.LoadScene("MainMenu");
    }

    public void CancelButton()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        GameObject.FindGameObjectWithTag("GamePlayer").GetComponent<gamePlayerController>().enableTouch = true;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
}
