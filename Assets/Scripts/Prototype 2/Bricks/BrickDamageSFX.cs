using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BrickDamageSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip damagedSFX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBrickDamagedSFX()
    {
        audioSource.pitch = Random.Range(1, 4);
        audioSource.PlayOneShot(damagedSFX);
    }
}
