using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Public variable to customize the duration of the day in seconds
    public float dayDuration = 60f; // 60 seconds = 1 day
    public Light directionalLight;  // Reference to the directional light
    public float maxLightIntensity = 1f;  // Maximum light intensity (for day)
    public float minLightIntensity = 0f;  // Minimum light intensity (for night)

    private float timeOfDay = 0f;  // 0 = midnight, 1 = next midnight
    private float lightRotationSpeed; // Speed at which light rotates

    void Start()
    {
        if (directionalLight == null)
        {
            directionalLight = GetComponent<Light>();
        }

        // Calculate the speed at which the light rotates based on the day duration
        lightRotationSpeed = 360f / dayDuration;
    }

    void Update()
    {
        // Update the time of day
        timeOfDay += Time.deltaTime / dayDuration;

        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f; // Reset the cycle after 1 full day
        }

        // Rotate the directional light based on the time of day
        float lightRotation = timeOfDay * 360f;

        // Rotate the light
        directionalLight.transform.rotation = Quaternion.Euler(lightRotation, 0f, 0f);

        // Adjust the intensity of the light based on the time of day
        float intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, Mathf.Abs(Mathf.Cos(timeOfDay * Mathf.PI)));
        directionalLight.intensity = intensity;
    }
}
