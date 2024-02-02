using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawn : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    private bool spawnYet = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (spawnYet)
            {
                Instantiate(spawn1, new Vector3(37, 6, 0), Quaternion.identity);
                Instantiate(spawn2, new Vector3(54, 6, 0), Quaternion.identity);
                Instantiate(spawn3, new Vector3(37, -7, 0), Quaternion.identity);
                Instantiate(spawn4, new Vector3(54, -7, 0), Quaternion.identity);
                spawnYet = false;
            }
        }
    }
}
