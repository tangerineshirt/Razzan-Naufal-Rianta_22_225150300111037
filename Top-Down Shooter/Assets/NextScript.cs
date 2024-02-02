using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScript : MonoBehaviour
{
    public GameObject melee;
    private bool spawnYet = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (spawnYet)
            {
                Instantiate(melee, new Vector3(116, 6, 0), Quaternion.identity);
                Instantiate(melee, new Vector3(116, 1, 0), Quaternion.identity);
                Instantiate(melee, new Vector3(116, -6, 0), Quaternion.identity);
                spawnYet = false;
            }
        }
    }
}
