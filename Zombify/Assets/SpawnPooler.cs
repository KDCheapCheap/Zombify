using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPooler : MonoBehaviour
{

    public static SpawnPooler poolInstance;

    public List<GameObject> pooledEnemies;
    public GameObject enemyPrefab;
    public int amountToPool;


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
        pooledEnemies = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            if(!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        return null;
    }
}
