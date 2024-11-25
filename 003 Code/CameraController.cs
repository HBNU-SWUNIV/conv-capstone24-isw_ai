using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Car;
    public float CarX;
    public float CarY;
    public float CarZ;

   
    void Update()
    {
        CarX = Car.transform.eulerAngles.x;
        CarY = Car.transform.eulerAngles.y;
        CarZ = Car.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX-CarX,CarY, CarZ-CarZ);
    }
}
