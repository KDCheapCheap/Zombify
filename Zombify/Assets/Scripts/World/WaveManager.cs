using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [HideInInspector] public bool startGame = false; //UI Element and press enter on keyboard to start
   [HideInInspector] public bool isChecking = false;
    private int waveNumber = 0;
    private float intermissionTime = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning($"Multiple {this.name} in the scene! Removed extra");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveIntermission());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartWave()
    {
        StartCoroutine(SpawnPooler.poolInstance.SpawnWave(waveNumber));
        InvokeRepeating("CheckWave", 15, 5);
    }

    private void CheckWave()
    { 
        if (SpawnPooler.poolInstance.spawnedEnemies.Count == 0)
        {
            EndWave(); //WHEN ENEMY DIES, REMOVE IT FROM THE SPAWNED LIST
        }
    }

    private IEnumerator WaveIntermission()
    {
        SpawnPooler.poolInstance.PrepareWave();
        yield return new WaitForSeconds(intermissionTime);
        waveNumber += 1;
        StartWave();
        //bool false
        yield return null;
    }

    public void EndWave()
    {
        //recycle all lists so we can start fresh next wave
        SpawnPooler.poolInstance.pooledEnemies.Clear();
        SpawnPooler.poolInstance.spawnedEnemies.Clear();

        CancelInvoke();
        StartCoroutine(WaveIntermission());
    }


}
