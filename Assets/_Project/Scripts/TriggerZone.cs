using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public AudioSource guideAudio;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger zone.");

        if (other.CompareTag("Player"))
        {
            if (guideAudio != null && !guideAudio.isPlaying)
            {
                guideAudio.Play();
                Debug.Log("Guide audio is playing.");
            }
        }
    }
}
