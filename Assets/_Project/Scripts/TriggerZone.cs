using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public AudioSource guideAudio;
    private bool hasTriggered = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; 
            Debug.Log("Player entered the trigger zone for the first time.");

            if (guideAudio != null && !guideAudio.isPlaying)
            {
                guideAudio.Play();
                Debug.Log("Guide audio is playing.");
            }
        }
    }
}
