using UnityEngine;
using UnityEngine.UI;

public class ResetLevelButton : MonoBehaviour
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
        // Call the ResetLevelCompletionStatus function in SceneManagerScript
        sceneManager.ResetLevelCompletionStatus();
    }
}
