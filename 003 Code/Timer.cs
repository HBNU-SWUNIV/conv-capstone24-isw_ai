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

            // �ð� ���
            int minutes = Mathf.FloorToInt(time / 60);              // ��
            int seconds = Mathf.FloorToInt(time % 60);              // ��
            float milliseconds = (time - Mathf.Floor(time)) * 1000; // �и���

            // Ÿ�̸� UI ������Ʈ
            uiText.text = $"Time: {minutes}m {seconds}s {milliseconds:000}ms";
        }
    }

    private IEnumerator CountdownAndStartTimer()
    {
        // Ÿ�̸� ���� ���� 3�� ī��Ʈ�ٿ�
        yield return new WaitForSeconds(1f);
        countdownText.text = "Are You Ready?";
        yield return new WaitForSeconds(2f);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "";

        // Ÿ�̸� ����
        timerActive = true;
        canMove = true;
    }

    // ������ �����Ϸ��� ȣ��Ǵ� �޼���
    public void ResetTimer()
    {
        time = 0f;
        timerActive = false;
        canMove = false;
    }
}
