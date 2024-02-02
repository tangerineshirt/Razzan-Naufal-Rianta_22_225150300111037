using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private int hitSelf = 0;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            logic.loseHealth();
            if(hitSelf == 9)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(2);
            }
            hitSelf++;
        }
        if (collision.gameObject.CompareTag("MeleeEnemy"))
        {
            logic.loseHealth();
            if(hitSelf == 9)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(2);
            }
            hitSelf++;
        }
    }

}
