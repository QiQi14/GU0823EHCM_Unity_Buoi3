using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private float speed = 1f;
    private float rotationSpeed = 0.025f;

    private Rigidbody2D rb;

    [SerializeField]
    private Transform EnemyShapeTransform;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            getTarget();
        } else
        {
            RotationEnemyFace();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = EnemyShapeTransform.up * speed;
    }

    private void RotationEnemyFace()
    {
        Vector2 targetDirection = target.position - EnemyShapeTransform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90F;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        EnemyShapeTransform.localRotation = Quaternion.Slerp(EnemyShapeTransform.localRotation, q, rotationSpeed);
    }

    private void getTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
