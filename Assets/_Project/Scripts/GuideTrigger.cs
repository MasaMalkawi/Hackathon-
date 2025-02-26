using UnityEngine;
using UnityEngine.UI;

public class GuideTrigger : MonoBehaviour
{

    public AudioSource guideAudio;
    public Image guideImage; // صورة تُعرض عند دخول اللاعب

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

            if (guideImage != null)
            {
                guideImage.gameObject.SetActive(true); // عرض الصورة
                Debug.Log("Guide image is now visible.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && guideImage != null)
        {
            guideImage.gameObject.SetActive(false); // إخفاء الصورة عند خروج اللاعب
            Debug.Log("Guide image is now hidden.");
        }
    }
}


