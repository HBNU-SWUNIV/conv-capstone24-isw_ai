using UnityEngine;

public class KartDriftController : MonoBehaviour
{
    public Animator kartAnimator;        // 카트의 Animator
    public Transform kartTransform;     // 카트의 Transform
    public float driftSpeed = 10f;      // 드리프트 이동 속도
    public ParticleSystem driftParticles; // 드리프트 파티클 효과
    public float driftDuration = 2f;    // 드리프트 지속 시간 (초)
    public Vector3 scaleMultiplier = new Vector3(1.5f, 1.5f, 1.5f); // 카트 크기 조정

    private Vector3 driftStartPos;
    private Vector3 driftEndPos;
    private float driftProgress = 0f;   // 드리프트 진행도 (0 ~ 1)
    private bool isDrifting = true;     // 드리프트 상태
    private Vector3 originalScale;      // 원래 크기 저장

    void Start()
    {
        // 시작 위치와 끝 위치를 정면 기준으로 설정
        driftStartPos = new Vector3(0, -2, 10); // 정면에서 멀리 떨어진 위치
        driftEndPos = new Vector3(0, -2, 0);    // 중앙으로 설정

        // 카트 위치 초기화
        kartTransform.position = driftStartPos;

        // 카트의 초기 회전을 정면으로 설정
        kartTransform.rotation = Quaternion.Euler(0, 180, 0); // 정면 회전

        // 원래 카트 크기 저장
        originalScale = kartTransform.localScale;

        // 카트 크기 초기화
        kartTransform.localScale = originalScale;

        // 드리프트 애니메이션 실행
        kartAnimator.SetTrigger("Drift");

        // 드리프트 파티클 효과 시작
        StartDriftEffect();
    }

    void Update()
    {
        if (isDrifting)
        {
            // driftSpeed에 따라 드리프트 진행도를 증가
            driftProgress += Time.deltaTime * driftSpeed / driftDuration;
            driftProgress = Mathf.Clamp01(driftProgress); // 진행도를 0 ~ 1로 제한

            // 카트 이동
            kartTransform.position = Vector3.Lerp(driftStartPos, driftEndPos, driftProgress);

            // 카트 크기를 점진적으로 키우기
            kartTransform.localScale = Vector3.Lerp(originalScale, scaleMultiplier, driftProgress);

            // 드리프트 중 회전을 고정하여 정면을 유지
            kartTransform.rotation = Quaternion.Euler(0, 180, 0); // 항상 정면 회전 유지

            // 드리프트 완료 후 처리
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
            driftParticles.Play(); // 파티클 효과 시작
        }
    }

    void StopDriftEffect()
    {
        if (driftParticles != null)
        {
            driftParticles.Stop(); // 파티클 효과 멈춤
        }
    }

    void StopDrift()
    {
        isDrifting = false; // 드리프트 상태 종료
        kartAnimator.SetTrigger("Idle"); // 멈춤 애니메이션 실행
        StopDriftEffect(); // 파티클 효과 종료
    }

    private void OnDisable()
    {
        // 객체 비활성화 시 파티클도 멈춤
        StopDriftEffect();
    }
}
