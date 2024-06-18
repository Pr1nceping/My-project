using UnityEngine;
using UnityEngine.UI;

public class ObjectTransparencyController : MonoBehaviour
{
    public Image image;
    public GameObject targetObject;
    public ParticleSystem snowParticleSystem;
    public float maxAngle = 45f; // Maximum angle at which transparency is 0.5

    private Transform cameraTransform;



    void Start()
    {
        cameraTransform = Camera.main.transform; // Assuming you are using the main camera
        snowParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (IsCameraPointingAtObject())
        {
            // Camera is pointing at the object, adjust transparency
            UpdateTransparencyAndColor();
        }
        else
        {
            // Camera is not pointing at the object, set transparency to 0
            SetImageTransparency(0f);
        }
    }

    private bool IsCameraPointingAtObject()
    {
        if (targetObject == null)
        {
            return false;
        }

        Vector3 cameraToObject = targetObject.transform.position - cameraTransform.position;
        float angle = Vector3.Angle(cameraTransform.forward, cameraToObject);
        return angle <= maxAngle;
    }

    private void UpdateTransparencyAndColor()
    {
        Vector3 cameraToObject = targetObject.transform.position - cameraTransform.position;
        float angle = Vector3.Angle(cameraTransform.forward, cameraToObject);

        // Calculate transparency based on the angle
        float transparency = Mathf.Clamp01(1f - angle / maxAngle);
        SetImageAndParticleTransparency(transparency);
    }

    private void SetImageAndParticleTransparency(float transparency)
    {
        // Set transparency for the image
        SetImageTransparency(transparency);

        // Set transparency for the particle system's start color
        var mainModule = snowParticleSystem.main;
        Color startColor = mainModule.startColor.color;
        startColor.a = transparency;
        mainModule.startColor = startColor;
    }

    private void SetImageTransparency(float transparency)
    {
        Color currentColor = image.color;
        currentColor.a = transparency;
        image.color = currentColor;
    }
}
