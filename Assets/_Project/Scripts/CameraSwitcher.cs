using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // مصفوفة تحتوي جميع الكاميرات
    private int currentCameraIndex = 0;

    void Start()
    {
        // تفعيل الكاميرا الأولى وإيقاف البقية
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }

    public void SwitchCamera()
    {
        // إيقاف تفعيل الكاميرا الحالية
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // تحديث الفهرس للدوران بين الكاميرات
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // تفعيل الكاميرا الجديدة
        cameras[currentCameraIndex].gameObject.SetActive(true);
    }
}
