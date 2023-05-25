using System;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Player의 움직임을 실행하는 클래스.
    
    public class Movement : MonoBehaviour
    {
        private const float BaseMoveSpeed = 10.0f;
        
        public event Action OnMoved = delegate {  };
        
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        private bool _isStart = false;
        private float _moveSpeed = 0.0f;
        private Vector3 _targetPos = Vector3.zero;
        
        private void Start()
        {
            _targetPos = GetRandomPos();
        }

        private void FixedUpdate()
        {
            OnMove();
        }
        
        public void Set(float moveSpeed = BaseMoveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        
        public void SetDirection(Vector3 targetPos)
        {
            float distance = transform.position.x - targetPos.x;

            spriteRenderer.flipX = distance > 0;
        }

        private void OnMove()
        {
            if (!CheckMovable())
            {
                if (_isStart) return;
                
                OnMoved.Invoke();
                _isStart = true;
                
                return;
            }
            
            SetDirection(_targetPos);
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
        }

        private bool CheckMovable()
        {
            return Vector3.Distance(transform.position, _targetPos) >= 0.5f;
        }

        private Vector3 GetRandomPos()
        {
            float randomX = UnityEngine.Random.Range(2.0f, 5.0f) * GetRandomDirection();
            float randomY = UnityEngine.Random.Range(2.0f, 5.0f) * GetRandomDirection();
            
            return new Vector3(randomX, randomY, 0.0f);
        }
        
        private float GetRandomDirection()
        {
            return UnityEngine.Random.Range(0, 2) > 0 ? 1 : -1;
        }
    }
}


