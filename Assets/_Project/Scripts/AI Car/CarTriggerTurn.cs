/*using UnityEngine;

public class CarTriggerTurn : MonoBehaviour
{
    public float speed = 5f; // سرعة السيارة

    void Update()
    {
        // تحريك السيارة للأمام
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // التأكد أن الكائن الذي لمسته السيارة يحمل التاغ "TurnPoint"
        if (other.CompareTag("TurnPoint"))
        {
            transform.Rotate(0, -90, 0); // دوران السيارة 90 درجة
        }
    }
}*/
using UnityEngine;

public class CarTriggerTurn : MonoBehaviour
{
    public float speed = 15f;  // سرعة السيارة
    public float turnSpeed = 100f; // سرعة الدوران

    private Quaternion targetRotation; // الاتجاه المستهدف

    void Start()
    {
        targetRotation = transform.rotation; // حفظ الاتجاه الحالي
    }

    void Update()
    {
        // تحريك السيارة للأمام
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // تدوير السيارة بسلاسة نحو الاتجاه المستهدف
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TurnPoint"))
        {
            Debug.Log("السيارة تلف الآن!");
            targetRotation *= Quaternion.Euler(0, -90, 0); // تغيير الاتجاه بزاوية 90 درجة
        }
    }
}


