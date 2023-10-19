using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float currentHP;
   
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Transform enemy;

    private Transform target;

    [SerializeField]
    private Transform hpBar;
    private Vector2 hpScale;
    // Start is called before the first frame update
    void Start()
    {
        hpScale = hpBar.localScale;
        currentHP = maxHP;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getTarger();
        if (target == true)
        {
            Vector2 targetDirection = target.position - enemy.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90F;
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            enemy.localRotation = Quaternion.Slerp(enemy.localRotation, q, 0.025f);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = enemy.up * speed * 0.5f;
    }
    private void getTarger()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void ReceivedHP(float damage)
    {
        currentHP = currentHP - damage;
        if (currentHP <= 0)
        {
            hpBar.localScale = new Vector2(0, hpScale.y);
        }
        else
        {
            hpBar.localScale = new Vector2(hpScale.x * (currentHP / maxHP), hpScale.y);
        }
    }
}
