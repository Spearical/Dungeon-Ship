using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    IMovement movementBehavior;
    [SerializeField]
    private float movementStartDelay = 3.0f;
    private float timer;
    void Awake()
    {
        movementBehavior = GetComponent<IMovement>();
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timer > movementStartDelay)
        {
            movementBehavior.Move();
        }
    }
}
