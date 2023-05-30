using UnityEngine;

namespace QuarterDefense.InGame.Character
{
    // Scripted by Raycast
    // 2023. 05. 30
    // Player의 이동을 담당하는 클래스.
    
    public class PlayerMovement : Movement
    {
        private const float MinRange = 2.0f;
        private const float MaxRange = 5.0f;
        
        private bool _isStart;
        
        private void Start()
        {
            _targetPos = GetRandomPos();
        }

        /// <summary>
        /// 이동에 대한 로직을 실행합니다.
        /// </summary>
        protected override void Move()
        {
            if (!CheckMovable())
            {
                if (_isStart) return;
                
                OnMoveFinished.Invoke();
                OnDirectionChanged.Invoke(_targetPos);
                _isStart = true;
                
                return;
            }
            
            OnDirectionChanged.Invoke(_targetPos);
            MovePosition();
        }
        
        /// <summary>
        /// 랜덤으로 위치 값을 반환.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetRandomPos()
        {
            float randomX = Random.Range(MinRange, MaxRange) * GetRandomDirection();
            float randomY = Random.Range(MinRange, MaxRange) * GetRandomDirection();
            
            return new Vector3(randomX, randomY, 0.0f);
        }
        
        /// <summary>
        /// 랜덤으로 좌 또는 우 값을 반환.
        /// </summary>
        /// <returns></returns>
        private float GetRandomDirection()
        {
            return Random.Range(0, 2) > 0 ? 1.0f : -1.0f;
        }
    }
}