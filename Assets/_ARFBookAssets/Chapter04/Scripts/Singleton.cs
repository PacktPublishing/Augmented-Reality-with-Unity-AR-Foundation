using UnityEngine;

/// <summary>
///     Singleton behaviour class, used for components that should only have one instance
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    /// <summary>
    ///     Returns whether the instance has been initialized or not.
    /// </summary>
    public static bool IsInitialized {
        get { return Instance != null; }
    }

    /// <summary>
    ///     Base awake method that sets the singleton's unique instance.
    /// </summary>
    protected virtual void Awake()
    {
        if (Instance != null)
            Debug.LogError($"Trying to instantiate a second instance of singleton class {GetType().Name}");
        else
            Instance = (T)this;
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}

