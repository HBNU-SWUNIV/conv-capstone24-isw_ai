using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapSelection : MonoBehaviour
{
    public RectTransform cityPanel;        // 도시맵 Panel
    public RectTransform fantasyPanel;     // 판타지맵 Panel
    public float transitionSpeed = 3f;     // 패널 확대 속도 (더 빠르게 설정)
    public float delayBeforeSceneLoad = 2f; // 씬 전환 전 대기 시간
    public float fadeSpeed = 1f;           // 페이드 아웃 속도

    private bool isTransitioning = false;
    private RectTransform selectedPanel;
    private bool isPanelFullScreen = false;
    private CanvasGroup selectedPanelCanvasGroup; // 선택된 패널의 CanvasGroup      // 검은색 배경의 CanvasGroup (페이드 아웃용)

    void Start()
    {
        // 초기화 단계에서 각 패널에 CanvasGroup을 추가
        if (cityPanel.GetComponent<CanvasGroup>() == null)
            cityPanel.gameObject.AddComponent<CanvasGroup>();

        if (fantasyPanel.GetComponent<CanvasGroup>() == null)
            fantasyPanel.gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        if (isTransitioning && selectedPanel != null && !isPanelFullScreen)
        {
            // 선택된 Panel이 화면을 채우도록 크기와 위치 변경
            selectedPanel.sizeDelta = Vector2.Lerp(selectedPanel.sizeDelta, new Vector2(Screen.width, Screen.height), Time.deltaTime * transitionSpeed);
            selectedPanel.anchoredPosition = Vector2.Lerp(selectedPanel.anchoredPosition, Vector2.zero, Time.deltaTime * transitionSpeed);

            // 크기와 위치가 충분히 목표 값에 가까워졌을 때 상태 변경
            if (Vector2.Distance(selectedPanel.sizeDelta, new Vector2(Screen.width, Screen.height)) < 1f &&
                Vector2.Distance(selectedPanel.anchoredPosition, Vector2.zero) < 1f)
            {
                isPanelFullScreen = true;
                selectedPanel.sizeDelta = new Vector2(Screen.width, Screen.height);
                selectedPanel.anchoredPosition = Vector2.zero;
            }

          
        }
    }

    // 도시맵 버튼 클릭 시 호출
    public void OnCityMapButtonClick()
    {
        StartTransition(cityPanel, "map1");
    }

    // 판타지맵 버튼 클릭 시 호출
    public void OnFantasyMapButtonClick()
    {
        StartTransition(fantasyPanel, "EUNSIL_FANTASY1");
    }

    // 패널 확대 및 씬 전환 트리거
    private void StartTransition(RectTransform panel, string sceneName)
    {
        selectedPanel = panel;
        selectedPanelCanvasGroup = selectedPanel.GetComponent<CanvasGroup>(); // CanvasGroup 가져오기
        isTransitioning = true;

        // 패널을 가장 위로 올리기 위해 SetSiblingIndex 사용
        selectedPanel.SetSiblingIndex(selectedPanel.parent.childCount - 1); // 이 패널을 가장 위로 올림


        StartCoroutine(LoadSceneAfterPanelTransition(sceneName));
    }

    // 코루틴: 패널 확대 완료 후 지연 후 씬 전환
    private IEnumerator LoadSceneAfterPanelTransition(string sceneName)
    {
        // 패널이 꽉 차도록 기다림
        while (!isPanelFullScreen)
        {
            yield return null;
        }

        // 추가 지연 시간
        yield return new WaitForSeconds(delayBeforeSceneLoad);

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }
}
