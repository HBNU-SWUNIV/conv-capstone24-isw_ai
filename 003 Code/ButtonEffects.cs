using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform buttonRect; // 버튼의 RectTransform
    public Text legacyText;          // 레거시 UI Text
    public float scaleFactor = 1.2f; // 버튼 확대 비율

    private Vector3 originalScale;   // 버튼의 원래 크기

    void Start()
    {
        // 버튼의 원래 크기를 저장
        if (buttonRect == null)
            buttonRect = GetComponent<RectTransform>();

        originalScale = buttonRect.localScale;

        // 레거시 텍스트 초기화 (선택적으로 설정)
        if (legacyText != null)
        {
            legacyText = GetComponentInChildren<Text>();
        }
    }

    // 마우스가 버튼 위에 올라갔을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonRect.localScale = originalScale * scaleFactor; // 버튼 크기 확대
    }

    // 마우스가 버튼에서 벗어났을 때
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonRect.localScale = originalScale; // 버튼 크기 복원
    }
}
