using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject loseText;
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject panel;

    public void ShowLose()
    {
        panel.SetActive(true);
        loseText.SetActive(true);
        victoryText.SetActive(false);
    }

    public void ShowVictory()
    {
        panel.SetActive(true);
        victoryText.SetActive(true);
        loseText.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
