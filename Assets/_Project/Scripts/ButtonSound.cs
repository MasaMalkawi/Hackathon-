/*using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; 

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); 
        }
    }
}
*/
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void ToggleSound()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();  // إذا كان الصوت يعمل، يتم إيقافه
                Debug.Log("الصوت توقف!");
            }
            else
            {
                audioSource.Play();  // إذا لم يكن يعمل، يتم تشغيله
                Debug.Log("الصوت يعمل!");
            }
        }
    }
}
