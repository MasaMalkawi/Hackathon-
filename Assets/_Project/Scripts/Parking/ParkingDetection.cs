using UnityEngine;

public class ParkingDetection : MonoBehaviour
{
    public Transform parkingSpot; // Drag the parking spot here
    public float positionTolerance = 2.0f; // Distance tolerance
    public float rotationTolerance = 10f; // Angle tolerance
    private bool isParkedCorrectly = false;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, parkingSpot.position);
        float angle = Quaternion.Angle(transform.rotation, parkingSpot.rotation);

        if (distance < positionTolerance && angle < rotationTolerance)
        {
            isParkedCorrectly = true;
            Debug.Log("Perfect parking!");
        }
        else
        {
            isParkedCorrectly = false;
        }
    }
}
