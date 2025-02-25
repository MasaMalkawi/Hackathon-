using UnityEngine;
using UnityEngine.UI;

public class ParkingScore : MonoBehaviour
{
    public ParallelParkingCheck parkingCheck;
    public float maxScore = 100f;
    public float collisionPenalty = 20f;
    public Text scoreText;
    private bool scored = false;

    public AudioSource collisionSound; // Reference to AudioSource
    public GameObject warningImage;   // Reference to UI Image

    private void Start()
    {
        scoreText.text = "Score: " + maxScore;

        // Hide the warning image at the start
        if (warningImage != null)
        {
            warningImage.SetActive(false);
        }
    }

    private void Update()
    {
        if (parkingCheck.isParkedCorrectly && !scored)
        {
            scoreText.text = "Final Score: " + maxScore;
            Debug.Log("Final Parking Score: " + maxScore);
            scored = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FrontCar") || collision.gameObject.CompareTag("BackCar"))
        {
            maxScore -= collisionPenalty;
            maxScore = Mathf.Max(maxScore, 0);
            scoreText.text = "Score: " + maxScore;
            Debug.Log("Hit! Score reduced to: " + maxScore);

            if (collisionSound != null)
            {
                collisionSound.Play(); // Play crash sound
            }

            if (warningImage != null)
            {
                warningImage.SetActive(true); // Show warning image
                Invoke("HideWarning", 3f);  // Hide it after 1.5 seconds
            }
        }
    }

    private void HideWarning()
    {
        if (warningImage != null)
        {
            warningImage.SetActive(false);
        }
    }
}
