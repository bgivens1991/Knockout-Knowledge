using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float velX = 5f;
    public float velY = 0f;
    public Rigidbody2D rb;
    public float lifetime = 100f;
    float timer = 0;
    public int Lane;
    private SpriteRenderer sprite;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > lifetime)
        {
            timer = 0f;
            Destroy(gameObject);
        }
        rb.velocity = new Vector2(velX, velY);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //take damage from player
            if(col.gameObject.GetComponent<playerStatus>().returnLane() == Lane)
            {
                col.gameObject.GetComponent<playerStatus>().UpdateHealth(2);
                Destroy(gameObject);
            }

        }


    }
    public void SetLane(int n)
    {
        Lane = n;
        //  switch (Lane)
        // {
        //     case 1:
        //         sprite.sortingLayerName = "LowLane";
        //         //Debug.Log("Change Lane 1");
        //         break;
        //     case 2:
        //         sprite.sortingLayerName = "MidLane";
        //         //Debug.Log("Change Lane 2");
        //         break;
        //     case 3:
        //         sprite.sortingLayerName = "HighLane";
        //         //Debug.Log("Change Lane 3");
        //         break;
        // }
    }
}
