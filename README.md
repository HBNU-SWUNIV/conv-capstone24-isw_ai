# 한밭대학교 인공지능소프트웨어학과 iSW_AI팀

## 팀 구성 
|[정은주](https://github.com/nju26)|[장채은](https://github.com/zzangchaeeun1)|[최은실](https://github.com/eunsil04)|[김은경](https://sites.google.com/view/hisw/professor?authuser=0)
|:---:|:---:|:---:|:---:|
|<img src="https://github.com/user-attachments/assets/5dbc0d15-b06e-46bf-9965-3b708520d302" width="100px" height="100px"/>|<img src="https://github.com/user-attachments/assets/42fba466-40e7-40de-83cc-b1aac7edca43" width="90px" height="90px"/>|<img src="https://github.com/user-attachments/assets/33b11a3f-5ca0-4736-ab33-01f028501f7c" width="100px" height="100px"/>|<img src="https://github.com/user-attachments/assets/74e10a12-2139-48cd-ab85-e8f1c6d13956" width="100px" height="100px"/>|
|팀장 / 강화학습|UI,UX 인터페이스|유니티 맵 구현|지도교수|

- 20221073 정은주
- 20221067 장채은
- 20231077 최은실
- 지도교수    김은경 

## <u>Teamate</u> Project Background
- ### 필요성
  - 실시간 적응과 학습: 강화학습을 통해 AI는 트랙의 다양한 상황에 실시간으로 적응하고, 상황에 맞는 전략을 학습할 수 있다. 이는 고정된 규칙이나 전통적인 방식으로는 해결할 수 없는, 동적인 환경에서의 도전 과제를 해결할 수 있다.
  - 자율성 향상: 차량이 트랙을 스스로 주행하며 경로 최적화와 효율적인 주행을 배우게 된다. 이를 통해 AI는 단순한 명령 수행을 넘어서, 자율적인 판단과 행동을 할 수 있게 되어 더 자연스럽고 현실적인 주행 경험을 제공한다.
    - 유니티에서 강화학습을 통한 차(에이전트)의 주행 학습은 자율 주행, 게임 내 AI, 시뮬레이션 환경 등 다양한 분야에서 매우 중요한 기술적 필요성을 충족시키고, 현실감 있고 도전적인 경험을 제공한다.
      
- ### 기존의 문제점
  - 기존에는 사용자가 차를 직접 조작하여 트랙을 따라가는 방식 -> 자신의 스타일대로 게임을 진행하면 되었기 때문에 최적 경로를 배우거나 최적화된 주행 방법을 익히는 데 한계
  - 강화학습을 통해 AI 차가 최적의 경로를 찾아가며 주행하는 환경으로 변화 -> 사용자는 AI 차가 주행하는 방식을 보고, 어떻게 최적의 경로를 선택할 수 있을지 배울 수 있게 되었다.
  
  
## System Design
  - ### System Requirements
    - Unity(ML-Agents)
    - C#
    - PyTorch
    - TensorFlow
  
  - ### System Design
    <img src="https://github.com/user-attachments/assets/a80198de-c064-4402-800e-e15ab023c430" width="400" height="200" style="display: inline-block; margin-right: 10px;">
    <img src="https://github.com/user-attachments/assets/3a18cfdb-abe7-4184-bf8f-0ef7d7c6fb35" width="400" height="200" style="display: inline-block;">
    
    - 본 프로젝트에서는 Unity 환경에서 ML-Agents를 활용하여 차량 에셋을 이용한 트랙 주행 강화학습을 진행하였다. 강화학습 알고리즘으로는 PPO(Proximal Policy Optimization)를 사용하여 차량이 트랙을 효율적으로 주행할 수 있도록 학습시켰다. 차량은 주행 경로를 따라 이동하면서 주어진 트랙을 잘 주행할 수 있도록 최적의 행동을 학습하게 된다. 학습 과정에서, 차량의 현재 상태와 주행 정보는 ML-Agents를 통해 모델에 입력되며, PPO는 이를 기반으로 정책을 업데이트하고 주행 성능을 향상시킨다.

       
     



  
## Conclusion
  - ### 결과
    ![제목-없는-동영상-Clipchamp로-제작-_3_](https://github.com/user-attachments/assets/681fb454-cd18-4ec8-afca-081f96015da2)
    
    - 강화학습을 통해 차(에이전트)가 트랙을 효과적으로 주행하는 것을 확인할 수 있었다. 특히, 직진 구간뿐만 아니라 커브 구간에서도 원활한 주행을 수행하며, 다양한 주행 상황에 적응하는 능력을 보였다. 에이전트는 강화학습 알고리즘인 PPO를 통해 지속적으로 학습하며, 주행 성능을 점진적으로 향상시켰다. 결과적으로, 트랙 전체를 안정적으로 주행할 수 있는 능력을 갖추게 되었으며, 이는 학습 과정에서 트랙의 다양한 특성에 대한 적응 능력이 향상되었다.

    ![맵화면](https://github.com/user-attachments/assets/2ed13af8-34df-40b7-b64e-84b69ba53fd6)
    
    - 각 트랙은 판타지 맵과 도시 맵 두 가지로 구현되어, 다양한 게임 환경을 제공한다.


  - ### 향후 계획
    - 향후 계획으로는 더 긴 트랙을 포함한 환경에서 강화학습을 진행할 예정이다. 이를 통해 에이전트가 더욱 복잡한 경로를 효율적으로 주행할 수 있도록 학습시키고, 성능을 더욱 향상시킬 계획이다. 또한, 다양한 환경에서의 강화학습을 통해 트랙의 형태나 조건이 달라져도 안정적으로 주행할 수 있는 능력을 갖추도록 할 것이다. 이를 통해 강화학습의 적용 범위를 확장하고, 다양한 시나리오에서의 에이전트 성능을 극대화하는 방향으로 연구를 지속할 예정이다.
   


## Future Work
  - 게임 외에도 자율주행, 로봇 공학 등 다양한 산업에 강화학습을 이용한 AI 기술의 발전 가능성을 확장 기대
  



