using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5F;

    private Rigidbody2D rb;

    private Vector2 movement;

    private PlayerBehavior behavior;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        behavior = GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            behavior.StaminaChange(-behavior.currentSP / 1000);
        }
        else
        {
            behavior.StaminaChange(behavior.currentSP / 1000);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
