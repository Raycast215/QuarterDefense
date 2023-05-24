using System;
using System.Collections;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Player의 공격 모듈.
    
    public class AttackSystem : MonoBehaviour
    {
        public event Action OnAttacked = delegate {  };
        public Func<bool> OnAttackStateChecked = null;

        private float _delay = 0.0f;
        
        public void Set(float attackDelay = 0.0f)
        {
            _delay = attackDelay;
        }

        public void StartAttack()
        {
            StartCoroutine(OnAttack());
        }

        private IEnumerator OnAttack()
        {
            while (true)
            {
                yield return new WaitUntil(OnAttackStateChecked);

                OnAttacked.Invoke();
                
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}