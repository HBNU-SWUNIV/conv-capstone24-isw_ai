using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform buttonRect; // ��ư�� RectTransform
    public Text legacyText;          // ���Ž� UI Text
    public float scaleFactor = 1.2f; // ��ư Ȯ�� ����

    private Vector3 originalScale;   // ��ư�� ���� ũ��

    void Start()
    {
        // ��ư�� ���� ũ�⸦ ����
        if (buttonRect == null)
            buttonRect = GetComponent<RectTransform>();

        originalScale = buttonRect.localScale;

        // ���Ž� �ؽ�Ʈ �ʱ�ȭ (���������� ����)
        if (legacyText != null)
        {
            legacyText = GetComponentInChildren<Text>();
        }
    }

    // ���콺�� ��ư ���� �ö��� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonRect.localScale = originalScale * scaleFactor; // ��ư ũ�� Ȯ��
    }

    // ���콺�� ��ư���� ����� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonRect.localScale = originalScale; // ��ư ũ�� ����
    }
}
