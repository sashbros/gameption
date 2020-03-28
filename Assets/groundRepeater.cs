using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundRepeater : MonoBehaviour
{
    public float speed;
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        float newPos = Mathf.Repeat(Time.time * speed, 10.24f);
        transform.position = startPos + Vector2.down * newPos;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (collision.gameObject.CompareTag("Ground"))
        //{
            //transform.position = new Vector3(transform.position.x, 20.48f);
        //}
    //}
}
