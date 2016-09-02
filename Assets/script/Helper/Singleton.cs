// Source: http://wiki.unity3d.com/index.php/Singleton

using UnityEngine;

public class Singleton<TInstance> : MonoBehaviour where TInstance : MonoBehaviour
{
    public static TInstance Instance;
    public static bool Persistant { get; set; }

    public virtual void Awake()
    {
        if (Persistant)
        {
            if (!Instance)
            {
                Instance = this as TInstance;
            }
            else
            {
                DestroyObject(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance = this as TInstance;
        }

        // If object already exists, destroy it.
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}