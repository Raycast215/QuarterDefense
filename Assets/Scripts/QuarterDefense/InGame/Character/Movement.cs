using System;
using UnityEngine;

namespace QuarterDefense.InGame.Character
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Character의 움직임을 실행하는 클래스.
    
    public abstract class Movement : MonoBehaviour
    {
        private const float MoveSpeed = 5.0f;
        
        public Action OnMoveFinished = delegate {  };
        public Action<Vector3> OnDirectionChanged = delegate {  };
        
        protected Vector3 _targetPos;

        private void FixedUpdate()
        {
            Move();
        }
        
        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        public void SetTargetPos(Vector3 targetPos)
        {
            _targetPos = targetPos;
        }

        protected void MovePosition()
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, _targetPos, MoveSpeed * Time.deltaTime);
        }
        
        protected bool CheckMovable()
        {
            return Vector3.Distance(transform.position, _targetPos) > 0.0f;
        }
        
        protected abstract void Move();
    }
}