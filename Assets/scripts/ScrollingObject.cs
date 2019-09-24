using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timecounter = 2000.0f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed * (timecounter / 20), 0);
    }

    void Update()
    {
        timecounter += 1;
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed * (timecounter / 2000), 0);
        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}