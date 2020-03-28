using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float moveX;
    private float moveY;

    private Rigidbody2D rb;

    private float dirX;
    public float moveSpeed = 20f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(dirX, 0f);
        //moveX = Input.GetAxis("Horizontal");
        //moveY = Input.GetAxis("Vertical");

        //rb.velocity = new Vector2(moveX * 5f, moveY * 5f);
    }

    void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.8f, 0.75f), transform.position.y);
    }
}
