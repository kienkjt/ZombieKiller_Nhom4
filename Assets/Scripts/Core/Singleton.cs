using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool dontDetroyOnLoad;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>(true);

                if (instance == null)
                {
                    Debug.LogError($"[Singleton<{typeof(T).Name}>] Không tìm thấy instance trong scene! Hãy đảm bảo script '{typeof(T).Name}' đã được gắn vào một GameObject trong scene.");
                }
            }
            return instance;
        }
    }

    protected virtual void KeepAlive(bool enable)
    {
        dontDetroyOnLoad = enable;
    }

    protected virtual void Awake()
    {
        if (instance != null && instance.GetInstanceID() != GetInstanceID())
        {
            Destroy(this);
            return;
        }

        instance = this as T;

        if (dontDetroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
