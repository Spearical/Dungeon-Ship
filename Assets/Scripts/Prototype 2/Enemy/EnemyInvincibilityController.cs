using System.Collections;
using UnityEngine;

public class EnemyInvincibilityController : MonoBehaviour
{
    private SpriteFlash spriteFlashComponent;
    private EnemyDamageController enemyDamageController;
    void Awake()
    {
        enemyDamageController = GetComponent<EnemyDamageController>();
        spriteFlashComponent = GetComponent<SpriteFlash>();
    }

    public void StartInvincibility(float invincibilityDuration, Color flashColor, int numberOfFlashes)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration, flashColor, numberOfFlashes));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration, Color flashColor, int numberOfFlashes)
    {
        enemyDamageController.isInvincible = true;
        yield return spriteFlashComponent.FlashCoroutine(invincibilityDuration, flashColor, numberOfFlashes);
        enemyDamageController.isInvincible = false;
    }
}
