using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A timer
/// </summary>
public class Timer : MonoBehaviour {

    private static Timer instance;
    private float totalSeconds = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        totalSeconds += Time.deltaTime;
    }

    public static Timer GetInstance()
    {
        return instance;
    }

    public float GetTotalSeconds()
    {
        return totalSeconds;
    }
}
