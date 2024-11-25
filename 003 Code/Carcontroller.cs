using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    private Rigidbody rb;

    public WheelCollider frontLeftWheel, frontRightWheel;
    public WheelCollider rearLeftWheel, rearRightWheel;
    public Transform frontLeftWheelreal, frontRightWheelreal;
    public Transform rearLeftWheelreal, rearRightWheelreal;

    private float currentMotorTorque;
    private float currentSteerAngle;

    public float moveSpeed;  
    public float turnSpeed;

    public void Steering(float steerInput)
    {
        currentSteerAngle = steerInput * turnSpeed ;
        frontLeftWheel.steerAngle = currentSteerAngle;
        frontRightWheel.steerAngle = currentSteerAngle;
    }

    public void Motor(float motorInput)
    {
        currentMotorTorque = motorInput * moveSpeed ;
        rearLeftWheel.motorTorque = currentMotorTorque;
        rearRightWheel.motorTorque = currentMotorTorque;
    }


    private void UpdatePosition(WheelCollider wheel, Transform wheelposition)
    {
        wheel.GetWorldPose(out Vector3 position, out Quaternion rotation);
        wheelposition.position = position;
        wheelposition.rotation = rotation;
    }

    private void WheelPosition()
    {
        UpdatePosition(frontLeftWheel, frontLeftWheelreal);
        UpdatePosition(frontRightWheel, frontRightWheelreal);
        UpdatePosition(rearLeftWheel, rearLeftWheelreal);
        UpdatePosition(rearRightWheel, rearRightWheelreal);
    }

    private void Update()
    {
        WheelPosition();
    }

}
