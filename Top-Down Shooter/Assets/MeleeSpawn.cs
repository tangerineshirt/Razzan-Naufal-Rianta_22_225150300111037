using System.Collections;
using UnityEngine;

public class MeleeSpawn : MonoBehaviour
{
    public GameObject meleeEnemy;
    private bool spawnYet = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (spawnYet)
            {
                StartCoroutine(SpawnMeleeEnemies(5, 2));
                spawnYet = false;
            }
        }
    }

    private IEnumerator SpawnMeleeEnemies(int count, float delay)
    {
        for(int i=0; i<count; i++)
        {
            int randomX = UnityEngine.Random.Range(36, 55);
            int randomY = UnityEngine.Random.Range(45, 53);
            Instantiate(meleeEnemy, new Vector3(randomX, randomY, 0), Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
