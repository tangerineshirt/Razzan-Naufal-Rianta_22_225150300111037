using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    public float chargeCooldown = 2f; 
    private Rigidbody2D rb;
    private int enemyHits = 0;
    private bool isCharging = true;
    private LogicScore meleeScore;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        meleeScore = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScore>();
    }

    private void Update()
    {
            if (!target)
            {
                GetTarget();
            }
            else if (isCharging)
            {
                RotateTowardsTarget();
            }
    }

    private void FixedUpdate()
    {
            if (target != null)
            {
                if (isCharging)
                {
                    rb.velocity = transform.up * speed;
                }
            }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isCharging)
            {
                StartCoroutine(ChargeCooldown());
                isCharging = false;
            }
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            enemyHits++;
            if (enemyHits == 5)
            {
                Destroy(gameObject);
                meleeScore.addScore();
            }
        }
    }

    private IEnumerator ChargeCooldown()
    {
        rb.velocity = -transform.up * speed;

        yield return new WaitForSeconds(chargeCooldown);
        rb.velocity = Vector2.zero;

        isCharging = true;
    }
}
