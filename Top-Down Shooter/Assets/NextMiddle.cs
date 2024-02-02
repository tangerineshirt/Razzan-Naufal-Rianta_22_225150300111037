using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMiddle : MonoBehaviour
{
    public GameObject range;
    private bool spawnYet = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MeleeEnemy"))
        {
            if (spawnYet)
            {
                Instantiate(range, new Vector3(89, 7, 0), Quaternion.identity);
                Instantiate(range, new Vector3(97, 7, 0), Quaternion.identity);
                Instantiate(range, new Vector3(86, -7, 0), Quaternion.identity);
                spawnYet = false;
            }
        }
    }
}
