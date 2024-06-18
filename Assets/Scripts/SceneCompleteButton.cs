using UnityEngine;
using UnityEngine.UI;

public class SceneCompleteButton : MonoBehaviour
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
        // Indicate level finished (you can add additional logic here if needed)

        // Save the level completion status
        sceneManager.LevelCompleted();
       

        // Return to the MainScene
        sceneManager.LoadMainScene();
    }
}
