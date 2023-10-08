using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonboss : MonoBehaviour
{
    public float speed;
    public float walkTime;

    private float timer;
    private bool walkRight = false;
    private bool attack = false;

    private Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }

        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0,180);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }

        if (attack)
        {
            
        }
    }
}
