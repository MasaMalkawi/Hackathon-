using UnityEngine;
using UnityEngine.UI;

public class ParkingManager : MonoBehaviour
{
    public bool isParkedCorrectly = false;

    [Header("Scoring System")]
    public float maxScore = 100f;
    public float collisionPenalty = 20f;
    public Text scoreText;

    [Header("Audio")]
    public AudioSource parkingSound;
    public AudioSource crashSound;

    [Header("UI Elements")]
    public GameObject parkingSuccessImage;
    public GameObject warningImage;

    private bool isColliding = false;
    private bool scored = false;

    void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + maxScore;

        if (parkingSuccessImage != null)
            parkingSuccessImage.SetActive(false);

        if (warningImage != null)
            warningImage.SetActive(false);
    }

    private void Update()
    {
        if (isParkedCorrectly && !scored)
        {
            Debug.Log("Parked Successfully!");
            ShowFinalScore();
            scored = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isParkedCorrectly) return; // If already parked, ignore collisions

        if (collision.gameObject.CompareTag("FrontCar") || collision.gameObject.CompareTag("BackCar"))
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);

            maxScore -= collisionPenalty;
            maxScore = Mathf.Max(maxScore, 0);
            scoreText.text = "Score: " + maxScore;

            if (crashSound != null && !crashSound.isPlaying)
            {
                crashSound.Play();
                Debug.Log("Crash sound played!");
            }

            if (warningImage != null)
            {
                warningImage.SetActive(true);
                Invoke("HideWarning", 3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ParkingZone") && !isColliding)
        {
            isParkedCorrectly = true;
            ShowParkingSuccess();
        }
    }

    private void ShowParkingSuccess()
    {
        if (parkingSuccessImage != null)
            parkingSuccessImage.SetActive(true);

        if (parkingSound != null && !parkingSound.isPlaying)
            parkingSound.Play();
    }

    private void ShowFinalScore()
    {
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Final Score: " + maxScore.ToString("F0");
            Debug.Log("Showing Final Score: " + maxScore);
            Invoke("HideFinalScore", 10f);
        }
    }


    private void HideFinalScore()
    {
        scoreText.gameObject.SetActive(false); // Hide the score text
    }

    private void HideWarning()
    {
        if (warningImage != null)
            warningImage.SetActive(false);
    }
}
