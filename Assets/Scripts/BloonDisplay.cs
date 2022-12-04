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
    public int value;

    public int health;
    public float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bloon.bloon;
        gameObject.layer = 1;
        speed = 2.0f;
        rb = GetComponent<Rigidbody2D>();
        health = bloon.health;
        value = bloon.value;
        rb.velocity = new Vector2(0, -speed);;
    }

    void Update()
    {
        gameObject.layer = 1;
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

        // if (collision.gameObject.tag == "Projectile") {
        //     Debug.Log("Projectile collision detected");
        //     Projectile projectileScript = collision.gameObject.GetComponent<Projectile>();
        //     health -= projectileScript.damage;
        //     Debug.Log(health);
        //     if (health<=0){
        //         Destroy(gameObject);
        //     }
        // }
        timeElapsed += 1.0f * Time.deltaTime;
    }
}
