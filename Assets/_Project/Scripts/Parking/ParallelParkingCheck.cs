using UnityEngine;

public class ParallelParkingCheck : MonoBehaviour
{
    public Transform frontCar;
    public Transform backCar;
    public float positionTolerance = 2.0f;
    public float rotationTolerance = 10f;
    public bool isParkedCorrectly = false;

    private void Update()
    {
        float frontDistance = Vector3.Distance(transform.position, frontCar.position);
        float backDistance = Vector3.Distance(transform.position, backCar.position);
        float angle = Quaternion.Angle(transform.rotation, frontCar.rotation);

        if (frontDistance > 2f && backDistance > 2f && angle < rotationTolerance)
        {
            isParkedCorrectly = true;
            Debug.Log("Perfect parking between two cars!");
        }
        else
        {
            isParkedCorrectly = false;
        }
    }
}
