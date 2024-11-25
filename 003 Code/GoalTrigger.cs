using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour
{
    public Text endMessageText;  // 축하 메시지 텍스트
    public Text ResultTime;      // 시간 텍스트
    public Text BestTime;        // 최고 시간 텍스트
    public GameObject RetryButton;  // 리트라이 버튼
    public GameObject BackButton;

    private bool goalReached = false;  // Goal에 도달했는지 여부
    public Timer timer;  // Timer 클래스 사용
    public GameController gameController;  // GameController 참조

    void Start()
    {
        // 초기 UI 설정
        
        endMessageText.gameObject.SetActive(false);
        ResultTime.text = "";
        BestTime.text = "";
        RetryButton.SetActive(false);
        BackButton.SetActive(false);
        goalReached = false; // GoalReached 초기화

        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
        Debug.Log($"Loaded BestTime: {bestTime}");

        if (bestTime == float.MaxValue)
        {
            Debug.Log("No previous BestTime found. This is the first play.");
        }
        else
        {
            Debug.Log($"BestTime found: {bestTime}");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // "Player" 태그를 가진 차량과 충돌
        {
            if (!goalReached)
            {
                goalReached = true;

                // UI 표시 및 최고 시간 저장
                ShowGoalReachedUI();

                if (timer != null)
                {
                    timer.ResetTimer();  // 타이머 초기화
                }
                else
                {
                    Debug.LogError("Timer is not assigned!");
                }

                // 차량 정지 처리
                var kartController = other.GetComponent<KartController>();
                if (kartController != null)
                {
                    kartController.StopCar();
                }
            }
        }
    }

    private void ShowGoalReachedUI()
    {
        if (timer.timerActive)  // 타이머가 작동 중일 때만 UI를 표시
        {
            // 축하 메시지 활성화
            endMessageText.text = "Congratulations!";
            endMessageText.gameObject.SetActive(true);

            // 경과 시간 표시
            DisplayTime();

            // 최고 시간 업데이트 및 표시
            float newBestTime = gameController.SaveAndReturnBestTime(Timer.time);
            DisplayBestTime(newBestTime);

            // 리트라이 버튼 활성화
            RetryButton.SetActive(true);
            BackButton.SetActive(true);
        }
    }

    private void DisplayTime()
    {
        float finalTime = Timer.time;  // 타이머 시간 가져오기
        int minutes = Mathf.FloorToInt(finalTime / 60);  // 분
        int seconds = Mathf.FloorToInt(finalTime % 60);  // 초
        float milliseconds = (finalTime % 1) * 1000;    // 밀리초

        // 결과 텍스트 설정
        ResultTime.text = $"Time: {minutes}m {seconds}s {milliseconds:0}ms";
        Debug.Log($"Final Time: {finalTime}");
    }

    private void DisplayBestTime(float bestTime)
    {
        if (bestTime == float.MaxValue)
        {
            BestTime.text = "Best Time: --m --s --ms";
            Debug.Log("Best Time is not set yet.");
            return;
        }

        int minutes = Mathf.FloorToInt(bestTime / 60);
        int seconds = Mathf.FloorToInt(bestTime % 60);
        float milliseconds = (bestTime % 1) * 1000;

        BestTime.text = $"Best Time: {minutes}m {seconds}s {milliseconds:0}ms";
        Debug.Log($"Displayed Best Time: {bestTime}");
    }


    public void ResetUI()
    {
        // UI 초기화
        endMessageText.gameObject.SetActive(false);
        ResultTime.text = "";
        BestTime.text = "";
        RetryButton.SetActive(false);
        BackButton.SetActive(false);
        goalReached = false;
    }
}
