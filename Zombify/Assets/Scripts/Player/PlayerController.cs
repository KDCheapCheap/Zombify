﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public enum PlayerClasses
    {
        Soldier,
        Medic,
        Scout,
        Engineer
    }

    public float baseSpeed;
    public int health;
    [HideInInspector]public PlayerClasses playerClass;

    public int upgradePoints = 0;
    public List<Ability> skillTree = new List<Ability>();
    [SerializeField]private Ability equippedAbility;

    public GameObject[] Weapons = new GameObject[4];
    [HideInInspector]public bool isGettingAmmo = false;

    #region Sprinting Vars
    private float currentStamina = 3.0f;
    private float MaxStamina = 3.0f;
    bool isSprinting = false;
    //---------------------------------------------------------
    private float StaminaRegenTimer = 0.0f;
    //---------------------------------------------------------
    private const float StaminaDecreasePerFrame = 1.0f;
    private const float StaminaIncreasePerFrame = 0.5f;
    private const float StaminaTimeToRegen = 1.5f;
    #endregion

    [SerializeField] private GameObject gunSpawn;

    private bool hasWeaponEquipped;
    [HideInInspector] public Weapon currentWeapon;
    private float currentSpeed;
    private float sprintSpeed;

    private TMP_Text currentBulletCount;
    private TMP_Text totalAmmo;

    public Vector2 lookAtPoint;

    private Vector2 lookDeadzone
    {
        get
        {
            float x = transform.position.x + 5f;
            float y = transform.position.y + 5f;

            return new Vector2(x, y);
        }
    } 

    private Vector2 GetLookAtPoint()
    {
        lookAtPoint = transform.position + new Vector3(InputManager.inputInstance.lookAtOffset.x * 10f, InputManager.inputInstance.lookAtOffset.y * 10f);

        return lookAtPoint;
    }

    private bool isShowingAbilityMenu;

    public virtual void Start()
    {
        currentSpeed = baseSpeed;
        currentWeapon = Weapons[0].GetComponent<Weapon>();
        GetUI();
    }

    public virtual void Update()
    {
        LookAtStick();
        Movement();
        CheckInput();
        Sprint();
        Shoot();

        currentBulletCount.text = currentWeapon.currentBulletCount.ToString();
        totalAmmo.text = currentWeapon.totalAmmo.ToString();

        for (int i = 0; i < skillTree.Count - 1; i++)
        {
            Debug.Log($"Skill {i}: {skillTree[i].gameObject.name}");
        }

        if (!hasWeaponEquipped)
        {
            GameObject newWeapon = Instantiate(currentWeapon.gameObject, gunSpawn.transform.position, gunSpawn.transform.rotation, gunSpawn.transform);
            currentWeapon = newWeapon.GetComponent<Weapon>();
            hasWeaponEquipped = true;
        }

        
    }

    private void CheckInput()
    {
        if (InputManager.inputInstance.onRBPressed)
        {
            Debug.Log("RB reload");
            currentWeapon.isReloading = true;
            StartCoroutine(currentWeapon.Reload(currentWeapon.reloadSpeed));
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (skillTree[0].AttemptBuyAbility())
            {
                equippedAbility = skillTree[0];
            }
        }

        if (InputManager.inputInstance.onXPress)
        {
            equippedAbility.Use();
        }

        if (InputManager.inputInstance.onBackPress)
        {
            if (!isShowingAbilityMenu)
            {
                OpenAbilityMenu();
                isShowingAbilityMenu = true;
            }
            else
            {
                HideAbilityMenu();
                isShowingAbilityMenu = false;
            }
        }
    }

    public void Sprint()
    {
        sprintSpeed = currentSpeed + (currentSpeed / 10) * 2;

        if (InputManager.inputInstance.isLTPressed)
        {
            if (!isSprinting && currentStamina != 0)
            {
                currentSpeed += sprintSpeed;
                isSprinting = true;
            }

            if (currentStamina <= 0)
            {
                currentSpeed = baseSpeed;
                isSprinting = false;
            }

            currentStamina = Mathf.Clamp(currentStamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            StaminaRegenTimer = 0.0f;
        }
        else
        {
            if (currentStamina < MaxStamina)
            {
                if (StaminaRegenTimer >= StaminaTimeToRegen)
                    currentStamina = Mathf.Clamp(currentStamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
                else
                    StaminaRegenTimer += Time.deltaTime;
            }

            isSprinting = false;
            currentSpeed = baseSpeed;
        }
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0) || InputManager.inputInstance.isRTPressed)
        {
            currentWeapon.Shoot();
        }
    }

    public void LookAtStick()
    {
        float dist = Vector2.Distance(transform.position, GetLookAtPoint());
        if (dist >= 3)
        {
            Vector2 dir = (Vector2)transform.position - GetLookAtPoint();/*Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)*/;
            float angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-angle, Vector3.back);
        }
        WeaponLookAtStick(currentWeapon);
    }

    private void WeaponLookAtStick(Weapon currentWeapon)
    {
        float dist = Vector2.Distance(transform.position, GetLookAtPoint()); //Stops the 

        if (dist >= 5f)
        {
            Vector2 dir = (Vector2)currentWeapon.transform.position - GetLookAtPoint();
            float angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            currentWeapon.transform.rotation = Quaternion.AngleAxis(-angle, Vector3.back);
        }
    }

    public void Movement()
    {
        Vector2 m = new Vector2(InputManager.inputInstance.movementVector.x, InputManager.inputInstance.movementVector.y) * Time.deltaTime * currentSpeed;
        //transform.Translate(xMovement * Time.deltaTime * currentSpeed, yMovement * Time.deltaTime * currentSpeed, 0, Space.World);
        transform.Translate(m, Space.World);
    }

    public void ChooseAbility()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Open weapon wheel popup
            //Weapon wheel popup handles the rest
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(lookAtPoint, .2f);
    }

    private void GetUI()
    {
        switch (playerClass)
        {
            case PlayerClasses.Soldier:
                currentBulletCount = GameObject.FindGameObjectWithTag("Player1CBC").GetComponent<TMP_Text>();
                totalAmmo = GameObject.FindGameObjectWithTag("Player1TA").GetComponent<TMP_Text>();
                break;
<<<<<<< HEAD
            case PlayerClasses.Engineer:
=======
            case PlayerClasses.Scout:
>>>>>>> origin/Development
                currentBulletCount = GameObject.FindGameObjectWithTag("Player2CBC").GetComponent<TMP_Text>();
                totalAmmo = GameObject.FindGameObjectWithTag("Player2TA").GetComponent<TMP_Text>();
                break;
            case PlayerClasses.Medic:
                currentBulletCount = GameObject.FindGameObjectWithTag("Player3CBC").GetComponent<TMP_Text>();
                totalAmmo = GameObject.FindGameObjectWithTag("Player3TA").GetComponent<TMP_Text>();
                break;
<<<<<<< HEAD
            case PlayerClasses.Scout:
=======
            case PlayerClasses.Engineer:
>>>>>>> origin/Development
                currentBulletCount = GameObject.FindGameObjectWithTag("Player4CBC").GetComponent<TMP_Text>();
                totalAmmo = GameObject.FindGameObjectWithTag("Player4TA").GetComponent<TMP_Text>();
                break;
        }
    }

    private void OpenAbilityMenu()
    {
        switch(playerClass)
        {
            case PlayerClasses.Soldier:
                MenuManager.Instance.Show(MenuManager.Instance.soldierAbilitiesMenu);
                break;
        }
    }

    private void HideAbilityMenu()
    {
        switch(playerClass)
        {
            case PlayerClasses.Soldier:
                MenuManager.Instance.Hide(MenuManager.Instance.soldierAbilitiesMenu);
                break;
        }
    }
}
