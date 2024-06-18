using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionButton : MonoBehaviour
{
    private SceneManagerScript sceneManager;

    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManagerScript>();
        if (sceneManager == null)
        {
            Debug.LogError("SceneManagerScript not found in the scene.");
        }

        // Attach a listener to the button's click event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        // Extract the number from the button's name
        int buttonNumber;
        bool success = int.TryParse(gameObject.name.Replace("Button", ""), out buttonNumber);

        if (success)
        {
            // Load the corresponding level
            sceneManager.LoadLevel(buttonNumber);
        }
        else
        {
            Debug.LogError("Failed to parse button number from button name.");
        }
    }
}
