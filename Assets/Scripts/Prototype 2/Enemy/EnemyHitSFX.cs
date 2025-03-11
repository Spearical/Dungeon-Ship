using UnityEngine;

public class EnemyHitSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hitSFX;
        [SerializeField]
    private AudioClip deathSFX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyHitSFX()
    {
        audioSource.PlayOneShot(hitSFX);
    }

    public void PlayEnemyDeathSFX()
    {
        audioSource.PlayOneShot(deathSFX);
    }
}
