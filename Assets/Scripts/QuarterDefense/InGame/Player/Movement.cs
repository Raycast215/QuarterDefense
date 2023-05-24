using System;
using System.Collections;
using QuarterDefense.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace QuarterDefense.InGame.Player
{
    public class Movement : MonoBehaviour
    {
        private const float BaseMoveSpeed = 10.0f;
        
        public event Action OnMoved = delegate {  };
        
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        private float _moveSpeed = 10.0f;
        private Vector3 _targetPos = Vector3.zero;
        
        public void Set(float moveSpeed = BaseMoveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        
        public void SetDirection(Vector3 targetPos)
        {
            float distance = transform.position.x - targetPos.x;

            spriteRenderer.flipX = distance > 0;
        }

        public void Move()
        {
            // StartCoroutine(OnMove());
            
            OnMoved.Invoke();
        }
        
       

        private IEnumerator OnMove()
        {
            Vector3 targetPos = GetRandomPos();
            
            while (Vector3.Distance(targetPos, transform.position) >= 0.1f)
            {
                transform.position = 
                    Vector3.MoveTowards(transform.position, GetRandomPos(), _moveSpeed * Time.deltaTime);
        
                yield return null;
            }
            
            OnMoved.Invoke();
        }

        private Vector3 GetRandomPos()
        {
            float randomX = Random.Range(2.0f, 3.0f);
            float randomY = Random.Range(1.0f, 2.0f);
            
            return new Vector3(randomX, randomY, 0.0f);
        }
    }
}


