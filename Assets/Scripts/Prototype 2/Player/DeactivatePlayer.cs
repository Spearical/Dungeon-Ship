using UnityEngine;

public class DeactivatePlayer : MonoBehaviour
{
    PlayerController playerController;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void DeactivatePlayerFunction()
    {
        playerController.enabled = false;
        spriteRenderer.enabled = false;
    }
}
