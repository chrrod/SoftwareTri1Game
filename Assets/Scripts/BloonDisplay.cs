using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloonDisplay : MonoBehaviour
{

    public Bloon bloon;
    public SpriteRenderer spriteRenderer;
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bloon.bloon;
        gameObject.layer = 1;
        speed = 2.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "down")
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else if (collision.gameObject.tag == "up")
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if (collision.gameObject.tag == "right")
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if (collision.gameObject.tag == "left")
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}
