using UnityEngine;

public class NPCWalk : MonoBehaviour
{
    public Transform[] waypoints; // Waypoints for NPC to follow
    public float speed = 2f; // Walking speed
    private int currentWaypointIndex = 0; // Track the current waypoint
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on NPC!");
            return;
        }

        animator.SetBool("isWalking", true); // Use Animator parameter
    }

    void Update()
    {
        if (waypoints.Length == 0) return; // Ensure waypoints exist

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Move NPC towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Rotate smoothly towards the waypoint
        Vector3 direction = targetWaypoint.position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
        }

        // Check if NPC reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.3f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Loop waypoints
        }
    }
}
