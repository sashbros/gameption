using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyEndline"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("GamePlayer"))
        {
            GameObject.Find("GameManager").GetComponent<gameManagerScript>().GameOverActive();
        }
    }
}
