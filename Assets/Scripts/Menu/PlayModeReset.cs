using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[InitializeOnLoad]
public static class PlayModeReset
{
    static PlayModeReset()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            PlayerPrefs.DeleteAll(); // Reset lại toàn bộ key
            Debug.Log("PlayerPrefs đã được xóa khi bắt đầu Play Mode.");
        }
    }
}
