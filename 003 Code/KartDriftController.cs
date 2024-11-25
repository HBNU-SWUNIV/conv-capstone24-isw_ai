using UnityEngine;

public class KartDriftController : MonoBehaviour
{
    public Animator kartAnimator;        // īƮ�� Animator
    public Transform kartTransform;     // īƮ�� Transform
    public float driftSpeed = 10f;      // �帮��Ʈ �̵� �ӵ�
    public ParticleSystem driftParticles; // �帮��Ʈ ��ƼŬ ȿ��
    public float driftDuration = 2f;    // �帮��Ʈ ���� �ð� (��)
    public Vector3 scaleMultiplier = new Vector3(1.5f, 1.5f, 1.5f); // īƮ ũ�� ����

    private Vector3 driftStartPos;
    private Vector3 driftEndPos;
    private float driftProgress = 0f;   // �帮��Ʈ ���൵ (0 ~ 1)
    private bool isDrifting = true;     // �帮��Ʈ ����
    private Vector3 originalScale;      // ���� ũ�� ����

    void Start()
    {
        // ���� ��ġ�� �� ��ġ�� ���� �������� ����
        driftStartPos = new Vector3(0, -2, 10); // ���鿡�� �ָ� ������ ��ġ
        driftEndPos = new Vector3(0, -2, 0);    // �߾����� ����

        // īƮ ��ġ �ʱ�ȭ
        kartTransform.position = driftStartPos;

        // īƮ�� �ʱ� ȸ���� �������� ����
        kartTransform.rotation = Quaternion.Euler(0, 180, 0); // ���� ȸ��

        // ���� īƮ ũ�� ����
        originalScale = kartTransform.localScale;

        // īƮ ũ�� �ʱ�ȭ
        kartTransform.localScale = originalScale;

        // �帮��Ʈ �ִϸ��̼� ����
        kartAnimator.SetTrigger("Drift");

        // �帮��Ʈ ��ƼŬ ȿ�� ����
        StartDriftEffect();
    }

    void Update()
    {
        if (isDrifting)
        {
            // driftSpeed�� ���� �帮��Ʈ ���൵�� ����
            driftProgress += Time.deltaTime * driftSpeed / driftDuration;
            driftProgress = Mathf.Clamp01(driftProgress); // ���൵�� 0 ~ 1�� ����

            // īƮ �̵�
            kartTransform.position = Vector3.Lerp(driftStartPos, driftEndPos, driftProgress);

            // īƮ ũ�⸦ ���������� Ű���
            kartTransform.localScale = Vector3.Lerp(originalScale, scaleMultiplier, driftProgress);

            // �帮��Ʈ �� ȸ���� �����Ͽ� ������ ����
            kartTransform.rotation = Quaternion.Euler(0, 180, 0); // �׻� ���� ȸ�� ����

            // �帮��Ʈ �Ϸ� �� ó��
            if (driftProgress >= 1f)
            {
                StopDrift();
            }
        }
    }

    void StartDriftEffect()
    {
        if (driftParticles != null)
        {
            driftParticles.Play(); // ��ƼŬ ȿ�� ����
        }
    }

    void StopDriftEffect()
    {
        if (driftParticles != null)
        {
            driftParticles.Stop(); // ��ƼŬ ȿ�� ����
        }
    }

    void StopDrift()
    {
        isDrifting = false; // �帮��Ʈ ���� ����
        kartAnimator.SetTrigger("Idle"); // ���� �ִϸ��̼� ����
        StopDriftEffect(); // ��ƼŬ ȿ�� ����
    }

    private void OnDisable()
    {
        // ��ü ��Ȱ��ȭ �� ��ƼŬ�� ����
        StopDriftEffect();
    }
}
