using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform WheelFL, WheelFR, WheelRL, WheelRR;
    public WheelCollider WheelFLCol, WheelFRCol, WheelRLCol, WheelRRCol;

    public float SteerAngle = 30;
    public float MotorTorque = 1000;
    public float BrakeTorque = 1000;

    // Update is called once per frame
    void Update()
    {
        HandleWheelColliderPhysics();
        UpdateWheelTransforms();
    }

    private void HandleWheelColliderPhysics()
    {
        float steer = Input.GetAxis("Horizontal");
        float accelerate = Input.GetAxis("Vertical");

        WheelFLCol.steerAngle = SteerAngle * steer;
        WheelFRCol.steerAngle = SteerAngle * steer;

        WheelRLCol.motorTorque = MotorTorque * accelerate;
        WheelRRCol.motorTorque = MotorTorque * accelerate;

        //if (accelerate < 0)
        //{
        //    WheelFLCol.brakeTorque = BrakeTorque;
        //    WheelFRCol.brakeTorque = BrakeTorque;
        //}
        //else
        //{
        //    WheelFLCol.brakeTorque = 0;
        //    WheelFRCol.brakeTorque = 0;
        //}

        if (Input.GetKey(KeyCode.Space))
        {
            WheelRLCol.brakeTorque = BrakeTorque;
            WheelRRCol.brakeTorque = BrakeTorque;
        }
        else
        {
            WheelRLCol.brakeTorque = 0;
            WheelRRCol.brakeTorque = 0;
        }
    }

    private void UpdateWheelTransforms()
    {
        Vector3 pos;
        Quaternion rot;

        WheelFLCol.GetWorldPose(out pos, out rot);
        WheelFL.SetPositionAndRotation(pos, rot);

        WheelFRCol.GetWorldPose(out pos, out rot);
        WheelFR.SetPositionAndRotation(pos, rot);

        WheelRLCol.GetWorldPose(out pos, out rot);
        WheelRL.SetPositionAndRotation(pos, rot);

        WheelRRCol.GetWorldPose(out pos, out rot);
        WheelRR.SetPositionAndRotation(pos, rot);
    }
}
