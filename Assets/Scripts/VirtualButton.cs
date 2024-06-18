using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton : MonoBehaviour
{
    public GameObject cube;
    public VirtualButtonBehaviour Vb;
    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        Vb.RegisterOnButtonPressed(onButtonPressed);
        Vb.RegisterOnButtonReleased(onButtonReleased);
        cube.SetActive(false);
    }

    // Update is called once per frame
    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        cube.SetActive(true);
        StartCoroutine(MoveModelCoroutine());
    }

    public void onButtonReleased(VirtualButtonBehaviour vb)
    {
        cube.SetActive(false);
    }

    IEnumerator MoveModelCoroutine()
    {
        Vector3 targetPosition = transform.position + new Vector3(510, 0, -510);
        float lerpTime = 3f;
        float elapsedTime = 0f;

        Vector3 initialPosition = model.transform.position;

        while (elapsedTime < lerpTime)
        {
            model.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / lerpTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the model reaches the exact target position
        model.transform.position = targetPosition;
    }
}
