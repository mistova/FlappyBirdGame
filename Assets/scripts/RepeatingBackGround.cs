using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackGround : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength = 0.0f;
    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }
    private void Update()
    {
        if (transform.position.x < groundHorizontalLength* (-1.5))
        {
            RepositionBackground();
        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 3f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}