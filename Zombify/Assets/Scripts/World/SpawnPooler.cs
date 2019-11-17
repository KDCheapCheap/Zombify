using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPooler : MonoBehaviour
{

    public static SpawnPooler poolInstance;

    public List<GameObject> pooledEnemies;
    public List<GameObject> spawnedEnemies;
    public List<GameObject> enemyPrefabs;
    public List<GameObject> spawners;
    public int waveOneAmount;
    private int enemyWaveAmount;
    private const int difficultyIncrease = 7;

    private float spawnDelay = 2;
    int spawnerCount = 0;

    private void Awake()
    {
        if(poolInstance == null)
        {
            poolInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject s in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawners.Add(s);
        }

        for (int i = 0; i < waveOneAmount; i++)
        {
            int rand = Random.Range(0, enemyPrefabs.Count - 1);
            GameObject obj = Instantiate(enemyPrefabs[rand], transform);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrepareWave()
    {
        if(pooledEnemies.Count > 0)
        {
            pooledEnemies.Clear(); // avoid any overheads from previous wave
        }
        if(spawnedEnemies.Count > 0)
        {
            spawnedEnemies.Clear(); //Same as above
        }

        enemyWaveAmount += enemyWaveAmount / 7; //difficulty curve

        for (int i = 0; i < enemyWaveAmount; i++) //add inactive enemies to the scene
        {
            int rand = Random.Range(0, enemyPrefabs.Count);
            GameObject obj = Instantiate(enemyPrefabs[rand]);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
        }
    }

    public IEnumerator SpawnWave(int waveNumber)
    {
        if(waveNumber % 3 == 0) //decrease the spawndelay every three waves
        {
            spawnDelay -= .02f;
        }
        if(spawnDelay < .2f) //lock it to .2 to avoid instant spawning after wave 30
        {
            spawnDelay = .2f;
        }

        while (pooledEnemies.Count > 0)
        {
            int randSpawner = Random.Range(0, spawners.Count); //choose a random spawner
            GameObject enemyToSpawn = pooledEnemies[0]; //get the enemy

            //Spawn Enemy
            enemyToSpawn.transform.position = spawners[randSpawner].transform.position;
            enemyToSpawn.SetActive(true);

            //change lists respectfully
            pooledEnemies.Remove(enemyToSpawn);
            spawnedEnemies.Add(enemyToSpawn);
            
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void ClearList(List<GameObject> list)
    {
        foreach(GameObject g in list)
        {
            list.Remove(g);
        }
    }
}
