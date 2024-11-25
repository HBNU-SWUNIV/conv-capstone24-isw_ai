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
                Debug.Log("벽과충돌이다 무조건 이건 틀린거임/다시원점으로돌아가");
                caragent.OnEpisodeBegin();
            }
        }
    }
   
}
