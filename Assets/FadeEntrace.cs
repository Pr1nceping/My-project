using System.Collections;
using UnityEngine;

public class FadeEntrace : MonoBehaviour
{
    public int SceneNumToLoad;
    public SceneManagerScript sceneManager;
    public bool canEntry = false;
    public GameObject water;

    public float targetY = 10.0f; // Set the target Y position
    public float duration = 3.0f; // Set the duration of the movement

    private float elapsedTime = 0.0f;
    private Vector3 initialPosition;

    public GameObject character;
    public WaterFloat float_;


    private void Start()
    {
        initialPosition = water.transform.localPosition;
        character = GameObject.Find("YingChun");
        float_ = character.GetComponent<WaterFloat>();
    }
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
                    StartCoroutine(FadeEffectCoroutine());
                }
            }
        }
        // Check for touch input

    }

    private IEnumerator FadeEffectCoroutine()
    {
        // Perform your fade effect here using shaders, materials, CanvasGroup, etc.
        // For example, you can use a coroutine to gradually change alpha over time
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            float newY = Mathf.Lerp(initialPosition.y, targetY, t);

            water.transform.localPosition = new Vector3(water.transform.localPosition.x, newY, transform.localPosition.z) ;
            float_.enabled = true;
            yield return null;
        }

        // Optionally, load the new scene after the fade effect completes
        //sceneManager.LoadLevel(SceneNumToLoad);
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
