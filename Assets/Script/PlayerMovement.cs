using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x > 0)
        {
            PlayerBehavior playerBehavior = gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceivedSP(0.01f);
        } 
        else if(movement.x < 0) 
        {
            PlayerBehavior playerBehavior = gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceivedSP(0.01f);
        }
        else if (movement.y > 0)
        {
            PlayerBehavior playerBehavior = gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceivedSP(0.01f);
        }
        else if (movement.y < 0)
        {
            PlayerBehavior playerBehavior = gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceivedSP(0.01f);
        }
        else
        {
            PlayerBehavior playerBehavior = gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceivedSP(-0.01f);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
