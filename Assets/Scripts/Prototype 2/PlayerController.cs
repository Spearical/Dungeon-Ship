using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float moveSpeed = 50f;
    private Vector3 rawInputMovement;
    private GameObject tmpProjectile;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        if (value.started)
        {
            tmpProjectile = Instantiate(projectilePrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpProjectile.GetComponent<ProjectileBehavior>().Fire();
        }
    }
}
