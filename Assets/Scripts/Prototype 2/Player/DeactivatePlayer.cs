using System.Collections;
using UnityEngine;

public class DeactivatePlayer : MonoBehaviour
{
    PlayerController playerController;
    PlayerDamageController playerDamageController;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerDamageController = GetComponent<PlayerDamageController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void DeactivatePlayerFunction()
    {
        StartCoroutine(DeactivatePlayerCoroutine());
    }

    IEnumerator DeactivatePlayerCoroutine()
    {
        playerDamageController.enabled = false;
        playerController.enabled = false;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = false;
    }
}
