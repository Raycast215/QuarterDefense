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
        
        /// <summary>
        /// 받아온 위치로 저장합니다.
        /// </summary>
        /// <param name="pos"></param>
        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        /// <summary>
        /// 받아온 위치로 타겟을의 위치를 저장합니다.
        /// </summary>
        /// <param name="targetPos"></param>
        public void SetTargetPos(Vector3 targetPos)
        {
            _targetPos = targetPos;
        }

        /// <summary>
        /// 오브젝트의 위치를 이동시킵니다.
        /// </summary>
        protected void MovePosition()
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, _targetPos, MoveSpeed * Time.deltaTime);
        }
        
        /// <summary>
        /// 움직일 수 있는 거리인지 체크합니다.
        /// </summary>
        /// <returns></returns>
        protected bool CheckMovable()
        {
            return Vector3.Distance(transform.position, _targetPos) > 0.0f;
        }
        
        /// <summary>
        /// 오브젝트의 위치를 이동시키는 로직을 실행합니다.
        /// </summary>
        protected abstract void Move();
    }
}