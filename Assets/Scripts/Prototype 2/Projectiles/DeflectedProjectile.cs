using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DeflectedProjectile : MonoBehaviour
{
    public UnityEvent onHitByPlayer;
    public UnityEvent onHitByBrick;
    public UnityEvent onHitByMissile;
    public UnityEvent onAboutToExpire;
    public int maxHitsForDamageBoost = 3;
    public int hitsAgainstBrickDamageBoost = 10;
    public int hitsAgainstEnemyDamageBoost = 10;
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float speed = 500.0f;
    private const float MAX_TIME_ALIVE = 30.0f;
    [SerializeField]
    private float aliveTimer;
    [SerializeField]
    private int currentHitsForDamageBoost = 0;
    private const float BOUNCE_BOOST_BUFFER_TIME = 1.0f;
    private const float EXPIRE_INDICATOR_THRESHOLD = 5.0f;
    [SerializeField]
    private bool canRebounce;
    [SerializeField]
    private bool expireSignaled;
    public CollisionDamage collisionDamage;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collisionDamage = GetComponent<CollisionDamage>();
    }

    private void Start()
    {
        aliveTimer = 0;
        canRebounce = false;
        expireSignaled = false;
        SetRandomTrajectory();
    }

    private void Update()
    {
        RebounceBufferTimer();

        aliveTimer += Time.deltaTime;

        if ( MAX_TIME_ALIVE - aliveTimer <= EXPIRE_INDICATOR_THRESHOLD && !expireSignaled)
        {
            onAboutToExpire.Invoke();
            expireSignaled = true;
        }

        if (aliveTimer >=  MAX_TIME_ALIVE)
        {
            Destroy(gameObject);
        }
    }

    public void ScaleUpEnergyOrbSize(float scaleMultiplier)
    {
        transform.localScale = new Vector3(1 * scaleMultiplier, 1 * scaleMultiplier, 1 * scaleMultiplier);
    }

    private void RebounceBufferTimer()
    {
        if (!canRebounce)
        {
            StartCoroutine(BounceBoostBufferCoroutine());
        }
    }

    IEnumerator BounceBoostBufferCoroutine()
    {
        yield return new WaitForSeconds(BOUNCE_BOOST_BUFFER_TIME);
        canRebounce = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DecreaseBouncesOnBrickContact(collision.gameObject);

        if (canRebounce)
        {
            IncreaseBouncesOnPlayerContact(collision.gameObject);
        }
        
        if (currentHitsForDamageBoost < maxHitsForDamageBoost)
        {
            BoostDamageOnPlayerMissileContact(collision.gameObject);
        }
    }

    private void DecreaseBouncesOnBrickContact(GameObject collisionObject)
    {
        if (collisionObject.TryGetComponent<BrickDamageController>
            (out BrickDamageController brickDamageController))
        {
            if (!brickDamageController.isUnbreakable)
            {
                onHitByBrick.Invoke();
            }
        }
    }

    private void IncreaseBouncesOnPlayerContact(GameObject collisionObject)
    {
        if (collisionObject.CompareTag("Player"))
        {
            canRebounce = false;
            onHitByPlayer.Invoke();
        }
    }

    private void BoostDamageOnPlayerMissileContact(GameObject collisionObject)
    {
        if (collisionObject.TryGetComponent<PlayerProjectile>
            (out PlayerProjectile playerProjectile))
        {
            onHitByMissile.Invoke();
            currentHitsForDamageBoost++;
            collisionDamage.brickDmgAmount += hitsAgainstBrickDamageBoost;
            collisionDamage.enemyDmgAmount += hitsAgainstEnemyDamageBoost;
        }
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1.0f, 1.0f);
        force.y = 1f;

        rigidBody.AddForce(force.normalized * speed);
    }
}
