using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;
    [SerializeField] private float detectionRange = 10f;

    private enum State
    {
        Roaming,
        Chasing
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Transform playerTransform;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        playerTransform = PlayerController.Instance.transform;
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < detectionRange)
            {
                state = State.Chasing;
            }
            else
            {
                state = State.Roaming;
            }

            if (state == State.Roaming)
            {
                Vector2 roamPosition = GetRoamingPosition();
                enemyPathfinding.MoveTo(roamPosition);
            }
            else if (state == State.Chasing)
            {
                Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
                enemyPathfinding.MoveTo(directionToPlayer);
            }

            yield return new WaitForSeconds(roamChangeDirFloat);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
