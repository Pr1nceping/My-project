using UnityEngine;

public class WindAffectedParticle : MonoBehaviour
{
    public float decreaseDuration = 400.0f;
    private float elapsedTime;
    private float initialSize;

    public float sizeDecreaseRate = 0.1f;
    public float minSize = 0.0f; // Minimum size the particle can reach

    private new ParticleSystem particleSystem; // Use 'new' to explicitly hide the inherited member
    private ParticleSystem.MainModule mainModule;
    public GameObject windzone;
    private WindZone wind;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;

        // Find the GameObject named "WindZone"


        if (windzone != null)
        {
            // Try to get the WindZone component
            wind = windzone.GetComponent<WindZone>();

            if (wind == null)
            {
                Debug.LogWarning("WindZone component not found on the GameObject named 'WindZone'.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject named 'WindZone' not found in the scene.");
        }

    }

    void Update()
    {
        if (IsWindActive())
        {
            //DecreaseParticleSize();
        }
    }

    bool IsWindActive()
    {
        // Check if your Wind Zone component is active or any other condition
        // For simplicity, you can replace this with your own condition.
        // For example, you can add a public WindZone windZone; variable and check windZone.isActiveAndEnabled.

        return wind != null && wind.gameObject.activeSelf;
    }

    /*void DecreaseParticleSize()
    {
        Debug.Log("decreasing");
        elapsedTime += Time.deltaTime;

        // Use a custom function to smoothly decrease size over time
        float elapsedPercentage = Mathf.Clamp01(elapsedTime / decreaseDuration);
        float newSize = Mathf.Lerp(initialSize, 0f, elapsedPercentage);
        mainModule.startSize = newSize;
        Debug.Log(newSize);
    }*/
}
