using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ParkingCheck : MonoBehaviour
{
    public bool isParkedCorrectly = false;

    public TextMeshProUGUI parkingText;  // UI Text to display success message
    public Image parkingImage;           // UI Image to show when parked
    public Image crashImage;             // UI Image to show when crashed
    public AudioSource parkingSound;     // AudioSource to play a sound
    public AudioSource crashSound;       // Sound for collision

    private bool isInsideParkingZone = false; // Checks if the car is inside the parking collider
    private bool isColliding = false; // Checks if the car is touching another vehicle

    public Transform parkingZoneTransform; // Reference to the parking zone transform
    public float rotationTolerance = 15f; // Allowable rotation error (degrees)

    private void Start()
    {
        if (parkingText != null)
            parkingText.gameObject.SetActive(false);

        if (parkingImage != null)
            parkingImage.gameObject.SetActive(false);

        if (crashImage != null)
            crashImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isInsideParkingZone && !isColliding && IsRotationCorrect())
        {
            if (!isParkedCorrectly)
            {
                isParkedCorrectly = true;
                ShowParkingSuccess();
            }
            return;
        }

        isParkedCorrectly = false;
        HideParkingIndicator();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ParkingZone"))
        {
            isInsideParkingZone = true;
        }

        if (other.CompareTag("FrontCar") || other.CompareTag("BackCar"))
        {
            isColliding = true;
            ShowCrashIndicator();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ParkingZone"))
        {
            isInsideParkingZone = false;
        }

        if (other.CompareTag("FrontCar") || other.CompareTag("BackCar"))
        {
            isColliding = false;
            HideCrashIndicator();
        }
    }

    private bool IsRotationCorrect()
    {
        if (parkingZoneTransform == null) return true; // If no reference, ignore rotation check

        float playerRotationY = transform.eulerAngles.y;
        float parkingRotationY = parkingZoneTransform.eulerAngles.y;

        float rotationDifference = Mathf.Abs(Mathf.DeltaAngle(playerRotationY, parkingRotationY));

        return rotationDifference <= rotationTolerance;
    }

    private void ShowParkingSuccess()
    {
        Debug.Log("Parked Successfully!");

        if (parkingText != null)
        {
            parkingText.gameObject.SetActive(true);
            parkingText.text = "Parked Successfully!";
        }

        if (parkingImage != null)
        {
            parkingImage.gameObject.SetActive(true);
        }

        if (parkingSound != null && !parkingSound.isPlaying)
        {
            parkingSound.Play();
        }
    }

    private void HideParkingIndicator()
    {
        if (parkingText != null)
            parkingText.gameObject.SetActive(false);

        if (parkingImage != null)
            parkingImage.gameObject.SetActive(false);
    }

    private void ShowCrashIndicator()
    {
        Debug.Log("Collision detected!");

        if (crashImage != null)
        {
            crashImage.gameObject.SetActive(true);
        }

        if (crashSound != null && !crashSound.isPlaying)
        {
            crashSound.Play();
        }
    }

    private void HideCrashIndicator()
    {
        if (crashImage != null)
            crashImage.gameObject.SetActive(false);
    }
}
