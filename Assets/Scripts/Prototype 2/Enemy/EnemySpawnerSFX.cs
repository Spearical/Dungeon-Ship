using UnityEngine;

public class EnemySpawnerSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip portalSFX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPortalOpenedSFX()
    {
        audioSource.PlayOneShot(portalSFX);
    }
}
