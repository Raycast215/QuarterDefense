using System;
using System.Collections;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Player의 공격 모듈.
    
    public class AttackModule : MonoBehaviour
    {
        public event Action OnAttacked = delegate {  };
        
        private EnemySystem _enemySystem = null;

        private float _delay = 0.0f;
        
        public void Set(float attackDelay = 0.0f)
        {
            GameObject.Find("EnemySystem").TryGetComponent(out EnemySystem enySystem);

            _enemySystem = enySystem;

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
                yield return new WaitUntil(CheckAttackState);

                OnAttacked.Invoke();
                
                yield return new WaitForSeconds(_delay);
            }
        }
        
        private bool CheckAttackState()
        {
            return _enemySystem.GetEnemyCount() > 0;
        }
    }
}