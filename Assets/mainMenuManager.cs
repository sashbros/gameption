using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuManager : MonoBehaviour
{
    public Text highScore;
    public Text skillLevel;

    public GameObject rewardsPanel;

    public Text[] rewardTexts;

    public GameObject[] rewards;

    public Animator canvasAnimator;

    private void Start()
    {
        //PlayerPrefs.SetInt("highScore", 0);
        //PlayerPrefs.SetInt("skillLevel", 1);
        rewardsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore.text = "HighScore : " +  PlayerPrefs.GetInt("highScore").ToString() + " m";
            if (PlayerPrefs.HasKey("skillLevel"))
            {
                skillLevel.text = "skill level : " + (Mathf.Max(PlayerPrefs.GetInt("highScore") / 5 + 1, PlayerPrefs.GetInt("skillLevel"))).ToString();
                PlayerPrefs.SetInt("skillLevel", Mathf.Max(PlayerPrefs.GetInt("highScore") / 5 + 1, PlayerPrefs.GetInt("skillLevel")));
            }
            else
            {
                skillLevel.text = "skill level : " + (PlayerPrefs.GetInt("highScore") / 5 + 1).ToString();
                PlayerPrefs.SetInt("skillLevel", PlayerPrefs.GetInt("highScore") / 5 + 1);
            }
            foreach (GameObject item in rewards)
            {
                if (PlayerPrefs.GetInt("highScore") >= 30)
                {
                    if ((item == rewards[0] && PlayerPrefs.GetInt("r1") == 0) || (item == rewards[1] && PlayerPrefs.GetInt("r2") == 0))
                    {
                        item.GetComponent<Button>().enabled = true;
                        item.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    }
                    else
                    {
                        item.GetComponent<Button>().enabled = false;
                        item.GetComponent<Image>().color = new Color(255, 255, 255, 150);
                    }
                    
                }
                else if (PlayerPrefs.GetInt("highScore") >= 15)
                {
                    if (item.CompareTag("reach15") && PlayerPrefs.GetInt("r1")==0)
                    {
                        item.GetComponent<Button>().enabled = true;
                        item.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    }
                    else
                    {
                        item.GetComponent<Button>().enabled = false;
                        item.GetComponent<Image>().color = new Color(255, 255, 255, 150);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("r1", 0);
                    PlayerPrefs.SetInt("r2", 0);
                    item.GetComponent<Button>().enabled = false;
                    item.GetComponent<Image>().color = new Color(255, 255, 255, 150);
                }
            }
        }
        else
        {
            foreach (GameObject item in rewards)
            {
                PlayerPrefs.SetInt("r1", 0);
                PlayerPrefs.SetInt("r2", 0);
                item.GetComponent<Button>().enabled = false;
                item.GetComponent<Image>().color = new Color(255, 255, 255, 150);
            }
        }
    }
    public void PlayButton()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        FindObjectOfType<AudioManager>().Play("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RewardsButton()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        rewardsPanel.SetActive(true);
    }

    public void CancelButton()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        rewardsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    public void Reward1()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        FindObjectOfType<AudioManager>().Play("JohnCena");
        PlayerPrefs.SetInt("skillLevel", PlayerPrefs.GetInt("skillLevel") + 3);
        rewards[0].GetComponent<Button>().enabled = false;
        rewards[0].GetComponent<Image>().color = new Color(255, 255, 255, 150);
        PlayerPrefs.SetInt("r1", 1);
        rewardsPanel.SetActive(false);
        rewardTexts[0].GetComponent<Animator>().enabled = true;
    }
    public void Reward2()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        FindObjectOfType<AudioManager>().Play("JohnCena");
        PlayerPrefs.SetInt("skillLevel", PlayerPrefs.GetInt("skillLevel") + 5);
        rewards[1].GetComponent<Button>().enabled = false;
        rewards[1].GetComponent<Image>().color = new Color(255, 255, 255, 150);
        PlayerPrefs.SetInt("r2", 1);
        rewardsPanel.SetActive(false);
        rewardTexts[1].GetComponent<Animator>().enabled = true;
    }
    IEnumerator Quit()
    {
        FindObjectOfType<AudioManager>().Play("BtnClick");
        FindObjectOfType<AudioManager>().Play("Quit");
        FindObjectOfType<AudioManager>().Play("Throw");
        canvasAnimator.Play("quitButton");
        GameObject.Find("Quit").GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(8f);
        Application.Quit(0);
    }

}
