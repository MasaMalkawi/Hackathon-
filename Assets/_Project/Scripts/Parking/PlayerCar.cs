using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to ScoreManager

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ParkedCar")) // Check if the hit object is a parked car
        {
            Debug.Log("Hit a parked car! -5 points");
            scoreManager.ReduceScore(5); // Subtract 5 points per collision
        }
    }
}
