using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager abilityManagerInstance;
    public Ability[] allAbilities; //Holds all abilities, set in inspector
    private List<GameObject> abilityPrefabs = new List<GameObject>();

    //Start and awake Functions
    #region Init
    private void Awake()
    {
        if (abilityManagerInstance == null)
        {
            abilityManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnAllAbilities();
    }
    #endregion 

    private void SpawnAllAbilities()
    {
        GameObject abilityToCreate = null;

        foreach(Ability a in allAbilities) 
        {
            abilityToCreate = a.gameObject;
            Instantiate(abilityToCreate);
            abilityToCreate.SetActive(false);
            abilityPrefabs.Add(abilityToCreate);
        }
    }

    private void AssignAbilties()
    {
        //loop through list, check each abilities player class and add it to their skill tree
    }

    
}
