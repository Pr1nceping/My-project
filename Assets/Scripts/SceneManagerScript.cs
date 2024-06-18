using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private static SceneManagerScript instance;
    public Animator transitionAnim;

    private int currentLevel = 0;
    private int completedLevelsCount = 0;

/*    private void Awake()
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
    }*/

    IEnumerator LoadScene(int currentLevel)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level" + currentLevel);
    }

    IEnumerator LoadMainSceneCoroutine()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainScene");
    }

    private void Initialize()
    {
        // Load completed levels from PlayerPrefs
        completedLevelsCount = 0;

        for (int i = 0; i < 4; i++) // Assuming 4 levels
        {
            if (PlayerPrefs.HasKey("Level" + (i + 1)))
            {
                // Level is completed
                completedLevelsCount++;
            }
            else
            {
                // First incomplete level found
                break;
            }
        }

        // Debug log the completion status of each level
        Debug.Log("SceneManagerScript: Levels completion status:");
        for (int i = 1; i <= 4; i++) // Assuming 4 levels
        {
            bool isCompleted = PlayerPrefs.HasKey("Level" + i);
            Debug.Log("SceneManagerScript: Level" + i + ": " + (isCompleted ? "Completed" : "Not Completed"));
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void LoadLevel(int level)
    {
        if (level > 0 && level <= 4) // Assuming 4 levels
        {
            currentLevel = level;
            StartCoroutine(LoadScene(currentLevel));
        }
        else
        {
            Debug.LogError("SceneManagerScript: Invalid level number.");
        }
    }


    public void LevelCompleted()
    {
        // Store completed level in PlayerPrefs
        PlayerPrefs.SetInt("Level" + currentLevel, 1);
        PlayerPrefs.Save();

        completedLevelsCount++;

        if (completedLevelsCount == 4)
        {
            // If all four levels are finished, go to the final level
            LoadFinalLevel();
        }
        else
        {
            // Otherwise, return to the MainScene
            LoadMainScene();
        }
    }

    public void LoadMainScene()
    {
        // Debug log when MainScene is loaded
        Debug.Log("SceneManagerScript: MainScene is loaded");
        StartCoroutine(LoadMainSceneCoroutine());
        Initialize(); // Call the initialize method to reload completion status
    }

    private void LoadFinalLevel()
    {
        // Debug log when FinalLevel is loaded
        Debug.Log("SceneManagerScript: FinalLevel is loaded");
        SceneManager.LoadScene("FinalLevel");
    }

    public void ResetLevelCompletionStatus()
    {
        // Reset all level completion status
        for (int i = 1; i <= 4; i++) // Assuming 4 levels
        {
            PlayerPrefs.DeleteKey("Level" + i);
        }
        PlayerPrefs.Save();

        // Reset completedLevelsCount
        completedLevelsCount = 0;

        Debug.Log("SceneManagerScript: Level completion status reset.");
    }
}
