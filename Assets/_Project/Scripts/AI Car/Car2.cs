using UnityEngine;

public class Car2 : MonoBehaviour
{

    public float speed = 15f;  // سرعة السيارة
    public float turnSpeed = 100f; // سرعة الدوران
    public float detectionDistance = 5f;  // المسافة التي تتحقق منها السيارة عن العوائق أمامها
    public LayerMask carLayer;  // الطبقة الخاصة بالسيارات

    private Quaternion targetRotation; // الاتجاه المستهدف
    private Rigidbody rb;

    void Start()
    {
        targetRotation = transform.rotation; // حفظ الاتجاه الحالي
        rb = GetComponent<Rigidbody>();

        // إذا لم يكن هناك Rigidbody، يتم إضافته
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;  // لمنع تأثير الفيزياء
        }
    }

    void Update()
    {
        // تحقق إذا كانت السيارة أمامك مسافة معينة
        if (!IsCarInFront())
        {
            // تحريك السيارة للأمام إذا لم تكن هناك سيارة أمامها
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // تدوير السيارة بسلاسة نحو الاتجاه المستهدف
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TurnPoint2"))
        {
            Debug.Log("السيارة تلف الآن!");
            targetRotation *= Quaternion.Euler(0, 90, 0); // تغيير الاتجاه بزاوية 90 درجة
        }
    }

    // دالة تتحقق من وجود سيارة أمامك باستخدام Raycast
    bool IsCarInFront()
    {
        RaycastHit hit;
        // اطلق Raycast للأمام
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance, carLayer))
        {
            if (hit.collider.CompareTag("Car")) // تأكد من أن الكائن الذي يصطدم هو سيارة
            {
                Debug.Log("هناك سيارة أمامك!");
                return true; // يوجد سيارة أمامك
            }
        }
        return false; // لا يوجد عائق
    }
}
