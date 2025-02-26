using UnityEngine;
using UnityEngine.UI;

public class ObstacleScoreManager : MonoBehaviour
{
    [Header("Scoring System")]
    public float maxScore = 100f;
    public float obstaclePenalty = 10f;
    public float collectableBonus = 5f;
    public Text scoreText;

    [Header("Audio")]
    public AudioSource crashSound;
    public AudioSource collectSound; // Add this for collectable sound

    void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + maxScore;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit an obstacle!");

            maxScore -= obstaclePenalty;
            maxScore = Mathf.Max(maxScore, 0);

            if (scoreText != null)
                scoreText.text = "Score: " + maxScore;

            if (crashSound != null && !crashSound.isPlaying)
                crashSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Debug.Log("Collected an item!");

            maxScore += collectableBonus;

            if (scoreText != null)
                scoreText.text = "Score: " + maxScore;

            if (collectSound != null) // Play collect sound if assigned
                collectSound.Play();

            Destroy(other.gameObject); // Remove collectable
        }
    }
}
