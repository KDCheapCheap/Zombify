using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [HideInInspector] public bool startGame = false; //UI Element and press enter on keyboard to start
    private bool inIntermission = false;
    private bool inWave = false;
   [HideInInspector] public bool isChecking = false;
    private int waveNumber;
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
        if (inWave)
        {
            if (!isChecking)
            {
                InvokeRepeating("CheckWave", 15, 5);
            }
        }
    }

    private void StartWave()
    {
        inWave = true;
        StartCoroutine(SpawnPooler.poolInstance.SpawnWave(waveNumber));
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
        inIntermission = true;
        SpawnPooler.poolInstance.PrepareWave();
        yield return new WaitForSeconds(intermissionTime);
        waveNumber += 1;
        inIntermission = false;
        StartWave();
        //bool false
        yield return null;
    }

    public void EndWave()
    {
        //recycle all lists so we can start fresh next wave
        SpawnPooler.poolInstance.pooledEnemies.Clear();
        SpawnPooler.poolInstance.spawnedEnemies.Clear();
        inWave = false;
        StartCoroutine(WaveIntermission());
    }


}
