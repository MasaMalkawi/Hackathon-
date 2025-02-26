/*using UnityEngine;
using TMPro; // Import TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public int score = 100;
    public TMP_Text scoreText; // Ensure TMP_Text is used

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();

            if (scoreText == null)
            {
                Debug.LogError("TextMeshPro object 'ScoreText' not found in the scene!");
                return;
            }
        }

        UpdateScoreText();
    }

    public void ReduceScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        else
            Debug.LogError("TMP Text is missing!");
    }
}*/
using UnityEngine;
using UnityEngine.UI; // تأكد من استيراد مكتبة UI

public class ScoreManager : MonoBehaviour
{
    public int score = 100;
    public Text scoreText; // استخدام Text بدلاً من TMP_Text

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText")?.GetComponent<Text>();

            if (scoreText == null)
            {
                Debug.LogError("❌ خطأ: لم يتم العثور على ScoreText في المشهد! تأكد من إضافته.");
                return;
            }
        }

        UpdateScoreText();
    }

    public void ReduceScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        else
            Debug.LogError("❌ خطأ: عنصر Text غير موجود!");
    }
}
