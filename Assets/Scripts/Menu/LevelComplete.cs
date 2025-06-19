using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public int currentLevel = 1; // Ví dụ: Level1 = 1, Level2 = 2...

    public void HoanThanhLevel()
    {
        int levelDaMo = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentLevel >= levelDaMo)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save();
        }

        // Quay lại menu chọn level (scene index 1)
        SceneManager.LoadScene(1);
    }
}
