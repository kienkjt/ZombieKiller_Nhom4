using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1); // Scene chọn màn
    }

    public void QuayLai()
    {
        SceneManager.LoadScene(0); // Về menu chính
    }
    public void ThoatRaMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(2); // Luôn được mở
    }

    public void LoadLevel2()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 2)
            SceneManager.LoadScene(3); // Mở sau khi hoàn thành Level1
        else
            Debug.Log("Level 2 chưa được mở.");
    }

    public void LoadLevel3()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 3)
            SceneManager.LoadScene(4);
        else
            Debug.Log("Level 3 chưa được mở.");
    }

    public void LoadLevel4()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel", 1) >= 4)
            SceneManager.LoadScene(5);
        else
            Debug.Log("Level 4 chưa được mở.");
    }
}
