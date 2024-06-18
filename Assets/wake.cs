using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wake : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameobject;

    private void Start()
    {
        Debug.Log("Start method called.");
        gameobject.SetActive(true);
        Debug.Log("GameObject set to active.");
    }
}
