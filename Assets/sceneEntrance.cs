using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public int SceneNumToLoad;
    public SceneManagerScript sceneManager;
    public bool canEntry = false;

    void Update()
    {
        if (canEntry)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // Assuming only one touch for simplicity

                // Check if the touch position is over the GameObject
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("beauty"))
                {
                    // Touch is on the GameObject
                    if (touch.phase == TouchPhase.Began)
                    {
                        Debug.Log("load new scene");
                        sceneManager.LoadLevel(SceneNumToLoad);
                    }
                }
            }
            else if (Input.GetMouseButtonDown(0)) // Check for left mouse click
            {
                // Check if the mouse click is over the GameObject
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.Log("Tapped");
                if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("beauty"))
                {
                    // Mouse click is on the GameObject
                    Debug.Log("Load new scene");
                    sceneManager.LoadLevel(SceneNumToLoad);
                }
            }
        }
        // Check for touch input
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("beauty"))
        {
            canEntry = true;
            Debug.Log(canEntry);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("beauty"))
        {
            canEntry = false;
        }
    }
}
