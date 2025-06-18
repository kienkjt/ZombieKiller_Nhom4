using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TMP_Text victoryText;
    [SerializeField] private TMP_Text loseText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject retryButton;

    [SerializeField] private AudioClip victorySound;
    [SerializeField] private AudioClip loseSound;

    private AudioSource audioSource;
    private int enemiesRemaining;
    private bool gameEnded = false;

    private void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (victoryText != null) victoryText.gameObject.SetActive(false);
        if (loseText != null) loseText.gameObject.SetActive(false);
        if (nextLevelButton != null) nextLevelButton.SetActive(false);
        if (retryButton != null) retryButton.SetActive(false);

        enemiesRemaining = FindObjectsOfType<EnemyHealth>().Length;

        audioSource = GetComponent<AudioSource>();
    }

    public void OnEnemyKilled()
    {
        if (gameEnded) return;

        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            gameEnded = true;
            ShowVictoryUI();
        }
    }

    public void OnPlayerDeath()
    {
        if (gameEnded) return;

        gameEnded = true;
        ShowLoseUI();
    }

    private void ShowVictoryUI()
    {
        if (audioSource != null && victorySound != null)
            audioSource.PlayOneShot(victorySound);

        if (victoryText != null) victoryText.gameObject.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (nextLevelButton != null) nextLevelButton.SetActive(true);
        if (loseText != null) loseText.gameObject.SetActive(false);
        if (retryButton != null) retryButton.SetActive(false);
        Time.timeScale = 0f;
    }

    private void ShowLoseUI()
    {
        if (audioSource != null && loseSound != null)
            audioSource.PlayOneShot(loseSound);

        if (loseText != null) loseText.gameObject.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (nextLevelButton != null) nextLevelButton.SetActive(false);
        if (victoryText != null) victoryText.gameObject.SetActive(false);
        if (retryButton != null) retryButton.SetActive(true);
        Time.timeScale = 0f;
    }
}
