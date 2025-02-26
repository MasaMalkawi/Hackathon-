using UnityEngine;
using UnityEngine.UI; // Import UI for Text component

public class ScoreManager : MonoBehaviour
{
    public int score = 100;
    public Text scoreText; // Use normal UI Text

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText")?.GetComponent<Text>();

            if (scoreText == null)
            {
                Debug.LogError("UI Text object 'ScoreText' not found in the scene!");
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
            Debug.LogError("UI Text is missing!");
    }
}

/*using UnityEngine;
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
*/