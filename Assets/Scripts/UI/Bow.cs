using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;

    [Header("Audio")]
    [SerializeField] private AudioClip swingSound;
    private AudioSource audioSource;

    private readonly int FIRE_HASH = Animator.StringToHash("Fire");
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);

        // Play bow swing sound
        if (swingSound != null)
        {
            audioSource.PlayOneShot(swingSound);
        }
        else
        {
            Debug.LogWarning("⚠️ Bow swingSound chưa được gán trong Inspector.");
        }

        // Spawn arrow
        if (arrowPrefab != null && arrowSpawnPoint != null)
        {
            GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
            newArrow.GetComponent<Projectile>().UpdateWeaponInfo(weaponInfo);
        }
        else
        {
            Debug.LogWarning("⚠️ arrowPrefab hoặc arrowSpawnPoint chưa được gán.");
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
