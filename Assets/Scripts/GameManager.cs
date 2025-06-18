using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TMP_Text victoryText;
    [SerializeField] private TMP_Text loseText;

    private int enemiesRemaining;
    private bool gameEnded = false;

    private void Start()
    {
        victoryText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);

        enemiesRemaining = FindObjectsOfType<EnemyHealth>().Length;
    }

    public void OnEnemyKilled()
    {
        if (gameEnded) return;

        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            gameEnded = true;
            victoryText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnPlayerDeath()
    {
        if (gameEnded) return;

        gameEnded = true;
        loseText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
