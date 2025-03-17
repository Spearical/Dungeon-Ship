using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private IMovement movementBehavior;
    [SerializeField]
    private float movementStartDelay = 3.0f;
    private float timer;
    private bool isMovementDisabled;
    public bool isStaticEnemy;
    void Awake()
    {
        if (!isMovementDisabled)
        {
            movementBehavior = GetComponent<IMovement>();
        }
    }

    void OnEnable()
    {
        isMovementDisabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (!isStaticEnemy && !isMovementDisabled && timer > movementStartDelay)
        {
            movementBehavior.Move();
        }
    }

    public void DisableMovement()
    {
        isMovementDisabled = true;
    }

}
