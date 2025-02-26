using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ParallelParkingCheck : MonoBehaviour
{
    public bool isParkedCorrectly = false;

    public TextMeshProUGUI parkingText;  // UI Text to display success message
    public Image parkingImage;           // UI Image to show when parked
    public AudioSource parkingSound;     // AudioSource to play a sound

    private int parkingTriggersInside = 0; // Ensures whole car is inside
    private bool isColliding = false; // Checks if the car is touching another vehicle

    private void Start()
    {
        if (parkingText != null)
            parkingText.gameObject.SetActive(false);

        if (parkingImage != null)
            parkingImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Ensure the whole car is inside and not colliding
        if (parkingTriggersInside > 0 && !isColliding)
        {
            if (!isParkedCorrectly)
            {
                isParkedCorrectly = true;
                ShowParkingSuccess();
            }
            return;
        }

        // If conditions are not met, reset parked state
        isParkedCorrectly = false;
        HideParkingIndicator();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ParkingZone"))
        {
            parkingTriggersInside++;
        }

        if (other.CompareTag("FrontCar") || other.CompareTag("BackCar"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ParkingZone"))
        {
            parkingTriggersInside--;
        }

        if (other.CompareTag("FrontCar") || other.CompareTag("BackCar"))
        {
            isColliding = false;
        }
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
}
