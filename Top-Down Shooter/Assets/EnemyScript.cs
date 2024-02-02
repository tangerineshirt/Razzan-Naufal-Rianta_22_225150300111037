using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    private int enemyHits = 0;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public float fireRate;
    private float timeToFire;
    public Transform firingPoint;
    private LogicScore score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeToFire = fireRate;
        score = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScore>();
    }
    private void Update()
    {
            if (!target)
            {
                GetTarget();
            }
            else
            {
                RotateTowardsTarget();
            }

            if (Vector2.Distance(target.position, transform.position) <= distanceToShoot)
            {
                Shoot();
            }
    }

    private void Shoot()
    {
        if(timeToFire <= 0f)
        {
            GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firingPoint.up * bulletForce, ForceMode2D.Impulse);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
            if (target != null)
            {
                if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
                {
                    rb.velocity = transform.up * speed;
                }
                else
                {
                    rb.velocity = Vector2.zero;
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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            enemyHits++;
            if (enemyHits == 5)
            {
                Destroy(gameObject);
                score.addScore();
            }

        }
    }
}
