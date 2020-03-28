using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlayerController : MonoBehaviour
{
    private bool gamePlayerLeft = true;
    public bool enableTouch = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableTouch == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (gamePlayerLeft == true)
                    {
                        transform.position = new Vector3(gameObject.GetComponentInParent<Transform>().position.x + 0.65f, gameObject.GetComponentInParent<Transform>().position.y);
                        gamePlayerLeft = false;
                    }
                    else
                    {
                        transform.position = new Vector3(gameObject.GetComponentInParent<Transform>().position.x - 0.65f, gameObject.GetComponentInParent<Transform>().position.y);
                        gamePlayerLeft = true;
                    }
                }
            }
        }
    }
}
