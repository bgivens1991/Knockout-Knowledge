using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    private Rigidbody2D player;
    public float speed;
    void Start()
    {
        

    }

    void FixedUpdate()
    {
        KeyCode RightKey = KeyCode.D; //shortcut
        KeyCode LeftKey = KeyCode.A; //shortcut
        KeyCode UpKey = KeyCode.W; //shortcut
        KeyCode DownKey = KeyCode.S; //shortcut

        if (Input.GetKey(RightKey)) //when Right Key pressed (D)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(LeftKey)) //when Left Key pressed (A)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(UpKey)) //when Left Key pressed (A)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
        else if (Input.GetKey(DownKey)) //when Left Key pressed (A)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }

    }
}
