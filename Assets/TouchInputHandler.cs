using UnityEngine;

public class TouchInputHandler : MonoBehaviour
{
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Loop through all the touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check touch phase
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Handle touch beginning
                        HandleTouchBegin(touch.position);
                        break;
                    case TouchPhase.Ended:
                        // Handle touch ending
                        HandleTouchEnd(touch.position);
                        break;
                }
            }
        }
    }

    void HandleTouchBegin(Vector2 touchPosition)
    {
        Debug.Log("Touch began at: " + touchPosition);
    }


    void HandleTouchEnd(Vector2 touchPosition)
    {
        Debug.Log("Touch ended at: " + touchPosition);
    }
}