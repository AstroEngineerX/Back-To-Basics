using UnityEngine;

public class Hit : MonoBehaviour
{
    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Reference to the AudioClip that will be played on collision
    public AudioClip hitSound;

    // Minimum velocity threshold to trigger the sound (can be adjusted)
    public float velocityThreshold = 0.5f;

    // Maximum volume to scale the sound
    public float maxVolume = 1.0f;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Ensure that there is an AudioClip assigned to bounceSound
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this GameObject");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the ball's velocity is above the threshold
        if (audioSource != null && hitSound != null)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null && rb.linearVelocity.magnitude > velocityThreshold)
            {
                // Calculate volume based on the ball's speed (velocity magnitude)
                float volume = Mathf.Clamp(rb.linearVelocity.magnitude / 10f, 0f, maxVolume);

                // Play the bounce sound with the calculated volume
                audioSource.PlayOneShot(hitSound, volume);
            }
        }
    }
}
