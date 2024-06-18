using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyonLoad : MonoBehaviour
{
    private static dontDestroyonLoad instance;
    private void Awake()
    {
        // Ensure there's only one instance of SceneManagerScript
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
}
