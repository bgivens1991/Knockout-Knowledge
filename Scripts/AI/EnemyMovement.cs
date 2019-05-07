using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private GameObject target;
    public bool targetInRange;

    public float speed;
    public float attack1Range = .1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;


    // Use this for initialization
    void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(target.transform.position);
        Debug.Log("Enemy: "+transform.position);

    }

    // Update is called once per frame
    void Update () {
        if (targetInRange)
        {
            //rotate to look at player
            transform.LookAt(target.transform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            //move towards player
            if (Vector3.Distance(transform.position, target.transform.position) > attack1Range)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                Debug.Log("chasing player");
                Debug.Log(transform.position);
                Debug.Log(target.transform.position);

            }
        }

    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered Trigger");
        if(col.gameObject == target)
        {
            targetInRange = true;
            Debug.Log("target in range");
        }
    }
}
