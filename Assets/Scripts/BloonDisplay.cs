using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum Directions 
{
    LEFT = -1,
    RIGHT = 1,
    UP = 1,
    DOWN = -1
}

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
        if(transform.position.y<-5){
            TowerManagement.Instance.changeHealth(value);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "down")
        {
            rb.velocity = new Vector2(0, (float) Directions.DOWN * speed);
        }
        else if (collision.gameObject.tag == "up")
        {
            rb.velocity = new Vector2(0, (float) Directions.UP * speed);
        }
        else if (collision.gameObject.tag == "right")
        {
            rb.velocity = new Vector2((float) Directions.RIGHT * speed, 0);
        }
        else if (collision.gameObject.tag == "left")
        {
            rb.velocity = new Vector2((float) Directions.LEFT * speed, 0);
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
