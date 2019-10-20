using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class PlayerController : MonoBehaviour
{
    public float baseSpeed;
    float currentSpeed;
    float sprintSpeed;
    //---------------------------------------------------------
    bool isSprinting = false;
    //---------------------------------------------------------
    public float currentStamina = 3.0f;
    public float MaxStamina = 3.0f;
    //---------------------------------------------------------
    private float StaminaRegenTimer = 0.0f;
    //---------------------------------------------------------
    private const float StaminaDecreasePerFrame = 1.0f;
    private const float StaminaIncreasePerFrame = 0.5f;
    private const float StaminaTimeToRegen = 1.5f;
    //---------------------------------------------------------
    //---------------------------------------------------------
    //private const float timeBetweenShots = 0.7f;
    //private float shotTimer;
    ////bool canShoot = true;

    int magSize;
    int currentBulletsInMag;
    float reloadTimer;
    float timeToReload;
    //---------------------------------------------------------
    //---------------------------------------------------------
    public GameObject shootPoint;
    public GameObject bulletPrefab;
    public GameObject gunSpawn;
    public GameObject[] Weapons;
    public bool hasWeaponEquipped;
    //---------------------------------------------------------
    //---------------------------------------------------------
    //enum Weapons {Pistol, SMG, AR, ARBurst, Shotgun};
    private Weapon currentWeapon;
    //---------------------------------------------------------
    //---------------------------------------------------------
    public enum PlayerClasses {Soldier, Medic, Scout, Engineer};
    public PlayerClasses playerClass;
    //---------------------------------------------------------
    //---------------------------------------------------------
    public int upgradePoints = 0;

    void Start()
    {
        currentSpeed = baseSpeed;
        currentWeapon = Weapons[0].GetComponent<Weapon>();
    }

    public void Update()
    {
        LookAtMouse();
        Movement();
        Sprint();
        Shoot();

        if(!hasWeaponEquipped)
        {
            var newWeapon = Instantiate(currentWeapon.gameObject, gunSpawn.transform.position, gunSpawn.transform.rotation, gunSpawn.transform);
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
