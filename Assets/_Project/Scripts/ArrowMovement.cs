using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float speed = 2f; 
    public float distance = 0.5f; 
    private float startZ;

    void Start()
    {
        startZ = transform.position.z; 
    }

    void Update()
    {
        float newZ = startZ + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
