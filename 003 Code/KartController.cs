using UnityEngine;
using UnityEngine.UI;

public class KartController : MonoBehaviour
{
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;

    public float steeringAngle;
    public float speed;
    public float turnSpeed;
    public float wheelTurnSpeed;

    private bool isStopped = false; // 차량 멈춤 상태
    private float currentSteerAngle = 0f;

    public GameObject retryButton; // Retry 버튼

    void Update()
    {
        if (isStopped) return; // 게임이 종료되었으면 업데이트하지 않음

        if (Timer.canMove)
        {
            HandleSteering();
            MoveCar();
            RotateWheels();
        }
    }

    private void HandleSteering()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        currentSteerAngle = steeringAngle * horizontalInput;

        frontLeftWheel.localRotation = Quaternion.Euler(0, currentSteerAngle, 0);
        frontRightWheel.localRotation = Quaternion.Euler(0, currentSteerAngle, 0);
    }

    private void MoveCar()
    {
        transform.Translate(Vector3.forward * speed);

        if (currentSteerAngle != 0)
        {
            float rotationAmount = currentSteerAngle * turnSpeed;
            transform.Rotate(Vector3.up, rotationAmount);
        }
    }

    private void RotateWheels()
    {
        float rotationSpeed = wheelTurnSpeed;

        frontLeftWheel.Rotate(Vector3.right * rotationSpeed);
        frontRightWheel.Rotate(Vector3.right * rotationSpeed);
        rearLeftWheel.Rotate(Vector3.right * rotationSpeed);
        rearRightWheel.Rotate(Vector3.right * rotationSpeed);
    }


    public void StopCar()
{
    speed = 0f; // 차량의 직진 속도를 0으로 설정
    turnSpeed = 0f; // 차량의 회전 속도를 0으로 설정

    Rigidbody rb = GetComponent<Rigidbody>();
    if (rb != null)
    {
        // isKinematic을 비활성화하여 물리적 상호작용을 활성화
        rb.isKinematic = false;

        // 중력의 영향을 받지 않도록 설정
        rb.useGravity = false;

        // 속도와 각속도를 0으로 설정
        rb.linearVelocity = Vector3.zero; // 직선 속도 멈춤
        rb.angularVelocity = Vector3.zero; // 회전 속도 멈춤

        Debug.Log("Car stopped and gravity disabled.");
    }
}

}
