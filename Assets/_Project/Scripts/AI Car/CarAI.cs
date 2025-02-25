using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public EnemyConfig Config;
    public Transform[] waypoints; // النقاط A, B, C, D
    public NavMeshAgent Agent;

    private int currentWaypointIndex = 0;

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            Agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        Agent.speed = Config.speed;

        // التحقق من الوصول إلى النقطة الحالية
        Vector3 targetPos = waypoints[currentWaypointIndex].position;
        targetPos.y = transform.position.y; // تثبيت ارتفاع السيارة

        if (Vector3.Distance(transform.position, targetPos) < 1)
        {
            RotateCar(); // تدوير السيارة 90 درجة
            MoveToNextWaypoint(); // الانتقال للنقطة التالية
        }
    }

    void RotateCar()
    {
        transform.Rotate(0, 90, 0); // دوران 90 درجة حول المحور Y
    }

    void MoveToNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // الانتقال للنقطة التالية
        Agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
