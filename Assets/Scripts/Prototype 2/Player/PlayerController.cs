using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Sprite projectileSprite;
    public GameObject deflectionShield;
    public GameObject shieldReadyIndicator;
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float moveSpeed = 500f;
    [SerializeField]
    private float missileCoolDownTime = 0.5f;
    [SerializeField]
    private float shieldCooldownTime = 5.0f;
    [SerializeField]
    private float shieldActiveTime = 1.0f;
    [SerializeField]
    private bool isFiring = false;
    [SerializeField]
    private bool justFired = false;
    [SerializeField]
    private bool shieldActive = false;
    [SerializeField]
    private bool shieldOnCooldown = false;
    private Vector2 inputMovement;
    private GameObject tmpProjectile;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        deflectionShield.SetActive(false);
    }

    private void FixedUpdate()
    {
        float x = inputMovement.x * moveSpeed * Time.fixedDeltaTime;
        float y = inputMovement.y * moveSpeed * Time.fixedDeltaTime;
        rigidBody.velocity = new Vector2(x, y);
    }

    private void Update()
    {
        if (isFiring && !justFired)
        {
            StartCoroutine(FireProjectile());
        }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext value)
    {
        if ((value.started || value.performed) && gameObject.activeInHierarchy == true)
        {
            isFiring = true;
        }

        if (value.canceled)
        {
            isFiring = false;
        }
    }

    public void OnDeflect(InputAction.CallbackContext value)
    {
        if (value.started && !shieldActive && !shieldOnCooldown && gameObject.activeInHierarchy == true)
        {
            shieldActive = true;
            StartCoroutine(ActivateShield());
        }
    }

    public bool IsShieldActive()
    {
        return shieldActive;
    }

    IEnumerator ActivateShield()
    {
        deflectionShield.SetActive(true);
        yield return new WaitForSeconds(shieldActiveTime);
        shieldActive = false;
        shieldReadyIndicator.SetActive(false);
        deflectionShield.SetActive(false);
        
        shieldOnCooldown = true;
        yield return StartCoroutine(ShieldCooldown());
    }

    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSeconds(shieldCooldownTime);
        shieldOnCooldown = false;
        shieldReadyIndicator.SetActive(true);
    }

    IEnumerator MissileCooldown()
    {
        yield return new WaitForSeconds(missileCoolDownTime);
        justFired = false;
    }

    IEnumerator FireProjectile()
    {
        justFired = true;

        Vector3 spawnPosition =  new Vector3(transform.position.x, transform.position.y, 0);
        tmpProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            
        PlayerProjectile playerMissile = tmpProjectile.GetComponent<PlayerProjectile>();
        playerMissile.SetProjectileSprite(projectileSprite);
        playerMissile.Fire();
        
        yield return StartCoroutine(MissileCooldown());
    }
}
