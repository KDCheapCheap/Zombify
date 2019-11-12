using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager abilityManagerInstance;
    public Ability[] allAbilities; //Holds all abilities, set in inspector

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


        foreach (Ability a in allAbilities)
        {
            GameObject abilityToCreate = new GameObject();
            abilityToCreate = Instantiate(a.gameObject, transform);
            Debug.Log($"abilityPos: {abilityToCreate.transform.position}");
            abilityToCreate.GetComponent<Ability>().Init();
            abilityToCreate.SetActive(false);
            AssignAbilties(abilityToCreate);
        }
    }

    private void AssignAbilties(GameObject a)
    {
        //loop through list, check each abilities player class and add it to their skill tree
        //Find the correct player and add the ability to the skilltree

        switch (a.GetComponent<Ability>().playerClass)
        {
            case PlayerController.PlayerClasses.Engineer:
                GameObject.Find("Engineer").GetComponent<PlayerController>().skillTree.Add(a.GetComponent<Ability>());
                break;

            case PlayerController.PlayerClasses.Medic:
                GameObject.Find("Medic").GetComponent<PlayerController>().skillTree.Add(a.GetComponent<Ability>());
                break;

            case PlayerController.PlayerClasses.Scout:
                GameObject.Find("Scout").GetComponent<PlayerController>().skillTree.Add(a.GetComponent<Ability>());
                break;

            case PlayerController.PlayerClasses.Soldier:
                GameObject.Find("Soldier").GetComponent<PlayerController>().skillTree.Add(a.GetComponent<Ability>());
                break;
        }
    }
}

