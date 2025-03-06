using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Sprite projectileSprite;
    public GameObject deflectionShield;
    public GameObject shieldReadyRing;
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

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext value)
    {
        if (value.started  && !justFired)
        {
            justFired = true;
            StartCoroutine(MissileCooldown());
            
            float yOffset = 2.0f;
            Vector3 spawnPosition =  new Vector3(transform.position.x, transform.position.y + yOffset, 0);
            tmpProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            
            PlayerProjectile playerMissile = tmpProjectile.GetComponent<PlayerProjectile>();
            playerMissile.SetProjectileSprite(projectileSprite);
            playerMissile.Fire();
        }
    }

    public void OnDeflect(InputAction.CallbackContext value)
    {
        if (value.started && !shieldActive && !shieldOnCooldown)
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
        shieldReadyRing.SetActive(false);
        deflectionShield.SetActive(true);
        yield return new WaitForSeconds(shieldActiveTime);
        shieldActive = false;
        deflectionShield.SetActive(false);
        
        shieldOnCooldown = true;
        yield return StartCoroutine(ShieldCooldown());
    }

    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSeconds(shieldCooldownTime);
        shieldOnCooldown = false;
        shieldReadyRing.SetActive(true);
    }

    IEnumerator MissileCooldown()
    {
        yield return new WaitForSeconds(missileCoolDownTime);
        justFired = false;
    }
}
