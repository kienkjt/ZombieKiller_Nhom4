using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Staff : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject magicLaser;
    [SerializeField] private Transform magicLaserSpawnPoint;

    [Header("Audio")]
    [SerializeField] private AudioClip swingSound;

    private AudioSource audioSource;
    private Animator myAnimator;

    private readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

        if (swingSound != null)
        {
            audioSource.PlayOneShot(swingSound);
        }
        else
        {
            Debug.LogWarning("⚠️ Staff swingSound chưa được gán trong Inspector.");
        }
    }

    public void SpawnStaffProjectileAnimEvent()
    {
        if (magicLaser != null && magicLaserSpawnPoint != null)
        {
            GameObject newLaser = Instantiate(magicLaser, magicLaserSpawnPoint.position, Quaternion.identity);
            newLaser.GetComponent<MagicLaser>().UpdateLaserRange(weaponInfo.weaponRange);
        }
        else
        {
            Debug.LogWarning("⚠️ magicLaser hoặc magicLaserSpawnPoint chưa được gán.");
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y - playerScreenPoint.y, mousePos.x - playerScreenPoint.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
