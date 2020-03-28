using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entryManager : MonoBehaviour
{
    public float waitTime;
    void Start()
    {
        StartCoroutine(Wait(waitTime));
    }
    IEnumerator Wait(float waitTime)
    {
        FindObjectOfType<AudioManager>().Play("Entry");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainMenu");
    }
}
