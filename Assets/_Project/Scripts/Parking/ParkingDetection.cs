using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ParkingDetection : MonoBehaviour
{
    public bool isParkedCorrectly = false;

    public TextMeshProUGUI parkingText;  // UI text to show success message
    public Image parkingImage;           // UI image to display success
    public AudioSource parkingSound;     // Sound effect when parked

    private int parkingTriggersInside = 0; // Counter for ensuring entire car is inside
    private bool isColliding = false; // Checks if the car is touching another vehicle

    private void Start()
    {
        if (parkingText != null)
            parkingText.gameObject.SetActive(false); // Hide text at start

        if (parkingImage != null)
            parkingImage.gameObject.SetActive(false); // Hide image at start
    }

    private void Update()
    {
        // The car must have all its colliders inside the parking zone and not be colliding
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
        if (other.CompareTag("ParkingZone")) // Parking zone trigger
        {
            parkingTriggersInside++;
        }

        if (other.CompareTag("Car")) // Other vehicles
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

        if (other.CompareTag("Car"))
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
