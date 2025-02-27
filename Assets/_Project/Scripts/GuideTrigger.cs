using UnityEngine;
using UnityEngine.UI;

public class GuideTrigger : MonoBehaviour
{
    public AudioSource guideAudio;
    public Image guideImage;
    private bool hasTriggered = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; 

            Debug.Log("Player entered the trigger zone.");

            if (guideAudio != null && !guideAudio.isPlaying)
            {
                guideAudio.Play();
                Debug.Log("Guide audio is playing.");
            }

            if (guideImage != null)
            {
                guideImage.gameObject.SetActive(true);
                Debug.Log("Guide image is now visible.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && guideImage != null)
        {
            guideImage.gameObject.SetActive(false);
            Debug.Log("Guide image is now hidden.");
        }
    }
}
