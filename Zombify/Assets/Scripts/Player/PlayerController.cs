using System.Collections;
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
    public PlayerClasses playerClass;

    public int upgradePoints = 0;
    [SerializeField] private Ability[] skillTree;
    private GameObject equippedAbility;

    public GameObject[] Weapons = new GameObject[4];

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
    private Weapon currentWeapon;
    private float currentSpeed;
    private float sprintSpeed;

    [SerializeField] private TMP_Text currentBulletCount;
    [SerializeField] private TMP_Text totalAmmo;

    [HideInInspector] public PlayerControls controls; //control scheme
    Vector2 movement;


    public virtual void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        //controls.Gameplay.Move.canceled += ctx => movement = Vector2.zero;
    }

    public virtual void Start()
    {
        currentSpeed = baseSpeed;
        currentWeapon = Weapons[1].GetComponent<Weapon>();
    }

    public virtual void Update()
    {
        Debug.Log(movement);
        LookAtMouse();
        Movement();
        Sprint();
        Shoot();

        currentBulletCount.text = currentWeapon.currentBulletCount.ToString();
        totalAmmo.text = currentWeapon.totalAmmo.ToString();

        if (!hasWeaponEquipped)
        {
            GameObject newWeapon = Instantiate(currentWeapon.gameObject, gunSpawn.transform.position, gunSpawn.transform.rotation, gunSpawn.transform);
            currentWeapon = newWeapon.GetComponent<Weapon>();
            hasWeaponEquipped = true;
        }
    }

    public void Sprint()
    {
        sprintSpeed = currentSpeed + (currentSpeed / 10) * 2;

        if (Input.GetKey(KeyCode.LeftShift))
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
        if (Input.GetMouseButton(0))
        {
            currentWeapon.Shoot();
        }
    }

    public void LookAtMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Movement()
    {
        Vector3 m = new Vector3(movement.x, movement.y, 0) * Time.deltaTime * currentSpeed;
        Debug.Log(m);
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

    public void UseAbility(Ability ability)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ability.Use();
        }
    }
}
