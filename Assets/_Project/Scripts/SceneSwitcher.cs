using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1); // Load the next scene (Change the index if needed)
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting..."); // This message helps in testing in the Unity Editor
        Application.Quit(); // Closes the game (Works in a built app)
    }
}
