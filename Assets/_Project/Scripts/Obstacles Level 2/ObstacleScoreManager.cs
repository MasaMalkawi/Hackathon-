/*using UnityEngine;
using UnityEngine.UI;

public class ObstacleScoreManager : MonoBehaviour
{
    [Header("Scoring System")]
    public float maxScore = 50f;
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
}*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleScoreManager : MonoBehaviour
{
    [Header("Scoring System")]
    public float maxScore = 50f;
    public float obstaclePenalty = 10f;
    public float collectableBonus = 5f;
    public Text scoreText;

    [Header("Audio")]
    public AudioSource crashSound;
    public AudioSource collectSound; // صوت عند جمع العناصر

    [Header("Scene Names")]
    public string gameOverSceneName = "GameOverScene";
    public string winSceneName = "Win";

    void Start()
    {
        UpdateScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit an obstacle!");

            maxScore -= obstaclePenalty;
            maxScore = Mathf.Max(maxScore, 0); // لا يسمح للسكور بأن يكون أقل من 0

            UpdateScoreText();

            if (crashSound != null && !crashSound.isPlaying)
                crashSound.Play();

            CheckGameStatus();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Debug.Log("Collected an item!");

            maxScore += collectableBonus;
            maxScore = Mathf.Min(maxScore, 100); // لا يسمح للسكور بأن يكون أكثر من 100

            UpdateScoreText();

            if (collectSound != null)
                collectSound.Play();

            Destroy(other.gameObject); // حذف العنصر المجمع

            CheckGameStatus();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + maxScore;
        else
            Debug.LogError("UI Text is missing!");
    }

    void CheckGameStatus()
    {
        if (maxScore == 0)
        {
            Debug.Log("Score reached 0. Loading Game Over scene...");
            SceneManager.LoadScene(gameOverSceneName);
        }
        else if (maxScore == 100)
        {
            Debug.Log("Score reached 100. Loading Win scene...");
            SceneManager.LoadScene(winSceneName);
        }
    }
}

