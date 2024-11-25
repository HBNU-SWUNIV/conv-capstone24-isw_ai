using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public static float time;
    public Text uiText;
    public Text countdownText;
    public static bool canMove = false;

    public bool timerActive = false;

    void Start()
    {
        time = 0;
        countdownText.text = "";
        StartCoroutine(CountdownAndStartTimer());
    }

    void Update()
    {
        if (timerActive)
        {
            time += Time.deltaTime;

            // 시간 계산
            int minutes = Mathf.FloorToInt(time / 60);              // 분
            int seconds = Mathf.FloorToInt(time % 60);              // 초
            float milliseconds = (time - Mathf.Floor(time)) * 1000; // 밀리초

            // 타이머 UI 업데이트
            uiText.text = $"Time: {minutes}m {seconds}s {milliseconds:000}ms";
        }
    }

    private IEnumerator CountdownAndStartTimer()
    {
        // 타이머 시작 전에 3초 카운트다운
        yield return new WaitForSeconds(1f);
        countdownText.text = "Are You Ready?";
        yield return new WaitForSeconds(2f);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "";

        // 타이머 시작
        timerActive = true;
        canMove = true;
    }

    // 게임을 리셋하려면 호출되는 메서드
    public void ResetTimer()
    {
        time = 0f;
        timerActive = false;
        canMove = false;
    }
}
