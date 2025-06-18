using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void ThoatRaMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void QuayLai()
    {
        SceneManager.LoadScene(0);
    }
    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(5);
    }
}
