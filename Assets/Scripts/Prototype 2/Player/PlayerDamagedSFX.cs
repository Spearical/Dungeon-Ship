using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerDamagedSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip damagedSFX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayerDamagedSFX()
    {
        audioSource.PlayOneShot(damagedSFX);
    }
}
