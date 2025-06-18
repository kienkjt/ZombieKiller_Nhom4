using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MeleeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip swingSound;
    [SerializeField] private AudioClip hitZombieSound;
    [SerializeField] private AudioClip hitWoodSound;

    private AudioSource audioSource;

    public WeaponInfo GetWeaponInfo() => weaponInfo;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        if (swingSound != null)
            audioSource.PlayOneShot(swingSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && hitZombieSound != null)
        {
            audioSource.PlayOneShot(hitZombieSound);
        }
        else if (other.CompareTag("Wood") && hitWoodSound != null)
        {
            audioSource.PlayOneShot(hitWoodSound);
        }
    }
}
