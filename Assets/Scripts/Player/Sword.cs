using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sword : MonoBehaviour, IWeapon
{
    [Header("Attack Settings")]
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private float swordAttackCD = 0.5f;
    [SerializeField] private WeaponInfo weaponInfo;

    [Header("Audio")]
    [SerializeField] private AudioClip swingSound;
    private AudioSource audioSource;

    private GameObject slashAnim;
    private Transform weaponCollider;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        weaponCollider = PlayerController.Instance.GetWeaponCollider();

        // Tự gán SlashSpawnPoint nếu chưa gán trong Inspector
        if (slashAnimSpawnPoint == null)
        {
            GameObject foundPoint = GameObject.Find("SlashSpawnPoint");
            if (foundPoint != null)
                slashAnimSpawnPoint = foundPoint.transform;
            else
                Debug.LogWarning("⚠️ SlashSpawnPoint not found!");
        }
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    public WeaponInfo GetWeaponInfo() => weaponInfo;

    public void Attack()
    {
        myAnimator.SetTrigger("Attack");

        // Kích hoạt collider vũ khí
        if (weaponCollider != null)
            weaponCollider.gameObject.SetActive(true);

        // Tạo slash animation
        if (slashAnimPrefab != null && slashAnimSpawnPoint != null)
        {
            slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
            slashAnim.transform.parent = this.transform.parent;
        }

        // Phát âm thanh chém
        if (swingSound != null)
        {
            audioSource.PlayOneShot(swingSound);
        }
        else
        {
            Debug.LogWarning("⚠️ Swing sound is not assigned!");
        }
    }

    public void DoneAttackingAnimEvent()
    {
        if (weaponCollider != null)
            weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnimEvent()
    {
        if (slashAnim == null) return;

        slashAnim.transform.rotation = Quaternion.Euler(-180, 0, 0);
        slashAnim.GetComponent<SpriteRenderer>().flipX = PlayerController.Instance.FacingLeft;
    }

    public void SwingDownFlipAnimEvent()
    {
        if (slashAnim == null) return;

        slashAnim.transform.rotation = Quaternion.Euler(0, 0, 0);
        slashAnim.GetComponent<SpriteRenderer>().flipX = PlayerController.Instance.FacingLeft;
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);
        float angle = Mathf.Atan2(mousePos.y - playerScreenPoint.y, mousePos.x - playerScreenPoint.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
            if (weaponCollider != null)
                weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
            if (weaponCollider != null)
                weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
