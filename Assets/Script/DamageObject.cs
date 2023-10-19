using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerBehavior playerBehavior = collision.gameObject.GetComponent<PlayerBehavior>();
            playerBehavior.ReceivedHP(10);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyBehavior enemyBehavior = collision.gameObject.GetComponent<EnemyBehavior>();
            enemyBehavior.ReceivedHP(10);
            
        }
    }
}
