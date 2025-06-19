using UnityEngine;

public class PlayerPrefsResetOnPlay : MonoBehaviour
{
    void Awake()
    {
#if UNITY_EDITOR
        if (!PlayerPrefs.HasKey("FirstPlay"))
        {
            PlayerPrefs.DeleteAll(); // Reset toàn bộ dữ liệu khi chạy từ đầu
            PlayerPrefs.SetInt("FirstPlay", 1);
            PlayerPrefs.Save();
        }
#endif
    }
}
