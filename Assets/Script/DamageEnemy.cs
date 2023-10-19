using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
  
        if (collision.gameObject.tag == "Player")
        {
            PlayerBehavior playerBehavior = collision.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceivedHP(1);
        }
    }
}
