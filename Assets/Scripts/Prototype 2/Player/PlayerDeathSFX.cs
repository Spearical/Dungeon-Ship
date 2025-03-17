using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerDeathSFX : MonoBehaviour
{
    [SerializeField]
    private new ParticleSystem particleSystem;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip explosionSFX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayerDiedSFX()
    {
        StartCoroutine(PlayerDiedCoroutine());
    }

    IEnumerator PlayerDiedCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(explosionSFX);
        particleSystem.Play();
    }
}
