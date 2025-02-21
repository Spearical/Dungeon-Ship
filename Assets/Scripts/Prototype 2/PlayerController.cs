using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Sprite projectileSprite;
    public GameObject deflectionShield;
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float moveSpeed = 50f;
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
    private Vector3 rawInputMovement;
    private GameObject tmpProjectile;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        deflectionShield.SetActive(false);
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(rawInputMovement * moveSpeed);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, inputMovement.y, 0f);
    }

    public void OnShoot(InputAction.CallbackContext value)
    {
        if (value.started  && !justFired)
        {
            justFired = true;
            StartCoroutine(MissileCooldown());
            tmpProjectile = Instantiate(projectilePrefab, transform.position + Vector3.up, Quaternion.identity);
            
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

    IEnumerator ActivateShield()
    {
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
    }

    IEnumerator MissileCooldown()
    {
        yield return new WaitForSeconds(missileCoolDownTime);
        justFired = false;
    }
}
