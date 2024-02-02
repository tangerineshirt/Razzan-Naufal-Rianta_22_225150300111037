using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSpawner : MonoBehaviour
{
    public GameObject melee;
    public GameObject range;
    private bool spawnYet = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (spawnYet)
            {
                Instantiate(range, new Vector3(37, -55, 0), Quaternion.identity);
                Instantiate(range, new Vector3(46, -55, 0), Quaternion.identity);
                Instantiate(range, new Vector3(54, -55, 0), Quaternion.identity);
                StartCoroutine(SpawnMeleeEnemies(5f));
                spawnYet = false;
            }
        }
    }

    private IEnumerator SpawnMeleeEnemies(float delay)
    {
        yield return new WaitForSeconds(delay);

        Instantiate(melee, new Vector3(38, -38, 0), Quaternion.identity);
        Instantiate(melee, new Vector3(53, -38, 0), Quaternion.identity);
    }
}
