using System.Collections;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private SpriteFlash spriteFlashComponent;
    private PlayerDamageController playerDamageController;
    void Awake()
    {
        playerDamageController = GetComponent<PlayerDamageController>();
        spriteFlashComponent = GetComponent<SpriteFlash>();
    }

    public void StartInvincibility(float invincibilityDuration, Color flashColor, int numberOfFlashes)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration, flashColor, numberOfFlashes));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration, Color flashColor, int numberOfFlashes)
    {
        playerDamageController.isInvincible = true;
        yield return spriteFlashComponent.FlashCoroutine(invincibilityDuration, flashColor, numberOfFlashes);
        playerDamageController.isInvincible = false;
    }
}
