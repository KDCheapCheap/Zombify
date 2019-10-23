using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


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
    

    public virtual void Start()
    {
        currentSpeed = baseSpeed;
        currentWeapon = Weapons[1].GetComponent<Weapon>();
    }

    public virtual void Update()
    {
        LookAtMouse();
        Movement();
        Sprint();
        Shoot();

        if(!hasWeaponEquipped)
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
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        transform.Translate(xMovement * Time.deltaTime * currentSpeed, yMovement * Time.deltaTime * currentSpeed, 0, Space.World);
    }
}
