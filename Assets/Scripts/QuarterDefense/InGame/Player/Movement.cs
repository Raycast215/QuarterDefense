using System;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Player의 움직임을 실행하는 클래스.
    
    public class Movement : MonoBehaviour
    {
        private const float MinRange = 2.0f;
        private const float MaxRange = 5.0f;
        private const float MovableMinRange = 0.5f;
        private const float MoveSpeed = 5.0f;
        
        public event Action OnMoved = delegate {  };
        
        [SerializeField] private SpriteRenderer spriteRenderer;

        private bool _isStart;
        private Vector3 _targetPos = Vector3.zero;
        
        private void Start()
        {
            _targetPos = GetRandomPos();
        }

        private void FixedUpdate()
        {
            Move();
        }
        
        public void Init()
        {
            _isStart = false;
            transform.position = Vector3.zero;
        }

        /// <summary>
        /// 타겟의 위치를 바라보도록 좌우를 지정합니다.
        /// </summary>
        /// <param name="targetPos"></param>
        public void SetDirection(Vector3 targetPos)
        {
            float distance = transform.position.x - targetPos.x;

            spriteRenderer.flipX = distance > 0;
        }

        /// <summary>
        /// 이동에 대한 로직을 실행합니다.
        /// </summary>
        private void Move()
        {
            if (!CheckMovable())
            {
                if (_isStart) return;
                
                OnMoved.Invoke();
                _isStart = true;
                
                return;
            }
            
            SetDirection(_targetPos);
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, MoveSpeed * Time.deltaTime);
        }

        /// <summary>
        /// 이동 가능 여부를 반환.
        /// </summary>
        /// <returns></returns>
        private bool CheckMovable()
        {
            return Vector3.Distance(transform.position, _targetPos) >= MovableMinRange;
        }

        /// <summary>
        /// 랜덤으로 위치 값을 반환.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetRandomPos()
        {
            float randomX = UnityEngine.Random.Range(MinRange, MaxRange) * GetRandomDirection();
            float randomY = UnityEngine.Random.Range(MinRange, MaxRange) * GetRandomDirection();
            
            return new Vector3(randomX, randomY, 0.0f);
        }
        
        /// <summary>
        /// 랜덤으로 좌 또는 우 값을 반환.
        /// </summary>
        /// <returns></returns>
        private float GetRandomDirection()
        {
            return UnityEngine.Random.Range(0, 2) > 0 ? 1.0f : -1.0f;
        }
    }
}