using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MeleeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip swingSound;
    [SerializeField] private AudioClip hitZombieSound;
    [SerializeField] private AudioClip hitWoodSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public WeaponInfo GetWeaponInfo() => weaponInfo;

    public void Attack()
    {
        if (swingSound != null)
            audioSource.PlayOneShot(swingSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.activeInHierarchy) return;

        if (other.CompareTag("Enemy"))
        {
            if (hitZombieSound != null)
                StartCoroutine(PlayShortZombieSound(hitZombieSound, 0.2f)); // 0.2s or tune to your liking
        }
        else if (other.CompareTag("Wood"))
        {
            if (hitWoodSound != null)
                audioSource.PlayOneShot(hitWoodSound);
        }
    }

    private IEnumerator PlayShortZombieSound(AudioClip clip, float duration)
    {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(duration);
        if (audioSource.clip == clip) audioSource.Stop();
        audioSource.clip = null;
    }
}
