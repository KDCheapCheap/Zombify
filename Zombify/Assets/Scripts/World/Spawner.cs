using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    [Range(0, 50)]
    private float range = 25;

    int enemyAmountToSpawn;
    float spawnDelay = 1;


    //This will take from Object Pooler class/manager and just handle the spawning

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetEnemiesToSpawn", 0, 5); //Starts right away and repeats every 5 seconds (may change this depending how the waves play out
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetEnemiesToSpawn()
    {
        int amountToSpawn;

        switch (CheckPlayersInRange())
        {
            /*
             * This will decide how many enemies to grab (percentage?) from the pool
             * then spawn those enemies accordingly, move the enemies position to this spawner and set them active
             */

            case 0:
                StopAllCoroutines();
                break;

            case 1:
                Debug.Log("Adding Enemies to array");
                amountToSpawn = Mathf.RoundToInt((SpawnPooler.poolInstance.pooledEnemies.Count * 25) / 100);
                Debug.Log(amountToSpawn);
                StartCoroutine(SpawnEnemies(amountToSpawn)); //25 percent of enemies go to the spawner (In a coroutine which grabs one every so often, meaning it won't just grab loads. Take one, spawn one.

                break;

            case 2:
                amountToSpawn = Mathf.RoundToInt((SpawnPooler.poolInstance.pooledEnemies.Count * 50) / 100);
                StartCoroutine(SpawnEnemies(amountToSpawn));
                break;

            case 3:
                amountToSpawn = Mathf.RoundToInt((SpawnPooler.poolInstance.pooledEnemies.Count * 75) / 100);
                StartCoroutine(SpawnEnemies(amountToSpawn));
                break;

            case 4:
                amountToSpawn = SpawnPooler.poolInstance.pooledEnemies.Count;
                StartCoroutine(SpawnEnemies(amountToSpawn));
                break;
        }
    }

    private int CheckPlayersInRange()
    {
        int playersInRange = 0;
        //if an object of the type player is in range

        foreach (PlayerController p in GameObject.FindObjectsOfType<PlayerController>())
        {
            if (Vector3.Distance(transform.position, p.transform.position) < range)
            {
                //Player in spawning range
                Debug.Log("Player In Range");
                playersInRange += 1;
            }
        }

        return playersInRange;
    }

    private IEnumerator SpawnEnemies(int amount)
    {
        //GetEnemiesToSpawn();
        Debug.Log("Spawning Enemies");
        GameObject enemytoSpawn = null;
        int enemiesSpawned = 0;

        foreach (GameObject e in SpawnPooler.poolInstance.pooledEnemies)
        {
            if (!e.activeInHierarchy)
            {
                enemytoSpawn = e;
                //spawn this one
            }
            else
            {
                continue;
            }

            if (enemiesSpawned < amount)
            {
                e.transform.position = transform.position;
                e.SetActive(true);
                enemiesSpawned += 1;
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                yield return null;
            }
        }

        //for (int i = 0; i < amount; i++)
        //{

        //    if (CheckPlayersInRange() > 0)
        //    {
        //        if (SpawnPooler.poolInstance.pooledEnemies[i].activeInHierarchy)
        //        {
        //            SpawnPooler.poolInstance.pooledEnemies[i + 1].transform.position = transform.position;
        //            SpawnPooler.poolInstance.pooledEnemies[i + 1].SetActive(true);
        //            yield return new WaitForSeconds(spawnDelay);
        //        }
        //        else
        //        {
        //            SpawnPooler.poolInstance.pooledEnemies[i].transform.position = transform.position;
        //            SpawnPooler.poolInstance.pooledEnemies[i].SetActive(true);
        //            yield return new WaitForSeconds(spawnDelay);
        //        }
        //    }
        //    else
        //    {
        //        break;
        //    }
        //}

        //yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
