using UnityEngine;

public class WallManager : MonoBehaviour
{
    public CarAgent caragent;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Car"))
        {
            if(caragent != null)
            {
                caragent.AddReward(-10.0f);
                Debug.Log("�����浹�̴� ������ �̰� Ʋ������/�ٽÿ������ε��ư�");
                caragent.OnEpisodeBegin();
            }
        }
    }
   
}
