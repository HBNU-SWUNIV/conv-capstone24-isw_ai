using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapSelection : MonoBehaviour
{
    public RectTransform cityPanel;        // ���ø� Panel
    public RectTransform fantasyPanel;     // ��Ÿ���� Panel
    public float transitionSpeed = 3f;     // �г� Ȯ�� �ӵ� (�� ������ ����)
    public float delayBeforeSceneLoad = 2f; // �� ��ȯ �� ��� �ð�
    public float fadeSpeed = 1f;           // ���̵� �ƿ� �ӵ�

    private bool isTransitioning = false;
    private RectTransform selectedPanel;
    private bool isPanelFullScreen = false;
    private CanvasGroup selectedPanelCanvasGroup; // ���õ� �г��� CanvasGroup      // ������ ����� CanvasGroup (���̵� �ƿ���)

    void Start()
    {
        // �ʱ�ȭ �ܰ迡�� �� �гο� CanvasGroup�� �߰�
        if (cityPanel.GetComponent<CanvasGroup>() == null)
            cityPanel.gameObject.AddComponent<CanvasGroup>();

        if (fantasyPanel.GetComponent<CanvasGroup>() == null)
            fantasyPanel.gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        if (isTransitioning && selectedPanel != null && !isPanelFullScreen)
        {
            // ���õ� Panel�� ȭ���� ä�쵵�� ũ��� ��ġ ����
            selectedPanel.sizeDelta = Vector2.Lerp(selectedPanel.sizeDelta, new Vector2(Screen.width, Screen.height), Time.deltaTime * transitionSpeed);
            selectedPanel.anchoredPosition = Vector2.Lerp(selectedPanel.anchoredPosition, Vector2.zero, Time.deltaTime * transitionSpeed);

            // ũ��� ��ġ�� ����� ��ǥ ���� ��������� �� ���� ����
            if (Vector2.Distance(selectedPanel.sizeDelta, new Vector2(Screen.width, Screen.height)) < 1f &&
                Vector2.Distance(selectedPanel.anchoredPosition, Vector2.zero) < 1f)
            {
                isPanelFullScreen = true;
                selectedPanel.sizeDelta = new Vector2(Screen.width, Screen.height);
                selectedPanel.anchoredPosition = Vector2.zero;
            }

          
        }
    }

    // ���ø� ��ư Ŭ�� �� ȣ��
    public void OnCityMapButtonClick()
    {
        StartTransition(cityPanel, "map1");
    }

    // ��Ÿ���� ��ư Ŭ�� �� ȣ��
    public void OnFantasyMapButtonClick()
    {
        StartTransition(fantasyPanel, "EUNSIL_FANTASY1");
    }

    // �г� Ȯ�� �� �� ��ȯ Ʈ����
    private void StartTransition(RectTransform panel, string sceneName)
    {
        selectedPanel = panel;
        selectedPanelCanvasGroup = selectedPanel.GetComponent<CanvasGroup>(); // CanvasGroup ��������
        isTransitioning = true;

        // �г��� ���� ���� �ø��� ���� SetSiblingIndex ���
        selectedPanel.SetSiblingIndex(selectedPanel.parent.childCount - 1); // �� �г��� ���� ���� �ø�


        StartCoroutine(LoadSceneAfterPanelTransition(sceneName));
    }

    // �ڷ�ƾ: �г� Ȯ�� �Ϸ� �� ���� �� �� ��ȯ
    private IEnumerator LoadSceneAfterPanelTransition(string sceneName)
    {
        // �г��� �� ������ ��ٸ�
        while (!isPanelFullScreen)
        {
            yield return null;
        }

        // �߰� ���� �ð�
        yield return new WaitForSeconds(delayBeforeSceneLoad);

        // �� ��ȯ
        SceneManager.LoadScene(sceneName);
    }
}
