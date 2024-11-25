# 한밭대학교 인공지능소프트웨어학과 iSW_AI팀

**팀 구성**
- 20221073 정은주
- 20XX0002 장채은
- 20XX0003 최은실

## <u>Teamate</u> Project Background
- ### 필요성
  - 게임 산업에서 AI의 도입은 점차 필수적인 요소로 자리잡고 있으며, 특히 경쟁적이고 도전적인 게임 환경을 제공하는 데 중요한 역할을 합니다. AI 운전자의 적용은 게임 내에서 플레이어와의 상호작용을 더욱 현실적이고 몰입감 있게 만들어 주며, 이는 단순한 게임을 넘어서 전략적 판단과 효율적 경로 최적화 등을 요구하는 고도화된 게임 환경을 형성합니다. 이에 따라, AI 기술을 게임에 접목시키는 것은 게임의 재미와 몰입감을 극대화할 수 있는 중요한 방법이 됩니다.
 
- ### 기존 해결책의 문제점
  - 현재의 게임들에서 AI는 종종 예측 불가능한 행동을 보이며, 플레이어와의 경주에서는 때로는 너무 쉽게 승리하거나 반대로 비현실적으로 느려지는 문제가 발생할 수 있습니다. 대부분의 게임에서 AI는 경로 최적화와 상황에 따른 대응에서 제한적인 성능을 보이고, 게임의 재미와 도전성을 충분히 살리지 못하는 경우가 많습니다.

    또한, 기존의 주행 게임에서는 종종 단순한 물리 엔진에 의존하거나, 정해진 경로에서 AI의 움직임을 제어하는 수준에 그치는 경우가 많았습니다. 이로 인해 게임의 자연스러움이나 몰입감이 떨어지며, AI와의 경쟁이 의미 있는 도전이 되지 못합니다. 본 프로젝트는 이러한 문제를 해결하고, 실시간 학습과 동적 경로 제어를 통해 더욱 도전적이고 몰입감 있는 경주 환경을 제공하고자 합니다.
  
  
## System Design
  - ### System Requirements
    - Unity(ML-Agents), C#
  
  - ### System Design
    - 본 연구에서는 Unity 환경에서 ML-Agents를 활용하여 차량 에셋을 이용한 트랙 주행 강화학습을 진행하였다. 강화학습 알고리즘으로는 PPO(Proximal Policy Optimization)를 사용하여 차량이 트랙을 효율적으로 주행할 수 있도록 학습시켰다. 차량은 주행 경로를 따라 이동하면서 주어진 트랙을 잘 주행할 수 있도록 최적의 행동을 학습하게 된다. 학습 과정에서, 차량의 현재 상태와 주행 정보는 ML-Agents를 통해 모델에 입력되며, PPO는 이를 기반으로 정책을 업데이트하고 주행 성능을 향상시킨다.
     ![system](https://github.com/user-attachments/assets/48ae1bb2-86d6-4430-962c-8078f2ea280e)  ![시스템구조1](https://github.com/user-attachments/assets/a80198de-c064-4402-800e-e15ab023c430)

    
## Case Study
  - ### Description
    - 실제로 AI 운전자가 레이싱 트랙을 주행하면서 최적의 경로를 찾아가는 과정을 보여주는 사례입니다. AI는 강화학습을 통해 주행 경로와 속도 조절을 학습하며, 트랙의 장애물을 피하고 효율적인 경로 선택을 합니다. 이를 통해 AI와의 레이싱에서 더욱 현실적이고 자연스러운 주행이 가능해졌습니다. 또한, 각 트랙은 판타지 맵과 도시 맵 두 가지로 구현되어, 다양한 게임 환경을 제공합니다.
  - ### Results
    - 강화학습을 활용한 AI 운전자의 경로 학습은 단순한 주행을 넘어 플레이어와의 경주에서 더욱 효율적이고 자연스러운 동작을 실현할 수 있었습니다. 판타지 맵에서는 고속 주행과 장애물 회피 능력이 중요한 요소로 작용했으며, 도시 맵에서는 교차로 및 신호등 등 다양한 도시적 요소가 게임의 전략적 판단을 요구하게 했습니다. 이로 인해 플레이어는 AI와의 레이싱에서 도전적이고 몰입감 있는 경험을 할 수 있습니다.
  
  
## Conclusion
  - 본 프로젝트를 통해 강화학습(ML-Agents)을 활용한 AI 운전자의 학습과 최적화를 성공적으로 구현하였으며, 이를 바탕으로 경주 게임 환경을 현실감 있고 도전적인 경험으로 변환할 수 있었습니다. AI는 주행 경로 최적화, 속도 제어, 상황에 따른 반응을 학습하여, 플레이어와의 경쟁에서 더 이상 예측 불가능하거나 비현실적인 동작을 하지 않고, 자연스럽고 현실적인 레이싱 환경을 제공하였습니다.

    이 프로젝트는 AI 기술을 게임 개발에 접목시켜 몰입감 있는



 게임 경험을 제공하고, AI 운전자의 성능을 향상시키는 방법론을 제시했습니다. 향후 더 고도화된 AI 제어 시스템과 더 복잡한 게임 환경을 추가함으로써, 게임의 도전성과 재미를 한층 강화할 수 있을 것입니다.
    
  
## Project Outcome


