using System.Collections;
using UnityEngine;

public class EnemyAIBoss : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 1.0f;

    private enum State
    {
        Roaming,
        Chasing,
        Attacking
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Transform playerTransform;
    private Animator animator;
    private bool isAttacking = false;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        animator = GetComponent<Animator>();
        state = State.Roaming;
    }

    private void Start()
    {
        playerTransform = PlayerController.Instance.transform;
        StartCoroutine(AIBehaviorRoutine());
    }

    private IEnumerator AIBehaviorRoutine()
    {
        while (true)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < attackRange)
            {
                state = State.Attacking;
            }
            else if (distanceToPlayer < detectionRange)
            {
                state = State.Chasing;
            }
            else
            {
                state = State.Roaming;
            }

            switch (state)
            {
                case State.Roaming:
                    Vector2 roamPosition = GetRoamingPosition();
                    enemyPathfinding.MoveTo(roamPosition);
                    animator?.SetTrigger("run");
                    break;

                case State.Chasing:
                    Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
                    enemyPathfinding.MoveTo(directionToPlayer);
                    animator?.SetTrigger("run");
                    break;

                case State.Attacking:
                    if (!isAttacking)
                    {
                        StartCoroutine(Attack());
                    }
                    break;
            }

            yield return new WaitForSeconds(roamChangeDirFloat);
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator?.SetTrigger("attack");

        // Gây sát thương cho người chơi
        PlayerHealth.Instance.TakeDamage(1, transform); // transform là của Boss

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
